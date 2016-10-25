using System;
using OneCoin.Service.Cache.Core;
using OneCoin.Service.Cache.Key;

namespace OneCoin.Service.Cache.Stat
{
    public class ModuleStatCacheMgr
    {
        /// <summary>
        /// 增加统计计数
        /// </summary>
        /// <param name="module">模块</param>
        /// <param name="subModule">子模块</param>
        /// <param name="val">状态值</param>
        public static void AddStat(string module,string subModule,string val)
        {
            using (var client = CacheMgr.GetClient())
            { 
                var key = string.Format(KeyDefine.ModuleStat, module, subModule, val, DateTime.Now.ToString("yyyyMMdd"));
                client.Increment(key,1);
                client.ExpireEntryAt(key, DateTime.Now.Date.AddDays(2));
            }
        }

        /// <summary>
        /// 获取统计计数
        /// </summary>
        /// <param name="module">模块</param>
        /// <param name="subModule">子模块</param>
        /// <param name="val">状态值</param>
        /// <param name="date">统计日期</param>
        /// <returns></returns>
        public static int GetStat(string module, string subModule, string val,DateTime date)
        {
            using (var client = CacheMgr.GetClient())
            {
                var key = string.Format(KeyDefine.ModuleStat, module, subModule, val, date.ToString("yyyyMMdd"));
                return client.Get<int>(key);
            }
        }
    }
}
