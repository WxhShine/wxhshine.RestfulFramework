using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using wxhshine.Application.DTO;
using wxhshine.Application.IServices;
using wxhshine.Domian.Entities;
using wxhshine.Interface.RestAPI.Models;

namespace wxhshine.Interface.RestAPI.Controllers
{
    [ApiController]
    [Route("api/compaies/")]
    //[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService ?? throw new ArgumentNullException(nameof(companyService));
        }

        [HttpGet]
        public ActionResult<IEnumerable<CompanyDto>> GetCompanies()
        {
            var companies = _companyService.GetCompanies();
            return new JsonResult(companies);
        }

        [HttpGet("{companyIds}")]
        public IActionResult GetCompany([FromRoute][ModelBinder(typeof(ArrayModelBinder))]IEnumerable<Guid> companyIds)
        {
            var companies = _companyService.GetCompanies(companyIds);
            return new JsonResult(companies);
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
            _companyService.AddCompany(request);
            return Ok();
        }

    }
}