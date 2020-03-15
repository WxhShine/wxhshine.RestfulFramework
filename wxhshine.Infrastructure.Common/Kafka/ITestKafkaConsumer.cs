using wxhshine.Infrastructure.Common.Kafka.KafkaEntities;

namespace wxhshine.Infrastructure.Common.Kafka
{
    interface ITestKafkaConsumer
    {
        void DealMessage(TestKafkaEntity message);
        void Subscribe();
    }
}
