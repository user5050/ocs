namespace Lpn.Service.TrdPart.Partner.Core.Model
{
    public class CarEndDto 
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
        ///出场时间 
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        ///入场时间 
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        ///实收  
        /// </summary>
        public double PaymentMoney { get; set; }
        /// <summary>
        ///应收  
        /// </summary>
        public double TotalMoney { get; set; }
        /// <summary>
        ///抵扣 
        /// </summary>
        public double DeductionMoney { get; set; }
        /// <summary>
        ///支付方式 
        /// </summary>
        public int PayType { get; set; }
        /// <summary>
        ///停车场扣费流水号 
        /// </summary>
        public string Qn { get; set; }
    }
}
