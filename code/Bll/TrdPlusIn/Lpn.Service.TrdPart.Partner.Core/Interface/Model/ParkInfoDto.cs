namespace Lpn.Service.TrdPart.Partner.Core.Model
{
    public class ParkInfoDto
    {
        /// <summary>
        ///停车场编号 
        /// </summary>
        public string ParkCode { get; set; }

        /// <summary>
        /// 停车场名称
        /// </summary>
        public string ParkName { get; set; }

        /// <summary>
        /// 停车费率
        /// </summary>
        public string FeeRate { get; set; }

        /// <summary>
        /// 免费停车时间(分钟)
        /// </summary>
        public int FreeTime { get; set; }
        
    }
}
