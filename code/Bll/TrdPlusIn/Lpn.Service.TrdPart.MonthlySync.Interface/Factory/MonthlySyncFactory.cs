using System;
using System.Collections.Generic;
using Lpn.Service.TrdPart.MonthlySync.Interface.Core;

namespace Lpn.Service.TrdPart.MonthlySync.Interface.Factory
{
    public class MonthlySyncFactory
    {
        private static readonly Dictionary<string, IMonthlySyncUpload> Cache = new Dictionary<string, IMonthlySyncUpload>();

        /// <summary>
        /// 获取上报实例
        /// </summary>
        /// <param name="partnerId"></param>
        /// <param name="throwerror">抛出异常</param>
        /// <returns></returns>
        public static IMonthlySyncUpload GetInstance(string partnerId,bool throwerror=false)
        {
            if (Cache.ContainsKey(partnerId)) return Cache[partnerId];

            try
            {
                var instance = (IMonthlySyncUpload)System.Reflection.Assembly.Load(string.Format("Lpn.Service.TrdPart.MonthlySync.{0}", partnerId.ToUpper())).CreateInstance(string.Format("Lpn.Service.TrdPart.MonthlySync.{0}.Instance.Uploader", partnerId.ToUpper()), true);
                if (instance != null)
                {
                    Cache[partnerId] = instance;
                }

                return instance;
            }
            catch (Exception)
            {
                if (throwerror)
                    throw;
            }
             
            return null;
        }
    }
}
