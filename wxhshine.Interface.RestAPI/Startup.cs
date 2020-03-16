using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using wxhshine.Application.DTO.Profiles;
using wxhshine.Infrastructure.Common.Configuration;
using wxhshine.Infrastructure.Common.DIBuilder;
using wxhshine.Infrastructure.Common.Utils;

namespace wxhshine.Interface.RestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(x =>
            {
                x.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
            {
                o.LoginPath = new PathString(@"/api/login/reLogin");
            });

            services.AddAutoMapper(typeof(CompanyProfile));

            Configuration.GetSection("ConfigEntity").Bind(ConfigEntity.Instance);


            var diTypes = AppDomainTypeFinder.GetSubClassType(typeof(IDIBuilder));
            diTypes.Foreach(x =>
            {
                var instance = (IDIBuilder)Activator.CreateInstance(x);
                instance.DIBuilder(services);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("Error!");
                    });
                });
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
