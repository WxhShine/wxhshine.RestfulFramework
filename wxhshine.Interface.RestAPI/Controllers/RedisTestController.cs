using Microsoft.AspNetCore.Mvc;
using System;
using wxhshine.Application.DTO;
using wxhshine.Infrastructure.Common.Redis;

namespace wxhshine.Interface.RestAPI.Controllers
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
