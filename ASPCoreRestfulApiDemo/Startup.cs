using ASPCoreRestfulApiDemo.CommonBase.Redis;
using ASPCoreRestfulApiDemo.Configuration;
using ASPCoreRestfulApiDemo.Data;
using ASPCoreRestfulApiDemo.Kafka;
using ASPCoreRestfulApiDemo.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace ASPCoreRestfulApiDemo
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(x =>
            {
                x.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                               o =>
                               {
                                   o.LoginPath = new PathString(@"/api/login/reLogin");
                               });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<AspCoreRestApiDbContext>(x =>
            {
                x.UseMySQL(Configuration.GetConnectionString("AspCoreRestApiDbStr"));
            });

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddSingleton<ITestKafkaConsumer, TestKafkaConsumer>();
            services.AddSingleton<IRedisClient, RedisClient>();

            Configuration.GetSection("ConfigEntity").Bind(ConfigEntity.Instance);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
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
