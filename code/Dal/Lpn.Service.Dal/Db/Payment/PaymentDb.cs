using System;

/*
* 由自动生成工具完成
* 描述:[payment_]支付信息
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Payment
{
    /// <summary>
    /// [payment_]支付信息
    /// </summary>
    [Serializable]
    public partial class PaymentDb
    {
        #region 支付编号
        private int _fID;

        /// <summary>
        /// 支付编号
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

        #region 用户编号
        private int _fUserID;

        /// <summary>
        /// 用户编号
        /// </summary>
        public  int  UserID
        {
            get
            {
                return  _fUserID;
            }
            set
            {
                  _fUserID = value;
            }
         }
        #endregion

        #region 支付金额
        private string _fPayment;

        /// <summary>
        /// 支付金额
        /// </summary>
        public  string  Payment
        {
            get
            {
                return  _fPayment;
            }
            set
            {
                  _fPayment = value;
            }
         }
        #endregion

        #region 支付帐号
        private string _fPayAccount;

        /// <summary>
        /// 支付帐号
        /// </summary>
        public  string  PayAccount
        {
            get
            {
                return  _fPayAccount;
            }
            set
            {
                  _fPayAccount = value;
            }
         }
        #endregion

     }
}

