
/*
 * 支付相关配置
 * 支付宝，银联支付 商户号，秘钥文件，MD5签名掩码等配置信息
 */

namespace OneCoin.Service.Model.Entity.Config
{
    public class PayConfig
    {
        /// <summary>
        /// 商户ID
        /// </summary>
        public string MchId { get; set; }

        /// <summary>
        /// RSA秘钥内容Base64格式
        /// </summary>
        public string Pfx { get; set; }

        /// <summary>
        /// RSA秘钥密码
        /// </summary>
        public string PfxPwd { get; set; }

        /// <summary>
        /// 平台RSA秘钥内容Base64格式(公钥)
        /// </summary>
        public string PlatformPublicCer { get; set; }

        /// <summary>
        /// 加密公钥
        /// </summary>
        public string EncrypCer { get; set; }

        /// <summary>
        /// MD5签名掩码
        /// </summary>
        public string Md5Key { get; set; }

        /// <summary>
        /// appid
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 子商户id
        /// </summary>
        public string SubMchId { get; set; }
    }
}
