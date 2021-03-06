﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wxhshine.Infrastructure.Common.Configuration
{
    public class ConfigEntity
    {
        public static ConfigEntity Instance = new ConfigEntity();
        public KafkaMapping kafkaMapping { get; set; }
        public string ConfigurationShow { get; set; }
        public string RedisHost { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class KafkaMapping
    {
        public string BootstrapServers { get; set; }
    }

    public class ConnectionStrings
    {
        public string AspCoreRestApiDbStr { get; set; }
    }
}
