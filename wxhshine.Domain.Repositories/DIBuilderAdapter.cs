using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using wxhshine.Domain.IRepositories;
using wxhshine.Infrastructure.Common.Configuration;
using wxhshine.Infrastructure.Common.DIBuilder;

namespace wxhshine.Domain.Repositories
{
    public class DIBuilderAdapter : IDIBuilder
    {
        public void DIBuilder(IServiceCollection services)
        {
            services.AddDbContext<Domian.Entities.AspCoreRestApiDbContext>(x =>
            {
                x.UseMySql(ConfigEntity.Instance.ConnectionStrings.AspCoreRestApiDbStr);
            });

            services.AddScoped<ICompanyRepository, CompanyRepository>();

        }
    }
}
