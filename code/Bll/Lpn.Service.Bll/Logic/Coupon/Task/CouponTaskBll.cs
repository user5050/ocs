using System;
using System.Text;
using System.Threading;
using OneCoin.Service.Helper.Log;

namespace OneCoin.Service.Bll.Logic.Coupon.Task
{
    public class CouponTaskBll
    {
        private static Thread _workThread = null; 
        private static Thread _monitorThread = null;
        private static DateTime _workThreadlastRunTime = DateTime.Now;

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
                    AppMonitorLog("执行优惠券过期状态修改工作", _workThread, _workThreadlastRunTime);
                }
                catch (Exception ex)
                {
                    LogHelper.Add("执行优惠券过期状态修改工作异常", ex);
                }

                Thread.Sleep(300000);
            }
        }

        private static void AppMonitorLog(string desc, Thread tread, DateTime lastTime)
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
        /// 执行回调成功的订单任务
        /// </summary>
        /// <param name="obj"></param>
        private static void Run(object obj)
        {
            while (true)
            {
                try
                {
                    LogHelper.Add("更改过期的优惠券");

                    // 删除过期10天后的优惠券
                    CouponBll.RemoveLongExpiredCoupon();

                    // 更改过期的优惠券,每日凌晨
                     if (CouponBll.UpdateExpriedCoupon())
                     {
                         Thread.Sleep( (int)DateTime.Now.Date.AddDays(1).Subtract(DateTime.Now).TotalMilliseconds +  60000);
                     }
                }
                catch (Exception ex)
                {
                    LogHelper.Add("更改过期的优惠券异常", ex);
                }

                // 标准停留60秒
                Thread.Sleep(60000);
                _workThreadlastRunTime = DateTime.Now;
            }
        }
    }
}
