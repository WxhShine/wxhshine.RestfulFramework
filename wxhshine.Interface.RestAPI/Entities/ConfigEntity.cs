using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreRestfulApiDemo.Entities
{
    public class ConfigEntity
    {
        public static ConfigEntity Instance = new ConfigEntity();
        public KafkaMapping kafkaMapping { get; set; }
        public string ConfigurationShow { get; set; }
    }

    public class KafkaMapping
    {
        public string BootstrapServers { get; set; }
    }
}
