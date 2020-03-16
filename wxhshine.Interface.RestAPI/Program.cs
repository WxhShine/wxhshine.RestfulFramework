using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using wxhshine.Domian.Entities;

namespace wxhshine.Interface.RestAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<AspCoreRestApiDbContext>();
                try
                {

                    dbContext.Database.EnsureDeleted();
                    dbContext.Database.EnsureCreated();
                    //dbContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetService<ILogger<Program>>();
                    logger.LogError(ex, "Ç¨ÒÆÊý¾Ý¿âÊ§°Ü");
                }

                //var testConsumer = scope.ServiceProvider.GetService<TestKafkaConsumer>();
                //testConsumer.Subscribe();
            }
            host.Run(); ;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
