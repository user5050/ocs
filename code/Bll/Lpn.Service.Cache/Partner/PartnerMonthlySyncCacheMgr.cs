using System;
using System.Collections.Generic;
using OneCoin.Service.Cache.Core;
using OneCoin.Service.Cache.Key;

namespace OneCoin.Service.Cache.Partner
{
    public class PartnerMonthlySyncCacheMgr
    {
        /// <summary>
        /// 获取指定parkCode对应的PartnerId
        /// </summary>
        /// <param name="parkCode"></param>
        /// <returns></returns>
        public static string GetPartnerId(string parkCode)
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.Get<string>(string.Format(KeyDefine.PartnerMonthlySyncPc2PIdFormatter, parkCode));
            }
        }

        /// <summary>
        /// 设置指定parkCode对应的PartnerId
        /// </summary>
        /// <param name="parkCode"></param>
        /// <param name="partnerId"></param>
        /// <returns></returns>
        public static bool SetPartnerId(string parkCode,string partnerId)
        {
            using (var client = CacheMgr.GetClient())
            {
                client.AddItemToSet(KeyDefine.PartnerMonthlySyncFormatter, parkCode);
                return client.Set(string.Format(KeyDefine.PartnerMonthlySyncPc2PIdFormatter, parkCode),partnerId);
            }
        }


        /// <summary>
        /// 获取最近一次续费时间
        /// </summary>
        /// <param name="parkCode"></param>
        /// <returns></returns>
        public static DateTime GetUploadTime(string parkCode)
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.Get<DateTime>(string.Format(KeyDefine.PartnerMonthlySyncTimeFormatter, parkCode));
            }
        }

        /// <summary>
        /// 设置最近一次续费时间
        /// </summary>
        /// <param name="parkCode"></param>
        /// <param name="lastConumseTime">最近一次续费时间</param>
        /// <returns></returns>
        public static bool SetUploadTime(string parkCode, DateTime lastConumseTime)
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.Set(string.Format(KeyDefine.PartnerMonthlySyncTimeFormatter, parkCode), lastConumseTime);
            }
        }


        /// <summary>
        /// 获取绑定的停车场编号
        /// </summary>
        /// <returns></returns>
        public static HashSet<string> GetBindParks()
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.GetAllItemsFromSet(KeyDefine.PartnerMonthlySyncFormatter); 
            }
        }

        /// <summary>
        /// 获取指定partnerid对应的key
        /// </summary>
        /// <param name="partnerId"></param>
        /// <returns></returns>
        public static bool IsEnableUpload(string partnerId)
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.Get<string>(string.Format(KeyDefine.PartnerMonthlySyncEnableUploadFormatter, partnerId)) =="true";
            }
        }

    }
}
