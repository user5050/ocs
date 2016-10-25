namespace OneCoin.Payment.Entity
{
    /// <summary>
    /// 支付宝支付所使用的特定参数
    /// </summary>
    public class AliPayRes
    {
        /// <summary>
        /// 商户PID
        /// </summary>
        public string partner
        {set;get;}

        /// <summary>
        /// 商户PID
        /// </summary>
        public string seller_id
        {set;get;}

        /// <summary>
        /// 支付成功后异步回调的路径
        /// </summary>
        public string notify_url
        {set;get;}

        /// <summary>
        /// 接口名称（此为固定值，不能为空）
        /// </summary>
        public string service
        {set;get;}

        /// <summary>
        /// 支付类型,默认值为：1(商品购买)
        /// </summary>
        public string payment_type
        {set;get;}

        /// <summary>
        /// 编码字符集
        /// </summary>
        public string _input_charset
        {set;get;}

        /// <summary>
        /// 未付款交易的超时时间
        /// </summary>
        public string it_b_pay
        {set;get;}

        /// <summary>
        /// 签名方式
        /// </summary>
        public string sign_type
        {set;get;}

        /// <summary>
        /// 加密数据的私钥（已用AES加密，需解密）
        /// </summary>
        public string privatekey
        { set; get; }

        /// <summary>
        /// 支付宝的公钥
        /// </summary>
        public string alipaypublickey
        { set; get; }
    }
}
