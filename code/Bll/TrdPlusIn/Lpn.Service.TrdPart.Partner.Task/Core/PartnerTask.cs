using System;
using System.Collections.Generic;
using System.Threading;
using Lpn.Service.Helper.Log;
using Lpn.Service.TrdPart.Partner.Task.Park;

namespace Lpn.Service.TrdPart.Partner.Task.Core
{
    public class PartnerTask
    {
        private static readonly Dictionary<string, DateTime> LastUpdateTime = new Dictionary<string, DateTime>();
        private static readonly IList<ITask> Tasks = new List<ITask>();

        private static Thread _workThread; 

        static PartnerTask()
        {
            Tasks.Add(new ParkFeeTask());
        }

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
                    foreach (var task in Tasks)
                    {
                        var taskName = task.GetTaskId();

                        try
                        {
                            var intervalTime = task.GetRunInterval();

                            if (LastUpdateTime.ContainsKey(taskName))
                            {
                                if (DateTime.Now.Subtract(LastUpdateTime[taskName]).TotalMinutes < intervalTime)
                                {
                                    continue;
                                }
                            }

                            task.Run();
                        }
                        catch (Exception ex)
                        {
                            LogHelper.Add("单任务异常", ex);
                        }


                        LastUpdateTime[taskName] = DateTime.Now;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Add("执行任务订单任务异常", ex);
                }

                // 标准停留5分钟
                Thread.Sleep(300000); 
            }
        } 
    }
}
