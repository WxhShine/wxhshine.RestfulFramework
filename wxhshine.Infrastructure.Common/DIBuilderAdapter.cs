using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using wxhshine.Infrastructure.Common.Configuration;
using wxhshine.Infrastructure.Common.DIBuilder;
using wxhshine.Infrastructure.Common.Kafka;
using wxhshine.Infrastructure.Common.Redis;

namespace wxhshine.Infrastructure.Common
{
    public class DIBuilderAdapter : IDIBuilder
    {
        public void DIBuilder(IServiceCollection services)
        {
            services.AddSingleton<ITestKafkaConsumer, TestKafkaConsumer>();
            services.AddSingleton<IRedisClient, RedisClient>();
        }
    }
}
