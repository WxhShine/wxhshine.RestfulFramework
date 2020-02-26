using ASPCoreRestfulApiDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreRestfulApiDemo.Kafka
{
    interface ITestKafkaConsumer
    {
        void DealMessage(TestKafkaEntity message);
        void Subscribe();
    }
}
