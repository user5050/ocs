using System;

namespace Lpn.Service.TrdPart.Partner.Ykb.Model.Request
{
    public class ReqGorderDto
    {
        /// <summary>
        ///车牌号
        /// </summary>
        public String carNo { get; set; }


        /// <summary>
        ///用户电话号码
        /// </summary>
        public String memberPhone { get; set; }


        /// <summary>
        ///用户经度，高德
        /// </summary>
        public Double longitude { get; set; }


        /// <summary>
        ///用户纬度，高德
        /// </summary>
        public Double latitude { get; set; }


        /// <summary>
        ///企业token
        /// </summary>
        public String compToken { get; set; }


        /// <summary>
        ///车场id
        /// </summary>
        public int carWashId { get; set; }


        /// <summary>
        ///车型    1.轿车2.suv
        /// </summary>
        public int carType { get; set; }


        /// <summary>
        ///车辆品牌
        /// </summary>
        public String brandName { get; set; }


        /// <summary>
        ///车系
        /// </summary>
        public String seriesName { get; set; }


        /// <summary>
        ///第三方订单号
        /// </summary>
        public String thirdTradeNo { get; set; }


        /// <summary>
        ///下单价
        /// </summary>
        public Double memberPrice { get; set; }


        /// <summary>
        ///服务类型0.洗车
        /// </summary>
        public int serviceType { get; set; }


        /// <summary>
        ///服务id
        /// </summary>
        public int serviceId { get; set; }


        /// <summary>
        ///预约服务时间
        /// </summary>
        public string serviceTime { get; set; }


        /// <summary>
        ///服务地址
        /// </summary>
        public string serviceAddr { get; set; }


        /// <summary>
        ///更多说明
        /// </summary>
        public string moreRequiry { get; set; } 
    }
}
