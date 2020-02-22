using ASPCoreRestfulApiDemo.Data;
using ASPCoreRestfulApiDemo.Entities;
using ASPCoreRestfulApiDemo.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ASPCoreRestfulApiDemo.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AspCoreRestApiDbContext _context;

        public CompanyRepository(AspCoreRestApiDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddCompany(Company company)
        {
            if (company == null)
            {
                throw new ArgumentNullException(nameof(company));
            }

            company.Id = Guid.NewGuid().ToString();
            List<int> ints = new List<int>();
            if(company.Employees != null && company.Employees.Count>0)
                company.Employees.Foreach(x =>
                {
                    x.Id = Guid.NewGuid().ToString();
                });

            _context.Companies.Add(company);
        }

        public void AddEmployee(Guid companyId, Employee employee)
        {
            if(companyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(companyId));
            }
            if (employee == null)
            {
                 throw new ArgumentNullException(nameof(employee));
            }
            employee.CompanyId = companyId.ToString();
           
             employee.Id = Guid.NewGuid().ToString();
            _context.Employees.Add(employee);
        }

        public async Task<bool> CompanyExistsAsync(Guid companyId)
        {
            if(companyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(companyId));
            }
            return await _context.Companies.AnyAsync(x => x.Id == companyId.ToString());
        }

        public void DeleteCompany(Company company)
        {
            if(company == null)
            {
                throw new ArgumentNullException(nameof(company));
            }
            _context.Companies.Remove(company);
        }

        public void DeleteEmployee(Employee employee)
        {

            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            _context.Employees.Remove(employee);
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync(IEnumerable<Guid> companyIds)
        {
            if(companyIds == null)
            {
                throw new ArgumentNullException(nameof(companyIds));
            }
            return await _context.Companies.Where(x => companyIds.Select(x=>x.ToString().ToUpper()).Contains(x.Id)).ToListAsync();
        }

        public async Task<Company> GetCompanyAsync(Guid companyId)
        {
            if(companyId== Guid.Empty)
            {
                throw new ArgumentNullException(nameof(companyId));
            }
            return await _context.Companies.Where(x => x.Id == companyId.ToString()).FirstOrDefaultAsync();
            throw new NotImplementedException();
        }

        public async Task<Employee> GetEmployeeAsync(Guid companyId, Guid employeeId)
        {
            if (companyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(companyId));
            }
            if (employeeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }

            return await _context.Employees.Where(x => x.CompanyId == companyId.ToString() && x.Id == employeeId.ToString()).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId)
        {
            if (companyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(companyId));
            }
            return await _context.Employees.Where(x => x.CompanyId == companyId.ToString()).OrderBy(x=>x.EmployeeNo).ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync()) >= 0;
            throw new NotImplementedException();
        }

        public void UpdateCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
