using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreRestfulApiDemo.Entities;
using ASPCoreRestfulApiDemo.Model;
using ASPCoreRestfulApiDemo.Service;
using ASPCoreRestfulApiDemo.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ASPCoreRestfulApiDemo.Controllers
{
    [ApiController]
    [Route("api/compaies/")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyRepository companyRepository,IMapper mapper)
        {
            _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetCompanies()
        {
            var companies = await _companyRepository.GetCompaniesAsync();
            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return new JsonResult(companiesDto);
        }

        [HttpGet("{companyIds}")]
        public async Task<IActionResult> GetCompany([FromRoute][ModelBinder(typeof(ArrayModelBinder))]IEnumerable<Guid> companyIds)
        {
            var companies = await _companyRepository.GetCompaniesAsync(companyIds);
            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return new JsonResult(companiesDto);
        }

        [HttpPost]
        public IActionResult AddCompany(AddCompanyDto request)
        {
            if (!ModelState.IsValid)
            {
                //return 
            }
            var company = new Company
                          {
                              Introduction = request.Introduction,
                              Name = request.Name
                          };
            _companyRepository.AddCompany(company);
            var result = _companyRepository.SaveAsync().Result;
            return Ok();
        }

    }
}