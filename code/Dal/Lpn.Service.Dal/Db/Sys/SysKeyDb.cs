using System;

/*
* 由自动生成工具完成
* 描述:[sys_key]密钥信息
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Sys
{
    /// <summary>
    /// [sys_key]密钥信息
    /// </summary>
    [Serializable]
    public partial class SysKeyDb
    {
        #region 密钥编号
        private int _fID;

        /// <summary>
        /// 密钥编号
        /// </summary>
        public  int  ID
        {
            get
            {
                return  _fID;
            }
            set
            {
                  _fID = value;
            }
         }
        #endregion

        #region 手机号
        private string _fUserName;

        /// <summary>
        /// 手机号
        /// </summary>
        public  string  UserName
        {
            get
            {
                return  _fUserName;
            }
            set
            {
                  _fUserName = value;
            }
         }
        #endregion

        #region 公钥
        private string _fPublicKey;

        /// <summary>
        /// 公钥
        /// </summary>
        public  string  PublicKey
        {
            get
            {
                return  _fPublicKey;
            }
            set
            {
                  _fPublicKey = value;
            }
         }
        #endregion

        #region 私钥
        private string _fPrivateKey;

        /// <summary>
        /// 私钥
        /// </summary>
        public  string  PrivateKey
        {
            get
            {
                return  _fPrivateKey;
            }
            set
            {
                  _fPrivateKey = value;
            }
         }
        #endregion

     }
}

