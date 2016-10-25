using System;

/*
* 由自动生成工具完成
* 描述:合作公司支付平台信息配置
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Model.Db.Partnerpay
{
    /// <summary>
    /// 合作公司支付平台信息配置
    /// </summary>
    [Serializable]
    public partial class PartnerpayPlatformconfigDb
    {
        #region 商户ID
        private string _fMchId;

        /// <summary>
        /// 商户ID
        /// </summary>
        public  string  MchId
        {
            get
            {
                return  _fMchId;
            }
            set
            {
                  _fMchId = value;
            }
         }
        #endregion

        #region 平台类型
        private int _fPlatfrom;

        /// <summary>
        /// 平台类型
        /// </summary>
        public  int  Platfrom
        {
            get
            {
                return  _fPlatfrom;
            }
            set
            {
                  _fPlatfrom = value;
            }
         }
        #endregion

        #region 微信appid
        private string _fAppId;

        /// <summary>
        /// 微信appid
        /// </summary>
        public  string  AppId
        {
            get
            {
                return  _fAppId;
            }
            set
            {
                  _fAppId = value;
            }
         }
        #endregion

        #region 合作商id
        private string _fPartnerId;

        /// <summary>
        /// 合作商id
        /// </summary>
        public  string  PartnerId
        {
            get
            {
                return  _fPartnerId;
            }
            set
            {
                  _fPartnerId = value;
            }
         }
        #endregion

        #region 签名证书
        private string _fSignCert;

        /// <summary>
        /// 签名证书
        /// </summary>
        public  string  SignCert
        {
            get
            {
                return  _fSignCert;
            }
            set
            {
                  _fSignCert = value;
            }
         }
        #endregion

        #region 签名秘钥密码
        private string _fSignCertPwd;

        /// <summary>
        /// 签名秘钥密码
        /// </summary>
        public  string  SignCertPwd
        {
            get
            {
                return  _fSignCertPwd;
            }
            set
            {
                  _fSignCertPwd = value;
            }
         }
        #endregion

        #region 签名Key(支付宝)
        private string _fSignKey;

        /// <summary>
        /// 签名Key(支付宝)
        /// </summary>
        public  string  SignKey
        {
            get
            {
                return  _fSignKey;
            }
            set
            {
                  _fSignKey = value;
            }
         }
        #endregion

        #region 加密公钥(银联)
        private string _fEncryptCert;

        /// <summary>
        /// 加密公钥(银联)
        /// </summary>
        public  string  EncryptCert
        {
            get
            {
                return  _fEncryptCert;
            }
            set
            {
                  _fEncryptCert = value;
            }
         }
        #endregion

        #region 平台公钥证书
        private string _fPlatfromPublicKey;

        /// <summary>
        /// 平台公钥证书
        /// </summary>
        public  string  PlatfromPublicKey
        {
            get
            {
                return  _fPlatfromPublicKey;
            }
            set
            {
                  _fPlatfromPublicKey = value;
            }
         }
        #endregion

        #region 扩展信息
        private string _fExtre;

        /// <summary>
        /// 扩展信息
        /// </summary>
        public  string  Extre
        {
            get
            {
                return  _fExtre;
            }
            set
            {
                  _fExtre = value;
            }
         }
        #endregion

        #region 子商户Id
        private string _fSubMchId;

        /// <summary>
        /// 子商户Id
        /// </summary>
        public  string  SubMchId
        {
            get
            {
                return  _fSubMchId;
            }
            set
            {
                  _fSubMchId = value;
            }
         }
        #endregion

     }
}

