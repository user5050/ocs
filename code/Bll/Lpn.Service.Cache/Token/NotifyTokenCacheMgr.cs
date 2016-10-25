using OneCoin.Service.Cache.Core;
using OneCoin.Service.Cache.Key;
using OneCoin.Service.Model.Entity.SysUser;

namespace OneCoin.Service.Cache.Token
{
    public class NotifyTokenCacheMgr
    {
        /// <summary>
        /// 获取指定userid对应的IOS TOKEN
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static UserNotifyToken GetToken(int userId)
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.Get<UserNotifyToken>(string.Format(KeyDefine.TokenIosTokenFormatter, userId));
            }
        }

        /// <summary>
        /// 设置指定userid对应的IOS TOKEN
        /// </summary>
        /// <param name="token"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool SetToken(int userId, UserNotifyToken token)
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.Set(string.Format(KeyDefine.TokenIosTokenFormatter, userId), token);
            }
        }
    }
}
