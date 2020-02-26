using ASPCoreRestfulApiDemo.Entities;
using ASPCoreRestfulApiDemo.Utils;
using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace ASPCoreRestfulApiDemo.Kafka
{
    public class KafkaProducer
    {
        public static async Task SendAsync<T>(string topic, T value) where T: KafkaMessage
        {
            var config = new ProducerConfig { BootstrapServers = ConfigEntity.Instance.kafkaMapping.BootstrapServers };
            ProducerBuilder<Null, string> producerBuilder = new ProducerBuilder<Null, string>(config);
            using (var p = producerBuilder.Build())
            {
                try
                {
                    var dr = await p.ProduceAsync(topic, new Message<Null, string> { Value = JsonConvert.SerializeObject(value) });
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
