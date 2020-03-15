using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using wxhshine.Domain.IRepositories;
using wxhshine.Infrastructure.Common.DIBuilder;

namespace wxhshine.Domain.Repositories
{
    public class DIBuilderAdapter : IDIBuilder
    {
        public void DIBuilder(IServiceCollection services)
        {
            services.AddScoped<ICompanyRepository, CompanyRepository>();
        }
    }
}
