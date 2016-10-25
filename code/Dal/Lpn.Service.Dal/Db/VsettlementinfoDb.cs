using System;

/*
* 由自动生成工具完成
* 描述:VIEW
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db
{
    /// <summary>
    /// VIEW
    /// </summary>
    [Serializable]
    public partial class VsettlementinfoDb
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
        private int _fParkid;

        /// <summary>
        /// 停车场编号
        /// </summary>
        public  int  Parkid
        {
            get
            {
                return  _fParkid;
            }
            set
            {
                  _fParkid = value;
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

        #region 停车场名称
        private string _fParkname;

        /// <summary>
        /// 停车场名称
        /// </summary>
        public  string  Parkname
        {
            get
            {
                return  _fParkname;
            }
            set
            {
                  _fParkname = value;
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

        #region Operatorname
        private string _fOperatorname;

        /// <summary>
        /// Operatorname
        /// </summary>
        public  string  Operatorname
        {
            get
            {
                return  _fOperatorname;
            }
            set
            {
                  _fOperatorname = value;
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

     }
}

