using System;
using System.Collections.Generic;
using System.Linq;
using OneCoin.Service.Cache.Core;
using OneCoin.Service.Cache.Key;
using OneCoin.Service.Model.Dto.Response.Product;

namespace OneCoin.Service.Cache.Product
{
    public class ProductCacheMgr
    {

        #region  成员
        public static bool SetMembers(string gameNo,List<GameMember> members,TimeSpan expriesAt)
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.Set(string.Format(KeyDefine.ProductGameMemberCache, gameNo), members, expriesAt);
            }
        }


        public static List<GameMember> GetMembers(string gameNo)
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.Get<List<GameMember>>(string.Format(KeyDefine.ProductGameMemberCache, gameNo));
            }
        }

        public static bool ClearCacheMember(string gameNo)
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.Remove(string.Format(KeyDefine.ProductGameMemberCache, gameNo));
            }
        }
        #endregion

        #region 晒单数

        public static bool SetShowCnt(string pid,int cnt)
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.Set(string.Format(KeyDefine.ProductShowCntCache, pid), cnt);
            }
        }


        public static int GetShowCnt(string pid)
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.Get<int>(string.Format(KeyDefine.ProductShowCntCache, pid));
            }
        }

        #endregion

        #region 参与数量

        public static bool SetJoinCnt(string pid, int cnt)
        {
            using (var client = CacheMgr.GetClient())
            {
                return client.Set(string.Format(KeyDefine.ProductJoinCntCache, pid), cnt);
            }
        }


        public static Dictionary<string,int> GetJoinCnt(List<string> pids)
        {

            var keys = pids.Select(x => string.Format(KeyDefine.ProductJoinCntCache, x)).ToList();

            using (var client = CacheMgr.GetClient())
            {
                return client.GetValuesMap<int>(keys);
            }
        }

        #endregion
    }
}
