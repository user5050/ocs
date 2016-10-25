namespace OneCoin.Payment.Plugins.BestPay.Core.Res
{  

    public class result
    {
        /// <summary>
        /// 查询接口返回码	an20	M	查询接口状态：0：成功查询到数据1：未找到记录9：MAC错误或系统忙，请稍后再试
        /// </summary>
        public string RETURNCODE { get; set; }

        /// <summary>
        /// 商户代码	n20	M	由支付平台统一分配给各接入商户
        /// </summary>
        public string COMMCODE { get; set; }

        /// <summary>
        /// 订单号	an30	M	用于标识一个唯一的订单
        /// </summary>
        public string ORDERSEQ { get; set; }

        /// <summary>
        /// 订单支付请求的交易流水号	an30	M	订单支付请求的交易流水号
        /// </summary>
        public string ORDERREQTRANSEQ { get; set; }

        /// <summary>
        /// 订单状态	an30	M	订单状态：A:交易请求B:交易成功C:交易失败
        /// </summary>
        public string TRANSTATUS { get; set; }

        /// <summary>
        /// 订单金额	n10	M	订单交易金额，单位为分
        /// </summary>
        public string ORDERAMOUNT { get; set; }

        /// <summary>
        /// 验证摘要信息	an256	M	使用标准md5算法进行摘要
        /// </summary>
        public string SIGN { get; set; }

        /// <summary>
        /// 翼支付网关平台流水号	n30	M	由支付平台提供，商户必须保存该信息，作为对帐依据
        /// </summary>
        public string OURTRANSNO { get; set; }

    }
}
