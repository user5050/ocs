using System.Globalization;

namespace OneCoin.Payment.Plugins.BestPay.Core
{
    public class PayQueryDto
    {
        /// <summary>
        /// 商户代码  	n20	M	由翼支付网关平台统一分配给各接入商户
        /// </summary>
        public string COMMCODE { get; set; }

        /// <summary>
        /// 订单号	an30	M	用于标识一个唯一的订单
        /// </summary>
        public string ORDERSEQ { get; set; }

        /// <summary>
        /// 订单请求交易流水号	an30	M	订单支付请求的交易流水号
        /// </summary>
        public string ORDERREQTRANSEQ { get; set; }

        /// <summary>
        /// 验证摘要信息	a255	M	使用标准md5算法进行摘要
        /// </summary>
        public string MAC { get; set; }


        /// <summary>
        /// 生成签名源字符串
        /// </summary>
        /// <param name="signKey"></param>
        /// <returns></returns>
        internal string GenricSource(string signKey)
        {
            return string.Format("COMMCODE={0}&ORDERSEQ={1}&ORDERREQTRANSEQ={2}&KEY={3}",
                                this.COMMCODE, ORDERSEQ, this.ORDERREQTRANSEQ,  signKey);
        } 

        internal string PostString()
        {
            return string.Format("COMMCODE={0}&ORDERSEQ={1}&ORDERREQTRANSEQ={2}&MAC={3}", COMMCODE, ORDERSEQ,
                                     ORDERREQTRANSEQ, MAC.ToUpper(CultureInfo.CurrentCulture));
        }
    }
}
