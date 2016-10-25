using System;
using OneCoin.Service.Cache.Core;
using OneCoin.Service.Cache.Key;
/*
 * 描述: 账号相关缓存 管理类,
 * 管理 用户名,用户id的对应关系
 * 作者:lee
 * 创建时间:2015/10/19
 */

namespace OneCoin.Service.Cache.User
{
    public class UserCacheMgr
    {
        /// <summary>
        /// 获取指定用户名对应的用户ID
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static int GetUserIdByName(string userName)
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.Get<int>(string.Format(KeyDefine.UserNameIdFormatter, userName));
            }
        }



        /// <summary>
        /// 获取指定用户ID对应的用户名
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string GetUserNameById(int userId)
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.Get<string>(string.Format(KeyDefine.UserIdNameFormatter, userId));
            }
        } 

        /// <summary>
        /// 设置指定用户名和用户ID对应关系
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool SetUserIdNameMap(string userName, string userId)
        {
            using (var client = CacheMgr.GetClient())
            {
                client.Set(string.Format(KeyDefine.UserNameIdFormatter, userName), userId, DateTime.Now.AddDays(15));
                return client.Set(string.Format(KeyDefine.UserIdNameFormatter, userId), userName, DateTime.Now.AddDays(15));
            }
        }

        /// <summary>
        /// 删除指定用户名和用户ID对应关系
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool RemoveUserIdNameMap(string userName, string userId)
        {
            using (var client = CacheMgr.GetClient())
            {
                client.Remove(string.Format(KeyDefine.UserNameIdFormatter, userName));
                return client.Remove(string.Format(KeyDefine.UserIdNameFormatter, userId));
            }
        }



        /// <summary>
        /// 是否为泊客侠用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool IsBelongToBkx(int userId)
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.Get<string>(string.Format(KeyDefine.UserIsBelongToBkx, userId)) == "true";
            }
        }
         

        /// <summary>
        /// 设置为宜泊用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool SetBelongToEbo(int userId)
        {
            using (var client = CacheMgr.GetClient())
            {
                if (client.ContainsKey(string.Format(KeyDefine.UserIsBelongToBkx, userId)))
                {
                    return client.Set(string.Format(KeyDefine.UserIsBelongToBkx, userId), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); 
                }
            }

            return false;
        }
    }
}
