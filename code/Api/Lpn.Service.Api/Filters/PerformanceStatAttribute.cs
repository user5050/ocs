using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web.Mvc;
using OneCoin.Service.Helper.Log;
using OneCoin.Service.Model.Entity.Performance;

namespace OneCoin.Service.Api.Filters
{
    public class PerformanceStatAttribute : ActionFilterAttribute
    {
        static PerformanceStatAttribute()
        {
            var logStat = new Thread(LogStat) {IsBackground = true};
            logStat.Start(); 
        }


        private static ConcurrentDictionary<string, PerformanceStat> _stat = new ConcurrentDictionary<string, PerformanceStat>();
         
        private DateTime _startTime;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _startTime = DateTime.Now;

            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // 首次请求不统计
            var actionName = string.Format("{0}.{1}", filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,filterContext.ActionDescriptor.ActionName);
            PerformanceStat curStat = null;
            if (!_stat.TryGetValue(actionName, out curStat))
            {
                curStat = new PerformanceStat {Method = actionName,RealCnt = 1};
                _stat[actionName] = curStat;
            }
            else
            {
                curStat.RealCnt++;
                if (curStat.RealCnt > 5)
                {
                    var runTime = DateTime.Now.Subtract(_startTime).TotalMilliseconds;

                    lock (curStat)
                    {
                        curStat.TotalRun += runTime;
                        curStat.MaxRun = Math.Max(runTime, curStat.MaxRun);
                        curStat.RealCnt++;
                    }
                } 
            }
            

            base.OnActionExecuted(filterContext);
        }
         
        private static void LogStat()
        {
            while (true)
            {
                try
                {
                    WriteLog();
                }
                catch (Exception ex)
                { 
                    LogHelper.Add("性能记录", ex);
                }
                

                Thread.Sleep(TimeSpan.FromHours(1));
            }
            
        }

        public static void WriteLog()
        {
            var sb = new StringBuilder();
            foreach (var stat in _stat.Values.Skip(0).Take(1000).OrderBy(p=>p.Method).ToList())
            {
                sb.AppendFormat("方法：{0},平均耗时:{1}ms,最大耗时:{2},访问次数:{3}", stat.Method, stat.TotalRun / stat.RealCnt, stat.MaxRun,
                                stat.RealCnt);
                sb.AppendLine();
             }

            _stat.Clear();

            if(sb.Length >0)
                LogHelper.Add(sb.ToString());
        }

    }
}