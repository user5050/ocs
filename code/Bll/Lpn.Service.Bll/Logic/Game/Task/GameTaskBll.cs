using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OneCoin.Service.Bll.Core;
using OneCoin.Service.Bll.Logic.Orders.Task.OrderProccess;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Dal.Dal.Game;
using OneCoin.Service.Dal.Dal.Product;
using OneCoin.Service.Helper.Log;
using OneCoin.Service.Model.Db.Game;
using OneCoin.Service.Model.Db.Orders;
using OneCoin.Service.Model.Db.Product;
using OneCoin.Service.Model.Enum.Product;
using StockTool;
using StockTool.Dto;

namespace OneCoin.Service.Bll.Logic.Game.Task
{
    public class GameTaskBll : BllBase
    {
        private static Thread _workThread = null;
        private static DateTime _nextComputeTime=DateTime.Now;
        private static DateTime _computeTime;

        /// <summary>
        /// 开启任务
        /// </summary>
        public static void Start()
        {
            _computeTime = GetComputeEndTime();
            _nextComputeTime = _computeTime.Date.AddHours(15).AddMinutes(5);


            if (_workThread == null)
            {
                _workThread = new Thread(Run) { IsBackground = true };
                _workThread.Start();
            }

        }

        /// <summary>
        /// 执行回调成功的订单任务
        /// </summary>
        /// <param name="obj"></param>
        private static void Run(object obj)
        {
            while (true)
            {
                try
                {
                    if (_nextComputeTime <= DateTime.Now)
                    {
                        _computeTime = GetComputeEndTime();

                        // 获取未处理的订单
                        var datas = ProductGameDal.GetWaitForCompute(_computeTime);
                        var stocks = datas.Select(x => x.StockNo1).ToList();
                        stocks.AddRange(datas.Select(x => x.StockNo2));
                        stocks.AddRange(datas.Select(x => x.StockNo3));
                        stocks.Add("sh000001");


                        int prcent;
                        var stockPrices = new StockHelper().Gets(stocks.Distinct().ToList(), out prcent);
                        var baseStock = stockPrices.FirstOrDefault(x => x.StockNo == "sh000001");

                        if (baseStock != null)
                        {
                            //根据未处理的订单数量
                            datas.ForEach(x => ComputeResult(x, baseStock, stockPrices));
                        }

                        if (datas.Count <= 0)
                        {
                            var nextTime = MakeNextComputeTime();

                            _nextComputeTime = nextTime.Date.AddHours(15).AddMinutes(5); 
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Add("执行任务订单任务异常", ex);
                }

                // 标准停留1分钟
                Thread.Sleep(60000);
            }
        }

        private static DateTime GetComputeEndTime()
        {
            var c = GameStockComputeTimeDal.GetAll().FirstOrDefault();
            if (c == null)
            {
                GameStockComputeTimeDal.Insert(new GameStockComputeTimeDb
                {
                    ComputeTime = DateTime.Now,
                    ComputeEndTime = DateTime.Now,
                    LastUpdateTime = DateTime.Now
                });

                return DateTime.Now;
            }

            return c.ComputeTime;
        }


        private static DateTime MakeNextComputeTime()
        {
            var today = DateTime.Now;
            while (true)
            {
                if (today.DayOfWeek == DayOfWeek.Sunday 
                    || today.DayOfWeek == DayOfWeek.Saturday
                    || GameStockComputeEldtimeDal.GetByPriKey(today.Date) != null)
                {
                    today = today.AddDays(1);
                    continue;
                }

                today= today.Date.AddHours(15).AddMinutes(-10);
                break;
            }

            var c = GameStockComputeTimeDal.GetAll().FirstOrDefault();
            c.ComputeTime = today;
            GameStockComputeTimeDal.UpdateByPriKey(c);

            return today;
        }

        private static bool ComputeResult(ProductGameDb pg, StockData baseStock, List<StockData> stockPrices)
        {
            if (pg.State == (int)GameState.WaitForCompute && pg.TotalMoney == pg.UserCnt)
            {
                try
                {
                    var p1 = stockPrices.FirstOrDefault(x => x.StockNo == pg.StockNo1);
                    var p2 = stockPrices.FirstOrDefault(x => x.StockNo == pg.StockNo2);
                    var p3 = stockPrices.FirstOrDefault(x => x.StockNo == pg.StockNo3);

                    if (p1 == null || p2 == null || p3 == null || p1.Value <= 0 || p2.Value <= 0 || p3.Value <= 0)
                    {
                        LogHelper.Add("参数不足:" + pg.GameNo);
                        return false;
                    }


                    var winNo = ComputeWinNo(baseStock, p1, p2, p3, pg.TotalMoney);
                    var winer = GameMemberBll.FindMember(pg.GameNo, winNo);


                    return Update(pg, winNo, winer, baseStock, p1, p2, p3);
                }
                catch (Exception ex)
                {
                    LogHelper.Add("计算错误:" + pg.GameNo, ex);
                }
            }

            return false;
        }


        private static bool Update(ProductGameDb pg, int winNo, GameMemberDb winer, StockData baseStock, StockData p1, StockData p2, StockData p3)
        {
            var conn = TransactionManager.GetCurrentConnection();
            var isCommit = false;
            try
            {
                var byStat = GameMemberStatDal.Get(pg.GameNo, winer.UId);

                if (ProductGameDal.UpdateState(conn, pg.GameNo, GameState.Publicity))
                {
                    if (GameComputeFactorDal.Insert(conn, new GameComputeFactorDb
                         {
                             GameNo = pg.GameNo,
                             Result = winNo,
                             SSEPrice = baseStock.Value,
                             StockNo1 = p1.StockNo,
                             StockPrice1 = p1.Value,
                             StockNo2 = p2.StockNo,
                             StockPrice2 = p2.Value,
                             StockNo3 = p3.StockNo,
                             StockPrice3 = p3.Value
                         }))
                    {
                        if (ProductGameWinnerDal.Insert(conn, new ProductGameWinnerDb
                            {
                                BuyAmount = byStat.BuyAmount,
                                GameNo = pg.GameNo,
                                Pid = pg.Pid,
                                RowTime = DateTime.Now,
                                Uid = winer.UId,
                                WinNo = winNo
                            }))
                        {
                            isCommit = true;
                        }
                    }
                }
            }
            finally
            {
                if (isCommit)
                {
                    TransactionManager.Commit();
                }
                else
                {
                    TransactionManager.Rollback();
                }
            }

            return isCommit;
        }

        private static int ComputeWinNo(StockData baseStock, StockData p1, StockData p2, StockData p3, int total)
        {
            return ((int)(p1.Value * p2.Value * p3.Value * 100000000 * baseStock.Value)) % total;
        }

        /// <summary>
        /// 立即执行订单处理
        /// </summary>
        /// <param name="order"></param>
        public static void RedirectProccessOrder(OrdersSuccesDb order)
        {
            if (order == null) return;

            var task = new System.Threading.Tasks.Task(() => OrderProccessBll.Proccess(order));
            task.Start();
        }
    }
}
