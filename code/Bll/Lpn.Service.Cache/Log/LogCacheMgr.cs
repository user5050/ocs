using OneCoin.Service.Cache.Core;
using OneCoin.Service.Cache.Key;

namespace OneCoin.Service.Cache.Log
{
    public class LogCacheMgr
    {
        /// <summary>
        /// 访问计数
        /// </summary>
        /// <param name="partner"></param>
        /// <param name="modue"></param>
        /// <returns></returns>
        public static long IncrementQueryCnt(string partner,string modue)
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.Increment(string.Format(KeyDefine.PartnerQueryStat, partner, modue), 1);
            }
        }
    }
}
