using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using OneCoin.Service.Bll.Core;
using OneCoin.Service.Bll.Logic.SysUser;
using OneCoin.Service.Cache.Product;
using OneCoin.Service.Dal.Dal.Game;
using OneCoin.Service.Model.Db.Game;
using OneCoin.Service.Model.Dto.Response.Product;
using System.Linq;
using OneCoin.Service.Model.Extension.Product;

namespace OneCoin.Service.Bll.Logic.Game
{
    public class GameMemberBll : BllBase
    {
        public static List<GameMember> GetMembers(string gameNo, bool isIn, int lastNo, int take)
        {
            // 进行中的可以尝试从缓存中获取, 有新订单需要清除缓存 TODO
            if (isIn && lastNo == 99999999)
            {
                var cache = ProductCacheMgr.GetMembers(gameNo);
                if (cache != null && cache.Count == take)
                {
                    return cache;
                }
            }

            var members = GameMemberDal.GetMembers(gameNo, lastNo, take);

            var users = UserBll.GetUsers(members.Select(x => x.UId).ToList());

            var ret = members.ToDto(users);

            // 首页缓存
            if (isIn && lastNo == 99999999 && ret.Count == take)
            {
                ProductCacheMgr.SetMembers(gameNo, ret, TimeSpan.FromMinutes(2));
            }

            return ret;
        }

        internal static void Save(MySqlConnection conn, string gameNo, string orderNo, string userId, string ipAddr, int curCanBuyAmount, int startNo, int endNo)
        {
            //保存记录
            if (! GameMemberDal.Insert(conn, new GameMemberDb
                {
                    BuyAmount = curCanBuyAmount,
                    EndNo = endNo,
                    GameNo = gameNo,
                    IpAddr = ipAddr,
                    OrderNo = orderNo,
                    RowTime = DateTime.Now,
                    StartNo = startNo,
                    UId = userId
                }))
            {
                throw  new Exception("保存参与记录");
            }

            //更新统计
            if (! GameMemberStatDal.Save(conn, new GameMemberStatDb
                {
                    BuyAmount = curCanBuyAmount,
                    GameNo = gameNo,
                    RowTime = DateTime.Now,
                    UId = userId
                }))
            {
                throw new Exception("更新统计");
            }
        }

        internal static GameMemberDb FindMember(string gameNo,int winNo)
        {
            return GameMemberDal.FindMemberWithNo(gameNo, winNo);
        }
    }
}
