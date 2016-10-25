using OneCoin.Service.Cache.Core;
using OneCoin.Service.Cache.Key;

namespace OneCoin.Service.Cache.Banner
{
    public class BannerCacheMgr
    {
        /// <summary>
        /// 获取预览白名单
        /// </summary>
        /// <param name="cityCode"></param>
        /// <returns></returns>
        public static string GetWhiteMobile()
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.Get<string>(KeyDefine.BannerWhiteMobileKey);
            }
        }
    }
}
