using System;
using System.Linq;
using wxhshine.Infrastructure.Common.Kafka;

namespace wxhshine.Infrastructure.Common.Kafka.KafkaEntities
{
    public class TestKafkaEntity : KafkaMessage
    {
        public string ConsumerValue { get; set; }
    }
}
