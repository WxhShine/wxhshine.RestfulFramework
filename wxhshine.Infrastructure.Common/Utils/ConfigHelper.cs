using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace wxhshine.Infrastructure.Common.Utils
{
    public static class ConfigHelper
    {
        // <summary>
        /// 获取配置文件中的内容，继承自IConfiguration
        /// </summary>
        private static IConfiguration _configuration { get; set; }

        static ConfigHelper()
        {
            //在当前目录或者根目录中寻找appsettings.json文件
            var fileName = "appsettings.json";

            var directory = AppContext.BaseDirectory;
            directory = directory.Replace("\\", "/");

            var filePath = $"{directory}/{fileName}";

            var builder = new ConfigurationBuilder()
                .AddJsonFile(filePath, false, true);

            _configuration = builder.Build();
        }

        public static string GetConfig(string configName)
        {
            return _configuration[configName];
        }
    }
}
