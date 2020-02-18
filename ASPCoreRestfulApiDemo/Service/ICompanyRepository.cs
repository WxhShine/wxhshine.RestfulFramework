using ASPCoreRestfulApiDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreRestfulApiDemo.Service
{
    public interface ICompanyRepository
    {
        #region 公司相关
        Task<IEnumerable<Company>> GetCompaniesAsync();

        Task<Company> GetCompanyAsync(Guid companyId);

        Task<IEnumerable<Company>> GetCompaniesAsync(IEnumerable<Guid> companyIds);

        void AddCompany(Company company);

        void UpdateCompany(Company company);

        void DeleteCompany(Company company);

        Task<bool> CompanyExistsAsync(Guid companyId);
        #endregion

        #region 员工相关
        Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId);

        Task<Employee> GetEmployeeAsync(Guid companyId, Guid employeeId);

        void AddEmployee(Guid companyId, Employee employee);

        void UpdateEmployee(Employee employee);

        void DeleteEmployee(Employee employee); 
        #endregion

        Task<bool> SaveAsync();
    }
}
