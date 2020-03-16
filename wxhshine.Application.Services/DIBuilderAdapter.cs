using Microsoft.Extensions.DependencyInjection;
using wxhshine.Application.IServices;
using wxhshine.Infrastructure.Common.DIBuilder;

namespace wxhshine.Application.Services
{
    public class DIBuilderAdapter : IDIBuilder
    {
        public void DIBuilder(IServiceCollection services)
        {
            services.AddScoped<ICompanyService, CompanyService>();
        }
    }
}
