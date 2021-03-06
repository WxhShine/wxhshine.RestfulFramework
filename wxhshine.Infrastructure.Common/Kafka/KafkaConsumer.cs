﻿using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wxhshine.Infrastructure.Common.Configuration;

namespace wxhshine.Infrastructure.Common.Kafka
{
    public class KafkaConsumer<T> where   T : KafkaMessage
    {
        public string Topic { get; set; }
        public string ConsumerGroup { get; set; }

        public void Subscribe(Action<T> dealMessage)
        {

            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine(ConfigEntity.Instance.kafkaMapping.BootstrapServers);
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            var config = new ConsumerConfig
            {
                GroupId = ConsumerGroup,
                BootstrapServers = ConfigEntity.Instance.kafkaMapping.BootstrapServers,
                AutoOffsetReset = AutoOffsetReset.Latest
            };
            Task.Run(() =>
           {
               var builder = new ConsumerBuilder<string, string>(config);
               using (var consumer = builder.Build())
               {
                   consumer.Subscribe(Topic);
                   while (true)
                   {
                       var result = consumer.Consume();
                       try
                       {
                           var message = JsonConvert.DeserializeObject<T>(result.Value);
                           dealMessage(message);
                       }
                       catch (Exception)
                       {
                           Console.WriteLine($"Topic : {result.Topic}, Message : {result.Value}");
                       }
                   }
               }
           });
        }
    }
}
