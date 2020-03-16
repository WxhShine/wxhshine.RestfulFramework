using System;
using System.Collections.Generic;
using System.Text;
using wxhshine.Application.DTO;

namespace wxhshine.Application.IServices
{
    public interface ICompanyService
    {
        void AddCompany(AddCompanyDto company);
        /// <summary>
        /// 获取所有公司
        /// </summary>
        /// <returns></returns>
        IEnumerable<CompanyDto> GetCompanies();
        IEnumerable<CompanyDto> GetCompanies(IEnumerable<Guid> companyIds);
    }
}
