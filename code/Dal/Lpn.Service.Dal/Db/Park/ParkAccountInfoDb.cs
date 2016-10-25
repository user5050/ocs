using System;

/*
* 由自动生成工具完成
* 描述:[park_account_info]停车场结算信息
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Park
{
    /// <summary>
    /// [park_account_info]停车场结算信息
    /// </summary>
    [Serializable]
    public partial class ParkAccountInfoDb
    {
        #region 停车场编号
        private int _fParkID;

        /// <summary>
        /// 停车场编号
        /// </summary>
        public  int  ParkID
        {
            get
            {
                return  _fParkID;
            }
            set
            {
                  _fParkID = value;
            }
         }
        #endregion

        #region 帐户名
        private string _fAccountName;

        /// <summary>
        /// 帐户名
        /// </summary>
        public  string  AccountName
        {
            get
            {
                return  _fAccountName;
            }
            set
            {
                  _fAccountName = value;
            }
         }
        #endregion

        #region 帐号
        private string _fAccountNo;

        /// <summary>
        /// 帐号
        /// </summary>
        public  string  AccountNo
        {
            get
            {
                return  _fAccountNo;
            }
            set
            {
                  _fAccountNo = value;
            }
         }
        #endregion

        #region 开户行
        private string _fBankName;

        /// <summary>
        /// 开户行
        /// </summary>
        public  string  BankName
        {
            get
            {
                return  _fBankName;
            }
            set
            {
                  _fBankName = value;
            }
         }
        #endregion

        #region 结算方式
        private int _fSettlementType;

        /// <summary>
        /// 结算方式
        /// </summary>
        public  int  SettlementType
        {
            get
            {
                return  _fSettlementType;
            }
            set
            {
                  _fSettlementType = value;
            }
         }
        #endregion

        #region 结算周期
        private int _fSettlementInterval;

        /// <summary>
        /// 结算周期
        /// </summary>
        public  int  SettlementInterval
        {
            get
            {
                return  _fSettlementInterval;
            }
            set
            {
                  _fSettlementInterval = value;
            }
         }
        #endregion

        #region 联系人
        private string _fContactor;

        /// <summary>
        /// 联系人
        /// </summary>
        public  string  Contactor
        {
            get
            {
                return  _fContactor;
            }
            set
            {
                  _fContactor = value;
            }
         }
        #endregion

        #region 联系电话
        private string _fContactPhone;

        /// <summary>
        /// 联系电话
        /// </summary>
        public  string  ContactPhone
        {
            get
            {
                return  _fContactPhone;
            }
            set
            {
                  _fContactPhone = value;
            }
         }
        #endregion

        #region 操作人员编号
        private int _fOpreator;

        /// <summary>
        /// 操作人员编号
        /// </summary>
        public  int  Opreator
        {
            get
            {
                return  _fOpreator;
            }
            set
            {
                  _fOpreator = value;
            }
         }
        #endregion

     }
}

