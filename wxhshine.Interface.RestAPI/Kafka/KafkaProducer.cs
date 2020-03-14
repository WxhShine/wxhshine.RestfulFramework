using ASPCoreRestfulApiDemo.Entities;
using ASPCoreRestfulApiDemo.Utils;
using Confluent.Kafka;
using System;
using System.Threading.Tasks;

namespace ASPCoreRestfulApiDemo.Kafka
{
    public class KafkaProducer
    {
        public static async Task SendAsync<T>(string topic, string value)
        {
            var config = new ProducerConfig { BootstrapServers = ConfigEntity.Instance.kafkaMapping.BootstrapServers };
            using (var p = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    var dr = await p.ProduceAsync(topic, new Message<Null, string> { Value = value });
                    Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
            }
        }
    }
}
