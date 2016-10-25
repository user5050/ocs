using System;

namespace OneCoin.Service.Model.Entity.Payment.Activity
{
    public class ActivityPurchaseReq : PurchaseReq
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        public string Contract { get; set; }

        /// <summary>
        /// 车型
        /// </summary>
        public string CarType { get; set; }

        /// <summary>
        /// 车辆颜色
        /// </summary>
        public string CarColor { get; set; }

        /// <summary>
        /// 服务地址
        /// </summary>
        public string ServiceAddr { get; set; }

        /// <summary>
        /// 车位信息
        /// </summary>
        public string ParkingLot { get; set; }

        /// <summary>
        /// 支付描述(eg:购买了1个月洗车服务，支付了36元)
        /// </summary>
        public string PayDesc { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 所选日期
        /// </summary>
        public DateTime SelectedDate { get; set; }


        /// <summary>
        /// 服务提供者id
        /// </summary>
        public string SpId { get; set; }

        /// <summary>
        /// 原始价格
        /// </summary>
        public double SpPrice { get; set; }
        
    }
}
