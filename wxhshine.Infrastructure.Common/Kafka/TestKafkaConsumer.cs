using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wxhshine.Infrastructure.Common.Kafka.KafkaEntities;

namespace wxhshine.Infrastructure.Common.Kafka
{
    public class TestKafkaConsumer : ITestKafkaConsumer
    {

        private KafkaConsumer<TestKafkaEntity> consumer { get; set; }

        public TestKafkaConsumer()
        {
            consumer = new KafkaConsumer<TestKafkaEntity>
            {
                Topic = "test",
                ConsumerGroup = "console-consumer-63873",
            };

        }
        public void DealMessage(TestKafkaEntity message)
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("这是一个消费者!!!" + message.ConsumerValue);
            Console.WriteLine("-------------------------------------------------------------");
        }

        public void Subscribe()
        {
            consumer.Subscribe(DealMessage);
        }
    }
}
