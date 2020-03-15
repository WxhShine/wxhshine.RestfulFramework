using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using wxhshine.Infrastructure.Common.Configuration;

namespace wxhshine.Infrastructure.Common.Redis
{
    public class RedisClient : IRedisClient
    {
        private ConnectionMultiplexer Redis { get; }
        private IDatabase RedisDb { get; }

        public RedisClient()
        {
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine(ConfigEntity.Instance.RedisHost);
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Redis = ConnectionMultiplexer.Connect(ConfigEntity.Instance.RedisHost);
            RedisDb = Redis.GetDatabase();
        }

        public bool SetKey(string key, string value, TimeSpan? expiry = null, When when = When.Always)
        {
            return RedisDb.StringSet(key, value, expiry, when);
        }

        public string GetKey(string key)
        {
            return RedisDb.StringGet(key);
        }

        public T DistributionLock<T>(string key, string value, TimeSpan expiry, Func<T> func)
        {
            var retryCount = 0;
            while (!RedisDb.LockTake(key, value, expiry))
            {
                Thread.Sleep(1000);
                if (retryCount++ == 30)
                {
                    throw new Exception("加锁异常-------------");
                }
            }
            try
            {
                return func.Invoke();
            }
            finally
            {
                RedisDb.KeyDelete(key);
            }
        }
    }
}
