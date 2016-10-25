using System;
using OneCoin.Service.Cache.Core;
using OneCoin.Service.Cache.Key;

namespace OneCoin.Service.Cache.ShortUrl
{
    public class ShortUrlMgr
    {
        /// <summary>
        /// 添加短连接key
        /// </summary>
        /// <param name="fullUrl"></param>
        /// <param name="shortKey"></param>
        /// <param name="expiresIn"></param>
        public static void Add(string fullUrl, string shortKey,TimeSpan expiresIn)
        {
            using (var client = CacheMgr.GetClient())
            {
                client.Set(string.Format(KeyDefine.ShortUrlCache, shortKey), fullUrl, expiresIn);
            }
        }

        /// <summary>
        /// 获取完整连接
        /// </summary> 
        /// <param name="shortKey">短连接key</param>
        /// <returns></returns>
        public static string Get(string shortKey)
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.Get<string>(string.Format(KeyDefine.ShortUrlCache, shortKey));
            }
        }
    }
}
