using System;
using OneCoin.Service.Cache.Core;
using OneCoin.Service.Cache.Key;

/*
 * 描述: 随机验证码 管理类,
 * 管理 手机号 与 验证码之间的对应关系
 * 作者:lee
 * 创建时间:2015/11/09
 */


namespace OneCoin.Service.Cache.Vcode
{
    public class VCodeCacheMgr
    {
        /// <summary>
        /// 获取指定手机信息对应的验证码
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static string GetVCode(string mobile)
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.Get<string>(string.Format(KeyDefine.MobileVcodeFormatter, mobile));
            }
        }

        /// <summary>
        /// 设置指定手机信息对应的验证码
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="vcode"></param>
        /// <returns></returns>
        public static bool SetVCode(string mobile, string vcode)
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.Set(string.Format(KeyDefine.MobileVcodeFormatter, mobile), vcode, TimeSpan.FromMinutes(5));
            }
        }


        /// <summary>
        /// 是否为白名单手机号码
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static bool IsWhiteMobile(string mobile)
        {
            using (var client = CacheMgr.GetClient())
            {
                var whiteMobile= client.Get<string>(KeyDefine.WhiteMobileKey);

                if (!string.IsNullOrEmpty(whiteMobile))
                {
                    return whiteMobile.IndexOf(mobile, StringComparison.CurrentCulture) >= 0;
                }
            }

            return false;
        }


        /// <summary>
        /// 获取验证码消息模板
        /// </summary> 
        /// <returns></returns>
        public static string GetVCodeMsgTemp()
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.Get<string>(KeyDefine.MobileVcodeMsgTempFormatter);
            }
        }
    }
}
