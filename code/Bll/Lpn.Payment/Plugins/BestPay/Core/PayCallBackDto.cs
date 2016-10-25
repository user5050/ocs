using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace OneCoin.Payment.Plugins.BestPay.Core
{
    public class PayCallBackDto
    {
        /// <summary>
        /// 翼支付网关平台交易流水号	n30	M	由翼支付网关平台提供，商户必须保存该信息，作为对帐依据
        /// </summary>
        public string UPTRANSEQ { get; set; }

        /// <summary>
        /// 翼支付网关平台交易日期	n8	M	由翼支付网关平台提供，商户必须保存该信息，格式：yyyyMMDD, 商户对账、清算报表以此日期为准
        /// </summary>
        public string TRANDATE { get; set; }

        /// <summary>
        /// 处理结果码	n4	M	由翼支付网关平台统一定义，商户需保存，作为对帐数据。结果码为“0000” 表示支付成功，其他值则表示支付失败
        /// </summary>
        public string RETNCODE { get; set; }

        /// <summary>
        /// 处理结果解释码	Ans256	M	由翼支付网关平台统一定义，对支付结果的说明码
        /// </summary>
        public string RETNINFO { get; set; }

        /// <summary>
        /// 订单请求交易流水号	an32	M	从商户发送的订单的信息中获得，翼支付网关平台原值传回
        /// </summary>
        public string ORDERREQTRANSEQ { get; set; }

        /// <summary>
        /// 订单号	an32	M	从商户发送的订单的信息中获得，翼支付网关平台原值传回
        /// </summary>
        public string ORDERSEQ { get; set; }

        /// <summary>
        /// 订单总金额	n10	M	从商户发送的订单的信息中获得，翼支付网关平台原值传回，单位：分订单总金额 = 产品金额+附加金额
        /// </summary>
        public string ORDERAMOUNT { get; set; }

        /// <summary>
        /// 产品金额	n10	M	从商户发送的订单的信息中获得，翼支付网关平台原值传回，单位：分
        /// </summary>
        public string PRODUCTAMOUNT { get; set; }

        /// <summary>
        /// 附加金额	n10	M	从商户发送的订单的信息中获得，翼支付网关平台原值传回，单位：分
        /// </summary>
        public string ATTACHAMOUNT { get; set; }

        /// <summary>
        /// 币种	a10	M	默认填 RMB
        /// </summary>
        public string CURTYPE { get; set; }

        /// <summary>
        /// 加密方式	n1	M	0：不加密1：MD5摘要(默认)
        /// </summary>
        public string ENCODETYPE { get; set; }

        /// <summary>
        /// 银行编码	Ans64	M	支付使用的银行编码
        /// </summary>
        public string BANKID { get; set; }

        /// <summary>
        /// 商户附加信息	Ans128	O	从商户发送的订单的信息中获得，翼支付网关平台原值传回
        /// </summary>
        public string ATTACH { get; set; }

        /// <summary>
        /// 网关平台请求银行流水号	ans32	C	从商户发送的订单的信息中获得，翼支付网关平台原值传回
        /// </summary>
        public string UPREQTRANSEQ { get; set; }

        /// <summary>
        /// 银行流水号	ans32	O	银行流水号
        /// </summary>
        public string UPBANKTRANSEQ { get; set; }

        /// <summary>
        /// 产品号码	ans32	O	如充值会返回充值的号码。
        /// </summary>
        public string PRODUCTNO { get; set; }

        /// <summary>
        /// 数字签名	an256	M	数字签名算法由翼支付网关平台统一提供，作为核查依据（为1时有效）
        /// </summary>
        public string SIGN { get; set; }


        public static PayCallBackDto Parse(IDictionary<string,string> data)
        {
            return new PayCallBackDto
                {
                    UPTRANSEQ = GetValue(data, "UPTRANSEQ"),
                    TRANDATE = GetValue(data, "TRANDATE"),
                    RETNCODE = GetValue(data, "RETNCODE"),
                    RETNINFO = GetValue(data, "RETNINFO"),
                    ORDERREQTRANSEQ = GetValue(data, "ORDERREQTRANSEQ"),
                    ORDERSEQ = GetValue(data, "ORDERSEQ"),
                    ORDERAMOUNT = GetValue(data, "ORDERAMOUNT"),
                    PRODUCTAMOUNT = GetValue(data, "PRODUCTAMOUNT"),
                    ATTACHAMOUNT = GetValue(data, "ATTACHAMOUNT"),
                    CURTYPE = GetValue(data, "CURTYPE"),
                    ENCODETYPE = GetValue(data, "ENCODETYPE"),
                    BANKID = GetValue(data, "BANKID"),
                    ATTACH = GetValue(data, "ATTACH"),
                    UPREQTRANSEQ = GetValue(data, "UPREQTRANSEQ"),
                    UPBANKTRANSEQ = GetValue(data, "UPBANKTRANSEQ"),
                    PRODUCTNO = GetValue(data, "PRODUCTNO"),
                    SIGN = GetValue(data, "SIGN")
                };
        }


        private static string GetValue(IDictionary<string, string> data, string key)
        {
            string value;
            if (data.TryGetValue(key, out value)) return value;

            var findKey = data.Keys.FirstOrDefault(x => x.ToLower(CultureInfo.CurrentCulture) == key.ToLower());

            if (!string.IsNullOrEmpty(findKey)) return data[key];

            return string.Empty;
        }


        /// <summary>
        /// 生成签名源字符串
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="signKey"></param>
        /// <returns></returns>
        internal string GenricSource(string merchantId, string signKey)
        {
            return string.Format("UPTRANSEQ={0}&MERCHANTID={1}&ORDERSEQ={2}&ORDERAMOUNT={3}&RETNCODE={4}&RETNINFO={5}&TRANDATE={6}&KEY={7}"
                , this.UPTRANSEQ, merchantId, this.ORDERSEQ, ORDERAMOUNT, this.RETNCODE, this.RETNINFO, this.TRANDATE, signKey);

        } 
    }
}
