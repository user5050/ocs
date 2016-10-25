namespace Lpn.Service.TrdPart.Partner.Core.Model
{
    public class CarStartDto 
    {
        /// <summary>
        ///停车场编号 
        /// </summary>
        public string ParkCode { get; set; }

        /// <summary>
        ///车牌号 
        /// </summary>
        public string VehicleNo { get; set; }
      
        /// <summary>
        ///入场时间 
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        ///图片
        /// </summary>
        public int ImageID { get; set; }
         
    }
}
