namespace OneCoin.Service.Model.Entity.Payment
{
    public class PurchaseRes : PurchaseReq
    {
        /// <summary>
        /// 流水号
        /// </summary>
        public string Sn
        { get; set; }

        /// <summary>
        /// 存放额外的参数(目前APP所需向支付宝提交支付订单的参数就存储于此)
        /// </summary>
        public object ExtraParam
        { get; set; }

        public PurchaseRes()
        {
            Sn = "";
            ExtraParam = new object();
        }


        public override string ToString()
        {
            return string.Format("Result:{0};SN:{1};OrderNo:{2};OrderTime:{3};OrderMoney:{4};ParkCode:{5};EntranceTime:{6};ExitTime:{7};TillDate:{8};RenewalMonths:{9};CarNo:{10};ErrMsg:{11}",
                Result.ToString(),
                Sn,
                OrderNo,
                OrderTime,
                OrderMoney.ToString(),
                ParkCode,
                EntranceTime,
                ExitTime,
                TillDate,
                RenewalMonths,
                CarNo,
                ErrMsg
                );
        }
    }
}
