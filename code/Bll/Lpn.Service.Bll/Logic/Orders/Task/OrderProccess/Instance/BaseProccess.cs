using System;
using System.Collections.Generic;
using OneCoin.Service.Model.Enum.Payment;

namespace OneCoin.Service.Bll.Logic.Orders.Task.OrderProccess.Instance
{
    public class BaseProccess
    {
        private class ProccessLog
        {
            /// <summary>
            /// 执行次数
            /// </summary>
            public int TotalCnt { get; set; }

            /// <summary>
            /// 执行时间
            /// </summary>
            public DateTime ProccessTime { get; set; }


            /// <summary>
            /// 执行时间
            /// </summary>
            public PaymentPurpose Purpose { get; set; }

            /// <summary>
            /// 订单时间
            /// </summary>
            public DateTime OrderTime { get; set; }
        }


       private static  Dictionary<string,ProccessLog>  _logs = new Dictionary<string, ProccessLog>();


       protected static void AddFault(string orderNo, DateTime orderTime, PaymentPurpose purpose)
       {
           lock (_logs)
           {
               if (_logs.ContainsKey(orderNo))
               {
                   var log = _logs[orderNo];

                   log.TotalCnt++;
                   log.ProccessTime = ComputeNextRunTime(log);
               }
               else
               {
                   var log = new ProccessLog
                       {
                           OrderTime = orderTime,
                           TotalCnt = 1,
                           Purpose = purpose,
                       };

                   log.ProccessTime = ComputeNextRunTime(log);
                   _logs[orderNo] = log;
               }
           }
       }


       protected static void NotifySuccess(string orderNo)
       {
           lock (_logs)
           {
               if (_logs.ContainsKey(orderNo))
               {
                   _logs.Remove(orderNo);
               }
           }
       }

       protected static bool IsAllProccess(string orderNo)
        {
            if (!_logs.ContainsKey(orderNo)) return true;

            lock (_logs)
            {
                if (_logs.ContainsKey(orderNo))
                {
                    return DateTime.Now >= _logs[orderNo].ProccessTime;
                }
            }

            return true;
        }


       private static DateTime ComputeNextRunTime(ProccessLog log)
       { 
           // 15分钟前的订单
           if (log.OrderTime.AddMinutes(15) < DateTime.Now)
           {
               // 最长5分钟一次
               log.ProccessTime = DateTime.Now.AddMinutes(Math.Min(5, log.TotalCnt));
           }


           // 15分钟内的订单   5,10,15,20,25,30,35,40...递增

           return DateTime.Now.AddSeconds(5 * log.TotalCnt);
       }


       /// <summary>
       /// 订单是否已过期，过期处理需要撤单
       /// </summary>
       /// <param name="dateTime"></param>
       /// <returns></returns>
       public static bool IsExpired(DateTime dateTime)
       {
           return DateTime.Now.Subtract(dateTime).TotalMinutes > 10;

       }
    }
}
