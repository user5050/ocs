using System.Globalization;

namespace OneCoin.Payment.Plugins.BestPay.Core
{
    public class PayRefundDto
    {
        /// <summary>
        /// 商户代码	n	20	M	由翼支付网关平台统一分配给各接入商户
        /// </summary>
        public string merchantId { get; set; }

        /// <summary>
        /// 商户子代码	ans	20	O	商户子代码如没有则填空
        /// </summary>
        public string subMerchantId { get; set; }

        /// <summary>
        /// 商户调用密码	an	20	M	商户执行时需填入相应密码
        /// </summary>
        public string merchantPwd { get; set; }

        /// <summary>
        /// 原扣款订单号	an	30	M	原扣款成功的订单号
        /// </summary>
        public string oldOrderNo { get; set; }

        /// <summary>
        /// 原订单请求支付流水号	an	30	M	原扣款成功的请求支付流水号
        /// </summary>
        public string oldOrderReqNo { get; set; }

        /// <summary>
        /// 退款流水号	an	30	M	该流水在商户处必须是唯一的，而且每次发起退款时，都必须是唯一的
        /// </summary>
        public string refundReqNo { get; set; }

        /// <summary>
        /// 退款请求日期	n	14	M	yyyyMMDD
        /// </summary>
        public string refundReqDate { get; set; }

        /// <summary>
        /// 退款交易金额	n	12	M	单位为分，小于等于原订单金额
        /// </summary>
        public string transAmt { get; set; }

        /// <summary>
        /// 分账明细	n	1024	O	分账示例：0018888888:10|3100888888:10分账规则：父商户可以全额退款，子商户的分账退款金额必须小于支付分账金额，分账金额不能为0。
        /// </summary>
        public string ledgerDetail { get; set; }

        /// <summary>
        /// 渠道	n	5	M	01：WEB//02：WAP04：语音05：客户端\H5
        /// </summary>
        public string channel { get; set; }

        /// <summary>
        /// Mac校验域	an	32	M	md5摘要
        /// </summary>
        public string mac { get; set; }


        /// <summary>
        /// 生成签名源字符串
        /// </summary>
        /// <param name="signKey"></param>
        /// <param name="payKey"></param>
        /// <returns></returns>
        internal string GenricSource(string signKey,string payKey)
        {
            return string.Format("MERCHANTID={0}&MERCHANTPWD={1}&OLDORDERNO={2}&OLDORDERREQNO={3}&REFUNDREQNO={4}&REFUNDREQDATE={5}&TRANSAMT={6}&LEDGERDETAIL={7}&KEY={8}",
                                merchantId, merchantPwd,oldOrderNo, oldOrderReqNo, refundReqNo,refundReqDate,transAmt,ledgerDetail, signKey);
        }

        internal string PostString()
        {
            return string.Format("oldOrderReqNo={0}&oldOrderNo={1}&mac={2}&merchantId={3}&transAmt={4}&channel={5}&refundReqNo={6}&refundReqDate={7}&merchantPwd={8}&subMerchantId={9}&ledgerDetail={10}"
                 ,oldOrderReqNo,oldOrderNo, mac.ToUpper(CultureInfo.CurrentCulture),merchantId,transAmt,channel,refundReqNo,refundReqDate,merchantPwd,subMerchantId,ledgerDetail);
        }
    }
}
