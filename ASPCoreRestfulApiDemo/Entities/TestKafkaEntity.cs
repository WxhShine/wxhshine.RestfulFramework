using ASPCoreRestfulApiDemo.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreRestfulApiDemo.Entities
{
    [Serializable]
    public class TestKafkaEntity : KafkaMessage
    {
        public string ConsumerValue { get; set; }
    }
}
