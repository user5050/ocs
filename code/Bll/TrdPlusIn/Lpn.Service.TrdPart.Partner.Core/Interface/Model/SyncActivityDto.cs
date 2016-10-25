using System;

namespace Lpn.Service.TrdPart.Partner.Core.Interface.Model
{
    public class SyncActivityDto
    {
        /// <summary>
        ///合作商id
        /// </summary>
        public String PartnerId { get; set; }
         

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
        ///服务类型  Wash , tickets
        /// </summary>
        public string serviceType { get; set; }


        /// <summary>
        ///服务id
        /// </summary>
        public string serviceId { get; set; }


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



        /// <summary>
        /// 姓名
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        public string idcard { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Amount { get; set; }
         
    }
}
