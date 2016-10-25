using Newtonsoft.Json;

namespace OneCoin.Service.Model.Dto.Response.Orders
{
    public class ResOrderLogDto
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        [JsonProperty("orderno")]
        public string OrderNo { get; set; }

      
        /// <summary>
        /// 订单时间
        /// </summary>
        [JsonProperty("ordertime")]
        public string OrderTime{ set; get; }


        /// <summary>
        /// 停车时长
        /// </summary>
        [JsonProperty("parkingtime")]
        public int ParkingTime { set; get; }

        /// <summary>
        /// 入场时间
        /// </summary>
        [JsonProperty("entertime")]
        public string EnterTime { set; get; }

        /// <summary>
        /// 描述信息
        /// </summary>
        [JsonProperty("description")]
        public string Description { set; get; }

        /// <summary>
        /// 订单金额
        /// </summary>
        [JsonProperty("ordermoney")]
        public decimal OrderMoney { set; get; }

      
        /// <summary>
        /// 对应车牌
        /// </summary>
        [JsonProperty("carno")]
        public string CarNo{ set; get; }

        /// <summary>
        /// 0 成功  1 撤费
        /// </summary>
        [JsonProperty("status")]
        public int Status { set; get; }
      
        /// <summary>
        /// 支付类型
        /// </summary>
        [JsonProperty("paytype")]
        public int PayType{ set; get; }

        /// <summary>
        /// 是否入账
        /// </summary>
        [JsonProperty("isincome")]
        public int IsIncome { get; set; }

        /// <summary>
        /// 支付目的
        /// </summary>
        [JsonProperty("purpose")]
        public int Purpose { get; set; }

        /// <summary>
        /// 停车场名称
        /// </summary>
        [JsonProperty("parkname")]
        public string ParkName { get; set; }

        /// <summary>
        /// 充值的手机号
        /// </summary>
        [JsonProperty("rechargemobile")]
        public string RechargeMobile { get; set; }

        /// <summary>
        /// 扩展标记
        /// </summary>
        [JsonProperty("extre")]
        public int Extre { get; set; }

        /// <summary>
        /// 活动名称
        /// </summary>
        [JsonProperty("activityname")]
        public string ActivityName { get; set; }

        /// <summary>
        /// 月租到期时间
        /// </summary>
        [JsonProperty("monthtilldate")]
        public string MonthTillDate { get; set; }

        /// <summary>
        /// 月租购买数量
        /// </summary>
        [JsonProperty("monthamount")]
        public int MonthAmount { get; set; }


        /// <summary>
        /// vip到期时间
        /// </summary>
        [JsonProperty("viptilldate")]
        public string VipTillDate { get; set; }

        /// <summary>
        /// vip购买数量
        /// </summary>
        [JsonProperty("vipamount")]
        public int VipAmount { get; set; }

        /// <summary>
        /// 是否已使用(0未使用1使用)
        /// </summary>
        [JsonProperty("isused")]
        public int IsUsed { get; set; }

        /// <summary>
        /// 服务商名称
        /// </summary>
        [JsonProperty("spname")]
        public string SpName { get; set; }

        /// <summary>
        /// 服务商联系地址
        /// </summary>
        [JsonProperty("spaddr")]
        public string SpAddr { get; set; }

        /// <summary>
        /// 服务商联系方式
        /// </summary>
        [JsonProperty("spcontact")]
        public string SpContact { get; set; }
    }
}
