using ASPCoreRestfulApiDemo.CommonBase.Redis;
using ASPCoreRestfulApiDemo.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreRestfulApiDemo.Controllers
{
    [ApiController]
    [Route("api/redis/")]
    public class RedisTestController : ControllerBase
    {
        private readonly IRedisClient _redis;

        public RedisTestController(IRedisClient redis)
        {
            _redis = redis ?? throw new ArgumentNullException(nameof(redis));
        }

        [HttpPost]
        public IActionResult SetKey([FromBody]RedisSetDto request)
        {
            return Ok(_redis.SetKey(request.Key, request.Value, request.Expiry));
        }

        [HttpGet("{key}")]
        public ActionResult<string> GetKey(string key)
        {
            return _redis.GetKey(key);
        }
    }
}
