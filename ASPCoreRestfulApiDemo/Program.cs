using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreRestfulApiDemo.Data;
using ASPCoreRestfulApiDemo.Kafka;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ASPCoreRestfulApiDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hostBuilder = CreateHostBuilder(args);
            var host = hostBuilder.Build();
            using (var scope = host.Services.CreateScope())
            {
                var testConsumer = scope.ServiceProvider.GetService<ITestKafkaConsumer>();
                testConsumer.Subscribe();
                var dbContext = scope.ServiceProvider.GetService<AspCoreRestApiDbContext>();
                try
                {
                    //dbContext.Database.EnsureDeleted();
                    dbContext.Database.EnsureCreated();
                    //dbContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetService<ILogger<Program>>();
                    logger.LogError(ex, "数据库连接失败");
                }
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
