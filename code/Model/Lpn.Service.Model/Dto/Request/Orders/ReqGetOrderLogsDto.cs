namespace OneCoin.Service.Model.Dto.Request.Orders
{
    public class ReqGetOrderLogsDto : RequestBaseDto
    {
        /// <summary>
        /// 历史类型(已支付待处理订单=0，已处理完毕的订单=1, 已撤费的订单=2)
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 起始订单号
        /// </summary>
        public string StartOrderNo { get; set; }

        /// <summary>
        /// 返回数量
        /// </summary>
        public int Take { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }
    }
}
