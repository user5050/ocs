using OneCoin.Service.Cache.Key;
using OneCoin.Service.Model.Config;
using ServiceStack.Redis;

/*
* 描述: redis管理类
* 作者:lee
* 创建时间:2015/10/21
*/

namespace OneCoin.Service.Cache.Core
{
    public class CacheMgr
    {
        private static PooledRedisClientManager _pooledRedis=null;

        static CacheMgr()
        {
            if (_pooledRedis == null)
            {
                var cfg = new RedisClientManagerConfig
                    {
                        AutoStart = true,
                        DefaultDb = WebConfig.DefaultRedisDb,
                        MaxReadPoolSize = WebConfig.PoolSize,
                        MaxWritePoolSize = WebConfig.PoolTimeOutSeconds
                    };

                //127.0.0.1:6379
                _pooledRedis = new PooledRedisClientManager(WebConfig.ReadWriteHosts.Split(';'), null, cfg);
            }
        }

    

        public static IRedisClient GetClient()
        {
            return _pooledRedis.GetClient();
        }


        public static string Test()
        {
            using (var client = GetClient())
            {
                client.Set("Key1", "川AEEE28");
 
                return client.Get<string>("key1");
            }
        }
    }

    
}
