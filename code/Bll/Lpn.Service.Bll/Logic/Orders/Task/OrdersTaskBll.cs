using System;
using System.Linq;
using System.Text;
using System.Threading;
using OneCoin.Service.Bll.Core;
using OneCoin.Service.Bll.Logic.Orders.Task.OrderPreProccess;
using OneCoin.Service.Bll.Logic.Orders.Task.OrderProccess;
using OneCoin.Service.Helper.Log;
using OneCoin.Service.Model.Db.Orders;

namespace OneCoin.Service.Bll.Logic.Orders.Task
{
    public class OrdersTaskBll : BllBase
    {
        private static Thread _workThread = null;
        private static Thread _clearThread = null;
        private static Thread _monitorThread = null;
        private static DateTime _workThreadlastRunTime = DateTime.Now;
        private static DateTime _clearThreadlastRunTime = DateTime.Now;
        private const int OrderNumPerTime = 20;

        /// <summary>
        /// 开启任务
        /// </summary>
        public static void Start()
        {
            if (_workThread == null)
            {
                _workThread = new Thread(Run) { IsBackground = true };
                _workThread.Start();
            }

            if (_clearThread == null)
            {
                _clearThread = new Thread(RunClear) { IsBackground = true };
                _clearThread.Start();
            }


            if (_monitorThread == null)
            {
                _monitorThread = new Thread(MonitorTask) { IsBackground = true };
                _monitorThread.Start();
            }
            
        }

        private static void MonitorTask(object obj)
        {
            while (true)
            {
                try
                {
                    AppMonitorLog("执行预支付订单清理工作", _clearThread,_clearThreadlastRunTime);
                    AppMonitorLog("执行回调成功的订单任务", _workThread,_workThreadlastRunTime);
                }
                catch (Exception ex)
                {
                     LogHelper.Add("订单任务监控异常",ex);
                }
                
                Thread.Sleep(300000);
            }
        }

        private static void AppMonitorLog(string desc, Thread tread,DateTime lastTime)
        {
            var sb = new StringBuilder(desc);
            if (tread == null)
            {
                sb.AppendLine("线程未初始化");
            }
            else
            {
                sb.AppendLine("");
                sb.AppendLine("IsAlive:" + tread.IsAlive);
                sb.AppendLine("IsBackground:" + tread.IsBackground);
                sb.AppendLine("IsThreadPoolThread:" + tread.IsThreadPoolThread);
                sb.AppendLine("ThreadState:" + tread.ThreadState);
                sb.AppendLine("LastTime:" + lastTime); 
            }

            LogHelper.Add(sb.ToString());
        }

        /// <summary>
        /// 执行预支付订单清理工作
        /// </summary>
        /// <param name="obj"></param>
        private static void RunClear(object obj)
        {
            // 十分钟之前的未确认订单,最近的订单优先处理
            var endTime = DateTime.Now.Subtract(TimeSpan.FromMinutes(1));

            while (true)
            { 
                try
                {
                    // 获取未处理的订单
                    var datas = OrdersPreBll.GetUnConfirmOrders(OrderNumPerTime, endTime);

                    if (datas.Count > 0)
                    {
                        endTime = datas.Min(p => p.OrderTime);

                        var tasks = datas.Select(local => new System.Threading.Tasks.Task(() => OrderPreProccessBll.Proccess(local)))
                            .ToList();

                        tasks.ForEach(p => p.Start());

                        System.Threading.Tasks.Task.WaitAll(tasks.ToArray()); 
                    }
                    else
                    {
                        Thread.Sleep(TimeSpan.FromMinutes(1));

                        // 休眠1分钟,从头开始
                        endTime = DateTime.Now.Subtract(TimeSpan.FromMinutes(1));
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Add("执行预支付订单清理工作", ex);
                }

                Thread.Sleep(TimeSpan.FromSeconds(1));
                _clearThreadlastRunTime = DateTime.Now;
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
                    // 获取未处理的订单
                    var datas = OrdersSuccesBll.GetUnProccessOrders(OrderNumPerTime);
                    var tasks = datas.Select(local => new System.Threading.Tasks.Task(() => OrderProccessBll.Proccess(local))).ToList();

                    tasks.ForEach(p => p.Start());

                    System.Threading.Tasks.Task.WaitAll(tasks.ToArray());

                    // 根据未处理的订单数量 休眠不同时间
                    if (tasks.Count < OrderNumPerTime)
                        Thread.Sleep(5000);
                }
                catch (Exception ex)
                {
                    LogHelper.Add("执行任务订单任务异常", ex);
                }

                // 标准停留3秒
                Thread.Sleep(3000);
                _workThreadlastRunTime = DateTime.Now;
            }
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
