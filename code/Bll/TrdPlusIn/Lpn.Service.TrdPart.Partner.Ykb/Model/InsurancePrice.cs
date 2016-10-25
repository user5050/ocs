using System.Text.RegularExpressions;

namespace Lpn.Service.TrdPart.Partner.Ykb.Model
{
    /*
     *  {
            "carno":"川A12345"//车牌
            "amount": "8106.00",// 保单价
            "payAmount": "6740.00",//支付价
            "url": "http://t.cn/Rt4YYEX"//详情地址
        } 
     */

    public class InsurancePrice
    { 
        /// <summary>
        /// 车牌
        /// </summary>
        public string CarNo { get; set; }

        /// <summary>
        /// 报单价
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// 支付价
        /// </summary>
        public string PayAmount { get; set; }

        /// <summary>
        /// 详情地址
        /// </summary>
        public string Url { get; set; }


        public bool IsValid()
        {
            return   !string.IsNullOrEmpty(CarNo)
                   && !string.IsNullOrEmpty(PayAmount)
                   && !string.IsNullOrEmpty(Amount)
                   && new Regex(@"^[0-9\.]+$").IsMatch(PayAmount)
                   && new Regex(@"^[0-9\.]+$").IsMatch(Amount)
                   && new Regex(@"(.*){5,10}$").IsMatch(CarNo)
                   ;
        }
    }
}
