using System;
using OneCoin.Service.Cache.Core;
using OneCoin.Service.Cache.Key;

/*
 * 描述: 用户登录token 管理类,
 * 管理 用户ID 与 token之间的对应关系
 * 作者:lee
 * 创建时间:2015/10/21
 */


namespace OneCoin.Service.Cache.Token
{
    public class TokenCacheMgr
    {

        /// <summary>
        /// 获取指定token对应的用户ID
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string GetUserId(string token)
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.Get<string>(string.Format(KeyDefine.TokenUserFormatter, token));
            }
        }

        /// <summary>
        /// 设置指定token对应的用户ID
        /// </summary>
        /// <param name="token"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool SetUserId(string token, string userId)
        {
            using (var client = CacheMgr.GetClient())
            {
                // 需要清除掉旧的Token数据，否则存在内存泄漏
                var oldToken = client.Get<string>(string.Format(KeyDefine.TokenUserkeyFormatter, userId));
                if (!string.IsNullOrEmpty(oldToken))
                {
                    client.Remove(string.Format(KeyDefine.TokenUserFormatter, oldToken));
                }

                if (client.Set(string.Format(KeyDefine.TokenUserFormatter, token), userId, DateTime.Now.AddYears(1)))
                {
                    return client.Set(string.Format(KeyDefine.TokenUserkeyFormatter, userId), token, DateTime.Now.AddYears(1));
                }

                return false;
            }
        }

        /// <summary>
        /// 获取用户Token
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string GetUserToken(string userId)
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.Get<string>(string.Format(KeyDefine.TokenUserkeyFormatter, userId));
            }
        }


        public static bool RemoveToken(string userId,string token)
        {
            using (var client = CacheMgr.GetClient())
            {
                client.Remove(string.Format(KeyDefine.TokenUserFormatter, token));
                return client.Remove(string.Format(KeyDefine.TokenUserkeyFormatter, userId)); 
            }
        }
    }
}
 