using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Threading.Tasks;
using wxhshine.Infrastructure.Common.Kafka;
using wxhshine.Infrastructure.Common.Kafka.KafkaEntities;

namespace wxhshine.Interface.RestAPI.Controllers
{
    [Route("api/kafkaSendTest")]
    public class KafkaSendTestController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> KafkaSendMessage()
        {
            await KafkaProducer.SendAsync("test", new TestKafkaEntity { ConsumerValue = "这是通过webAPi发送的Kafka消息:" + DateAndTime.Now.ToString("yyyy-MM-dd  hh:mm:ss") });
            return Ok();
        }
    }
}
