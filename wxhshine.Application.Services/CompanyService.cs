using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using wxhshine.Application.DTO;
using wxhshine.Application.IServices;
using wxhshine.Domain.IRepositories;
using wxhshine.Domian.Entities;

namespace wxhshine.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void AddCompany(AddCompanyDto companyDto)
        {
            var company = new Company
            {
                Name = companyDto.Name,
                Introduction = companyDto.Introduction
            };
        }

        public IEnumerable<CompanyDto> GetCompanies()
        {
            var companies =  _companyRepository.GetCompaniesAsync().Result;
            return _mapper.Map<IEnumerable<CompanyDto>>(companies);
        }

        public IEnumerable<CompanyDto> GetCompanies(IEnumerable<Guid> companyIds)
        {
            var companies = _companyRepository.GetCompaniesAsync(companyIds).Result;
            return _mapper.Map<IEnumerable<CompanyDto>>(companies);
        }
    }
}
