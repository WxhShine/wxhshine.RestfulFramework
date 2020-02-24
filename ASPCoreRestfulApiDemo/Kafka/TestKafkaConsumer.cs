using ASPCoreRestfulApiDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreRestfulApiDemo.Kafka
{
    public class TestKafkaConsumer : KafkaConsumer<TestKafkaEntity>
    {
        public TestKafkaConsumer()
        {
            Topic = "test";
        }
        public override void DealMessage(TestKafkaEntity message)
        {
            throw new NotImplementedException();
        }
    }
}
