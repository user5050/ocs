using System;
using OneCoin.Service.Cache.Core;
using OneCoin.Service.Cache.Key;
using OneCoin.Service.Model.Entity.Coupon;

/*
 * 描述: 优惠券预先看 管理类,
 * 管理 用户ID 与 token之间的对应关系
 * 作者:lee
 * 创建时间:2015/10/21
 */


namespace OneCoin.Service.Cache.Coupon
{
    public class CouponCacheMgr
    {

        /// <summary>
        /// 获取指定token对应的优惠券信息
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static CouponViewCache Get(string token)
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.Get<CouponViewCache>(string.Format(KeyDefine.CouponPreViewCache, token));
            }
        }


        /// <summary>
        /// 获取指定token对应的优惠券信息
        /// </summary>
        /// <param name="token"></param>
        /// <param name="data"></param>
        /// <param name="cacheMinutes"></param>
        /// <returns></returns>
        public static bool Save(string token,CouponViewCache data,int cacheMinutes=15)
        {
            if (cacheMinutes <= 0) cacheMinutes = 15;

            using (var client = CacheMgr.GetClient())
            {
                return client.Set(string.Format(KeyDefine.CouponPreViewCache, token), data,DateTime.Now.AddMinutes(cacheMinutes));
            }
        } 
    }
}
 