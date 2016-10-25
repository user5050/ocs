using System;

namespace OneCoin.Service.Model.Entity.Park
{
    public class ParkOnlineState
    {
        /// <summary>
        /// 停车场编号
        /// </summary>
        public string ParkCode { get; set; }

        /// <summary>
        /// 最近一次链接时间 
        /// </summary>
        public DateTime LastOnlineTime { get; set; }
    }
}
