using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreRestfulApiDemo.Kafka
{
    public abstract class KafkaConsumer<T> where   T : KafkaMessage
    {
        public string Topic { get; set; }
        public string ConsumerGroup { get; set; }
        public abstract void DealMessage(T message);

        public void Subscribe()
        {
            
        }
    }
}
