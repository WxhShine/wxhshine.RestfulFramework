using StackExchange.Redis;
using System;
using System.Linq;

namespace ASPCoreRestfulApiDemo.CommonBase.Redis
{
    public interface IRedisClient
    {
        T DistributionLock<T>(string key, string value, TimeSpan expiry, Func<T> func);
        string GetKey(string key);
        bool SetKey(string key, string value, TimeSpan? expiry = null, When when = When.Always);
    }
}
