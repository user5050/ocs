using System;
using System.Collections.Generic;
using System.Linq;
using OneCoin.Service.Cache.Core;
using OneCoin.Service.Cache.Key;

namespace OneCoin.Service.Cache.Partner
{
    public class PartnerCacheMgr
    {
        /// <summary>
        /// 获取指定partnerid对应的key
        /// </summary>
        /// <param name="partnerId"></param>
        /// <returns></returns>
        public static string GetKey(string partnerId)
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.Get<string>(string.Format(KeyDefine.PartnerKeyFormatter, partnerId));
            }
        }


        /// <summary>
        /// 获取指定partnerid对应的key
        /// </summary>
        /// <param name="partnerId"></param>
        /// <returns></returns>
        public static string GetName(string partnerId)
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.Get<string>(string.Format(KeyDefine.PartnerNameFormatter, partnerId));
            }
        }

      
        /// <summary>
        /// 获取指定partnerid对应的key
        /// </summary>
        /// <param name="partnerId"></param>
        /// <param name="parkCode"></param>
        /// <returns></returns>
        public static bool IsAuthedParkCode(string partnerId,string parkCode)
        {
            string parks;
            using (var client = CacheMgr.GetClient())
            {
                parks= client.Get<string>(string.Format(KeyDefine.PartnerAuthedParkCodeFormatter, partnerId));
            }

            if (string.IsNullOrEmpty(parks)) return false;

            //不考虑包含关系,比如 11 能绕过授权的 111。
            return parks.IndexOf(parkCode, StringComparison.CurrentCulture) >= 0;
        }


        /// <summary>
        /// 获取指定合作商下属的停车场编号列表
        /// </summary>
        /// <param name="partnerId"></param> 
        /// <returns></returns>
        public static List<string> GetBelongParkCodes(string partnerId)
        {
            string parks;
            using (var client = CacheMgr.GetClient())
            {
                parks = client.Get<string>(string.Format(KeyDefine.PartnerAuthedParkCodeFormatter, partnerId));
            }

            if (string.IsNullOrEmpty(parks)) return null;


            return parks.Split(',').ToList();
        }

        /// <summary>
        /// 获取指定合作商下属的第一个停车场编号
        /// </summary>
        /// <param name="partnerId"></param>
        /// <returns></returns>
        public static string GetFirstOrDefaultBelongParkCode(string partnerId)
        {
            var parks = GetBelongParkCodes(partnerId);

            return parks == null ? string.Empty : parks.FirstOrDefault();
        }


        /// <summary>
        /// 获取指定partnerid对应的key
        /// </summary>
        /// <param name="partnerId"></param>
        /// <returns></returns>
        public static int GetMapedUserId(string partnerId)
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.Get<int>(string.Format(KeyDefine.PartnerMapedUserIdFormatter, partnerId));
            }
        }
    }
}
