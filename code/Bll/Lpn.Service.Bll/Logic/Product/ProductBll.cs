using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using OneCoin.Service.Bll.Core;
using OneCoin.Service.Bll.Logic.Game;
using OneCoin.Service.Bll.Logic.SysUser;
using OneCoin.Service.Cache.Product;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Dal.Dal.Game;
using OneCoin.Service.Dal.Dal.Product;
using OneCoin.Service.Helper.Log;
using OneCoin.Service.Model.Db.Orders;
using OneCoin.Service.Model.Db.Product;
using OneCoin.Service.Model.Enum;
using OneCoin.Service.Model.Enum.Product;
using OneCoin.Service.Model.Extension.Product;
using OneCoin.Service.Model.Result;
using System.Linq;

namespace OneCoin.Service.Bll.Logic.Product
{
    public class ProductBll : BllBase
    {
        #region 商品列表
        /// <summary>
        /// 商品列表
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public static ResultDto Get(int skip, int take)
        {
            return ResultDto.DefaultSuccess(ProductInfoDal.GetInGame(skip, take));
        }
        #endregion

        #region 商品最新游戏情况
        /// <summary>
        /// 商品最新游戏情况
        /// </summary> 
        /// <returns></returns>
        public static ResultDto GetProductGameLastInfo(string pid)
        {
            return ResultDto.DefaultSuccess(ProductInfoDal.GetInGameOfProduct(pid));
        }
        #endregion

        #region 商品详情
        /// <summary>
        /// 商品详情
        /// </summary>
        /// <param name="gameNo"></param>
        /// <returns></returns>
        public static ResultDto Detail(string gameNo)
        {
            var game = ProductGameDal.GetByPriKey(gameNo);
            if (game == null) return ResultDto.DefaultError(ResultState.GlobalParameterError);

            var product = ProductInfoDal.GetByPriKey(game.Pid);
            if (product == null) return ResultDto.DefaultError(ResultState.GlobalParameterError);


            var winer = ProductGameWinnerBll.GetWiners(new List<string>{gameNo}).FirstOrDefault();
            var members = GameMemberBll.GetMembers(gameNo, game.State == 1, 0, 20);
            var showCnt = ProductCacheMgr.GetShowCnt(game.Pid);


            return ResultDto.DefaultSuccess(game.ToDetail(product, winer, showCnt, members));
        }
        #endregion

        #region 成员列表

        /// <summary>
        /// 成员列表
        /// </summary>
        /// <param name="gameNo"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public static ResultDto GetMembers(string gameNo,int skip, int take)
        {
            return ResultDto.DefaultSuccess(GameMemberBll.GetMembers(gameNo,false,skip, take));
        }

        #endregion

        #region 晒单

        public static ResultDto GetGameShow(string gameNo, int skip, int take)
        {
            var game = ProductGameDal.GetByPriKey(gameNo);
            if (game == null) return ResultDto.DefaultError(ResultState.GlobalParameterError);

            var product = ProductInfoDal.GetByPriKey(game.Pid);
            if (product == null) return ResultDto.DefaultError(ResultState.GlobalParameterError);


            var shows = GameShowDal.GetByGameNoPage(gameNo, skip, take);
            var users = UserBll.GetUsers(shows.Select(x => x.UId).ToList());

            return ResultDto.DefaultSuccess(shows.ToDto(users, product));
        }

        public static ResultDto GetGameShow(int skip, int take)
        { 
            var shows = GameShowDal.GetByPage(skip, take);
            var users = UserBll.GetUsers(shows.Select(x => x.UId).ToList());
            var products = ProductInfoDal.Gets(shows.Select(x => x.PId).ToList());

            return ResultDto.DefaultSuccess(shows.ToDto(users, products));
        }

        public static ResultDto GetUserGameShow(string userId,int skip, int take)
        {
            var shows = GameShowDal.GetByPage(skip, take);
            var users = UserBll.GetUsers(shows.Select(x => x.UId).ToList());
            var products = ProductInfoDal.Gets(shows.Select(x => x.PId).ToList());

            return ResultDto.DefaultSuccess(shows.ToDto(users, products));
        }
        #endregion 

        #region 等待揭晓

        /// <summary>
        /// 获取等待揭晓列表
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public static ResultDto WaitForCompute(int skip,int take)
        {
            return ResultDto.DefaultSuccess(ProductInfoDal.GetByState(GameState.WaitForCompute, skip, take));
        }

        #endregion

        #region 公示中

        /// <summary>
        /// 获取公示中列表
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public static ResultDto Publicity(int skip, int take)
        {
            return ResultDto.DefaultSuccess(ProductInfoDal.GetByState(GameState.Publicity, skip, take));
        }

        #endregion

        #region 个人夺宝记录

        /// <summary>
        /// 进行中(或 等待揭晓)
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public static ResultDto GameLogOfOnGoin(string userId,int skip,int take)
        {
            return ResultDto.DefaultSuccess(ProductInfoDal.GetByJoin(userId, skip, take));
        }


        /// <summary>
        /// 已揭晓(公示)
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public static ResultDto GameLogOfPublicity(string userId, int skip, int take)
        {
            var datas = ProductInfoDal.GetLogByState(userId, GameState.Publicity, skip, take);
            var winers = ProductGameWinnerBll.GetWiners(datas.Select(x => x.GameNo).ToList());

            return ResultDto.DefaultSuccess(datas.ToWaitDto(winers));
        }

         

        /// <summary>
        /// 已中奖
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public static ResultDto GameLogOfWin(string userId, int skip, int take)
        {
            var datas = ProductInfoDal.GetLogWin(userId, skip, take);
            var winers = ProductGameWinnerBll.GetWiners(datas.Select(x => x.GameNo).ToList());
            var express = GameExpresDal.GetByGameNos(winers.Select(x => x.GameNo).ToList());

            return ResultDto.DefaultSuccess(datas.ToWinDto(winers, express));
        }
        #endregion 

        #region 实时参与数据统计

        public static ResultDto GetCurJoinStat(List<string> gameNos)
        {
            return ResultDto.DefaultSuccess(ProductCacheMgr.GetJoinCnt(gameNos));
        }

        #endregion

        #region private

        internal static bool Buy(MySqlConnection conn, OrdersSuccesDb order)
        {
            var game = ProductGameDal.GetByPriKey(order.ParkCode);
             var isCommit = false;
            var left = game.TotalMoney - game.UserCnt;

            try
            {
                var gameNo = order.ParkCode;
                var productId = order.CarNo;
                var ipaddress = order.OpenId;

                if (game.State != (int)GameState.Going)
                {
                    var curGame = ProductInfoDal.GetInGameOfProduct(productId);
                    gameNo = curGame.GameNo;
                }

                var curCanBuyAmount = Math.Min((int)order.TotalMoney, game.TotalMoney - game.UserCnt);
                if (curCanBuyAmount > 0)
                {
                    var startNo = game.UserCnt;
                    var endNo = game.UserCnt + curCanBuyAmount - 1;

                    //记录购买，更新统计
                    GameMemberBll.Save(conn, gameNo, order.OrderNo, order.UserID, ipaddress, curCanBuyAmount, startNo, endNo);
                    //更新游戏
                    SaveProductGame(conn, gameNo, curCanBuyAmount);
                }

                //自动开启下期
                ProductGameDb nextGame=null;
                if (left <= order.TotalMoney)
                {
                    nextGame = BeginNextGame(conn, productId, gameNo);
                    gameNo = nextGame.GameNo;
                }

                var nextAmount = (int)order.TotalMoney - curCanBuyAmount;
                //计入下期
                if (nextAmount > 0 && nextGame!=null)
                {
                    var startNo = nextGame.UserCnt;
                    var endNo = nextGame.UserCnt + nextAmount - 1;

                    //购买
                    GameMemberBll.Save(conn, gameNo, order.OrderNo, order.UserID, ipaddress, curCanBuyAmount,startNo, endNo);
                }

                isCommit = true;
            }
            catch (Exception ex)
            {
                LogHelper.Add("购买任务",ex);
                isCommit = false;
            }

            return isCommit;
        }

        private static void SaveProductGame(MySqlConnection conn,string gameNo, int amount)
        {
            if (! ProductGameDal.AddUserCnt(conn, gameNo, amount))
            {
                throw  new Exception("更新游戏人数失败");
            }
        }

        private static ProductGameDb BeginNextGame(MySqlConnection conn, string productId,string gameNo)
        {
            //结束当前
            if (!ProductGameDal.UpdateToWaitCompute(conn, gameNo,DateTime.Now))
            {
                throw new Exception("更新游戏人数失败");
            }

            //新增
            var product = ProductInfoDal.GetByPriKey(productId);
            var newGame = new ProductGameDb
                {
                    GameNo = GenericGameNo(product),
                    Pid = productId,
                    EndTime = DateTime.MinValue,
                    RowTime = DateTime.Now,
                    State = (int) GameState.Going,
                    TotalMoney = product.OrderMoney,
                    UserCnt = product.OrderMoney
                };

            FillGameStock(newGame);

            if (! ProductGameDal.Insert(conn, newGame))
            {
                throw new Exception("更新游戏人数失败");
            }

            return newGame;
        }

        private static void FillGameStock(ProductGameDb newGame)
        {
            throw new NotImplementedException();
        }

        private static string GenericGameNo(ProductInfoDb product)
        {
            return string.Format("{0}{1}", product.PreGameNo, DateTime.Now.ToString("yyMMddHHMM"));
        } 
         
        #endregion
    }
}
