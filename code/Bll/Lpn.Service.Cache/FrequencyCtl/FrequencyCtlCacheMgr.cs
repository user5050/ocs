using System;
using OneCoin.Service.Cache.Core;
using OneCoin.Service.Cache.Key;

namespace OneCoin.Service.Cache.FrequencyCtl
{
    public class FrequencyCtlCacheMgr
    {

        /// <summary>
        /// 操作日志
        /// </summary> 
        /// <returns></returns>
        public static bool AddActionLog(string action, string userId, TimeSpan expired)
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.Set(string.Format(KeyDefine.FrequencyCache, action, userId), "1", expired);
            }
        }


        /// <summary>
        /// 是否可以操作
        /// </summary> 
        /// <returns></returns>
        public static bool IsCanDo(string action, string userId)
        {
            using (var client = CacheMgr.GetClient())
            {
                return !client.ContainsKey(string.Format(KeyDefine.FrequencyCache, action, userId));
            }
        }
    }
}
