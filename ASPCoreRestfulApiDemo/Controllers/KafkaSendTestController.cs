using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreRestfulApiDemo.Entities;
using ASPCoreRestfulApiDemo.Kafka;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace ASPCoreRestfulApiDemo.Controllers
{
    [Route("api/kafkaSendTest")]
    public class KafkaSendTestController : ControllerBase
    {
        [HttpGet("sendMessage/{message}")]
        public async Task<IActionResult>  KafkaSendMessage(string message)
        {
            await KafkaProducer.SendAsync("test", new TestKafkaEntity { ConsumerValue = "这是通过webAPi发送的Kafka消息:" + DateAndTime.Now.ToString("yyyy-MM-dd  hh:mm:ss") });
            return Ok();
        }
    }
}
