using System.Web;

namespace OneCoin.Payment.Plugins.BestPay.Core
{
    public class PayWebDto
    {
        /// <summary>
        /// 商户号	n30	M	由翼支付网关平台统一分配
        /// </summary>
        public string MERCHANTID { get; set; }

        /// <summary>
        /// 子商户号	ans30	O	由商户平台自己分配，在做支付时，可以一并发送过来，翼支付网关平台可以负责记录，如没有可以不填写
        /// </summary>
        public string SUBMERCHANTID { get; set; }

        /// <summary>
        /// 订单号	an30	M	由商户平台提供，数字或字母组成
        /// </summary>
        public string ORDERSEQ { get; set; }

        /// <summary>
        /// 订单请求交易流水号	an30	M	由商户平台提供，数字或字母组成
        /// </summary>
        public string ORDERREQTRANSEQ { get; set; }

        /// <summary>
        /// 订单日期	n14	M	由商户提供，长度8或14位yyyyMMdd格式yyyyMMddhhmmss
        /// </summary>
        public string ORDERDATE { get; set; }

        /// <summary>
        /// 订单总金额	n10	M	单位：分 比如1元，填写100订单总金额 = 产品金额+附加金额
        /// </summary>
        public string ORDERAMOUNT { get; set; }

        /// <summary>
        /// 产品金额	n10	M	单位：分 比如1元，填写100
        /// </summary>
        public string PRODUCTAMOUNT { get; set; }

        /// <summary>
        /// 附加金额	n10	M	单位：分 比如1元，填写100
        /// </summary>
        public string ATTACHAMOUNT { get; set; }

        /// <summary>
        /// 币种	a3	M	默认填 RMB
        /// </summary>
        public string CURTYPE { get; set; }

        /// <summary>
        /// 加密方式	n1	M	1：MD5摘要  默认
        /// </summary>
        public string ENCODETYPE { get; set; }

        /// <summary>
        /// 前台返回地址	ans255	M	商户提供的用于接收交易返回的前台url，不做业务处理，仅仅用于前台页面显示结果
        /// </summary>
        public string MERCHANTURL { get; set; }

        /// <summary>
        /// 后台返回地址	ans255	M	商户提供的用于接收交易返回的后台url，用于实际的业务处理
        /// </summary>
        public string BACKMERCHANTURL { get; set; }

        /// <summary>
        /// 附加信息	ans128	O	商户附加信息
        /// </summary>
        public string ATTACH { get; set; }

        /// <summary>
        /// 业务类型	n4	M	默认填0001
        /// </summary>
        public string BUSICODE { get; set; }

        /// <summary>
        /// 业务标识	n2	O	请参看业务填写说明
        /// </summary>
        public string PRODUCTID { get; set; }

        /// <summary>
        /// 终端号码	n40	O	请参看业务填写说明
        /// </summary>
        public string TMNUM { get; set; }

        /// <summary>
        /// 客户标识	ans32	O	请参看业务填写说明
        /// </summary>
        public string CUSTOMERID { get; set; }

        /// <summary>
        /// 产品描述	ans512	M	请参看业务填写说明，B2B类交易时，交易描述限制为8个中文，超过此限制可能导致交易失败
        /// </summary>
        public string PRODUCTDESC { get; set; }

        /// <summary>
        /// MAC校验域	an256	M	默认为0，当加密方式为1时有意义，采用标准的MD5算法，由商户实现
        /// </summary>
        public string MAC { get; set; }

        /// <summary>
        /// 分账明细	ns256	O	分账商户必填，格式参看 说明5：分账明细说明
        /// </summary>
        public string DIVDETAILS { get; set; }

        /// <summary>
        /// 分期数	n2	C	只有选择银行分期支付时，此项才为必填项，取值3,6,9,12,18,24。
        /// </summary>
        public string PEDCNT { get; set; }

        /// <summary>
        /// 订单关闭时间	ns19	O	超过此时间后订单不能支付，格式yyyy-MM-dd HH:mm:ss 
        /// </summary>
        public string GMTOVERTIME { get; set; }

        /// <summary>
        /// 商品付费类型	n3	O	1:预付费2:后付费0:不限（帐单支付时必填）
        /// </summary>
        public string GOODPAYTYPE { get; set; }

        /// <summary>
        /// 商品编码	ans15	O	商户侧产品的唯一标识，用于翼支付统计（帐单支付时必填）
        /// </summary>
        public string GOODSCODE { get; set; }

        /// <summary>
        /// 商品名称	ans20	M	商户侧产品名称，用于给用户发送订购短信时的展示（帐单支付时必填）
        /// </summary>
        public string GOODSNAME { get; set; }

        /// <summary>
        /// 商品数量	n10	O	用户购买的商户数量（帐单支付时必填）
        /// </summary>
        public string GOODSNUM { get; set; }

        /// <summary>
        /// 客户端IP	ns15	M	用户在访问商户网站时的IP，详情请参考接口说明7
        /// </summary>
        public string CLIENTIP { get; set; }

        /// <summary>
        /// 时间戳	ans256	M	商户调用时间戳生成接口返回的时间戳
        /// </summary>
        public string TIMESTAMP { get; set; }

        /// <summary>
        /// 生成签名源字符串
        /// </summary>
        /// <param name="signKey"></param>
        /// <returns></returns>
        internal string GenricSource(string signKey)
        {
            return string.Format("MERCHANTID={0}&ORDERSEQ={1}&ORDERDATE={2}&ORDERAMOUNT={3}&CLIENTIP={4}&KEY={5}",
                                MERCHANTID, ORDERSEQ, ORDERDATE, ORDERAMOUNT, CLIENTIP, signKey);
        } 
    }
}
