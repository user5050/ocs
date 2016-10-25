using System;

/*
* 由自动生成工具完成
* 描述:[park_settlement_info]停车场结算表
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Park
{
    /// <summary>
    /// [park_settlement_info]停车场结算表
    /// </summary>
    [Serializable]
    public partial class ParkSettlementInfoDb
    {
        #region 停车场结算表编号
        private int _fSettlementID;

        /// <summary>
        /// 停车场结算表编号
        /// </summary>
        public  int  SettlementID
        {
            get
            {
                return  _fSettlementID;
            }
            set
            {
                  _fSettlementID = value;
            }
         }
        #endregion

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

        #region 年
        private int _fYear;

        /// <summary>
        /// 年
        /// </summary>
        public  int  Year
        {
            get
            {
                return  _fYear;
            }
            set
            {
                  _fYear = value;
            }
         }
        #endregion

        #region 月
        private int _fMonth;

        /// <summary>
        /// 月
        /// </summary>
        public  int  Month
        {
            get
            {
                return  _fMonth;
            }
            set
            {
                  _fMonth = value;
            }
         }
        #endregion

        #region 总金额
        private decimal _fAllMoney;

        /// <summary>
        /// 总金额
        /// </summary>
        public  decimal  AllMoney
        {
            get
            {
                return  _fAllMoney;
            }
            set
            {
                  _fAllMoney = value;
            }
         }
        #endregion

        #region 手续费
        private decimal _fHandlingFee;

        /// <summary>
        /// 手续费
        /// </summary>
        public  decimal  HandlingFee
        {
            get
            {
                return  _fHandlingFee;
            }
            set
            {
                  _fHandlingFee = value;
            }
         }
        #endregion

        #region 实际支付
        private decimal _fActualPayMoney;

        /// <summary>
        /// 实际支付
        /// </summary>
        public  decimal  ActualPayMoney
        {
            get
            {
                return  _fActualPayMoney;
            }
            set
            {
                  _fActualPayMoney = value;
            }
         }
        #endregion

        #region 支付凭证图片
        private string _fCertificateImg;

        /// <summary>
        /// 支付凭证图片
        /// </summary>
        public  string  CertificateImg
        {
            get
            {
                return  _fCertificateImg;
            }
            set
            {
                  _fCertificateImg = value;
            }
         }
        #endregion

        #region 支付凭证备注信息
        private string _fCertificateMemo;

        /// <summary>
        /// 支付凭证备注信息
        /// </summary>
        public  string  CertificateMemo
        {
            get
            {
                return  _fCertificateMemo;
            }
            set
            {
                  _fCertificateMemo = value;
            }
         }
        #endregion

        #region 支付状态
        private int _fPaymentStatus;

        /// <summary>
        /// 支付状态
        /// </summary>
        public  int  PaymentStatus
        {
            get
            {
                return  _fPaymentStatus;
            }
            set
            {
                  _fPaymentStatus = value;
            }
         }
        #endregion

        #region 操作员
        private int _fOperator;

        /// <summary>
        /// 操作员
        /// </summary>
        public  int  Operator
        {
            get
            {
                return  _fOperator;
            }
            set
            {
                  _fOperator = value;
            }
         }
        #endregion

        #region 生成时间
        private DateTime _fOperateTime;

        /// <summary>
        /// 生成时间
        /// </summary>
        public  DateTime  OperateTime
        {
            get
            {
                return  _fOperateTime;
            }
            set
            {
                  _fOperateTime = value;
            }
         }
        #endregion

        #region 标志
        private int _fTillDate;

        /// <summary>
        /// 标志
        /// </summary>
        public  int  TillDate
        {
            get
            {
                return  _fTillDate;
            }
            set
            {
                  _fTillDate = value;
            }
         }
        #endregion

        #region 周期起始时间
        private DateTime _fStartTime;

        /// <summary>
        /// 周期起始时间
        /// </summary>
        public  DateTime  StartTime
        {
            get
            {
                return  _fStartTime;
            }
            set
            {
                  _fStartTime = value;
            }
         }
        #endregion

        #region 周期结束时间
        private DateTime _fEndTime;

        /// <summary>
        /// 周期结束时间
        /// </summary>
        public  DateTime  EndTime
        {
            get
            {
                return  _fEndTime;
            }
            set
            {
                  _fEndTime = value;
            }
         }
        #endregion

        #region 对帐单ID标识
        private string _fSettelementid;

        /// <summary>
        /// 对帐单ID标识
        /// </summary>
        public  string  Settelementid
        {
            get
            {
                return  _fSettelementid;
            }
            set
            {
                  _fSettelementid = value;
            }
         }
        #endregion

        #region 停车场编码
        private string _fParkcode;

        /// <summary>
        /// 停车场编码
        /// </summary>
        public  string  Parkcode
        {
            get
            {
                return  _fParkcode;
            }
            set
            {
                  _fParkcode = value;
            }
         }
        #endregion

     }
}

