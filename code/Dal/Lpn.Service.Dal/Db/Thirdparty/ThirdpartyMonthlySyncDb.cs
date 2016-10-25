using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Thirdparty
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class ThirdpartyMonthlySyncDb
    {
        #region Id
        private long _fId;

        /// <summary>
        /// Id
        /// </summary>
        public  long  Id
        {
            get
            {
                return  _fId;
            }
            set
            {
                  _fId = value;
            }
         }
        #endregion

        #region 停车场编号
        private string _fParkCode;

        /// <summary>
        /// 停车场编号
        /// </summary>
        public  string  ParkCode
        {
            get
            {
                return  _fParkCode;
            }
            set
            {
                  _fParkCode = value;
            }
         }
        #endregion

        #region 三方用户标示(手机号码)
        private string _fTrdUserToken;

        /// <summary>
        /// 三方用户标示(手机号码)
        /// </summary>
        public  string  TrdUserToken
        {
            get
            {
                return  _fTrdUserToken;
            }
            set
            {
                  _fTrdUserToken = value;
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

        #region 手机号码
        private string _fMobile;

        /// <summary>
        /// 手机号码
        /// </summary>
        public  string  Mobile
        {
            get
            {
                return  _fMobile;
            }
            set
            {
                  _fMobile = value;
            }
         }
        #endregion

        #region 用户名
        private string _fName;

        /// <summary>
        /// 用户名
        /// </summary>
        public  string  Name
        {
            get
            {
                return  _fName;
            }
            set
            {
                  _fName = value;
            }
         }
        #endregion

        #region 车牌号,分隔
        private string _fCarNos;

        /// <summary>
        /// 车牌号,分隔
        /// </summary>
        public  string  CarNos
        {
            get
            {
                return  _fCarNos;
            }
            set
            {
                  _fCarNos = value;
            }
         }
        #endregion

        #region 缴费时间
        private DateTime _fStartTime;

        /// <summary>
        /// 缴费时间
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

        #region 月租到期时间
        private DateTime _fTillTime;

        /// <summary>
        /// 月租到期时间
        /// </summary>
        public  DateTime  TillTime
        {
            get
            {
                return  _fTillTime;
            }
            set
            {
                  _fTillTime = value;
            }
         }
        #endregion

        #region 缴费金额
        private double _fConsume;

        /// <summary>
        /// 缴费金额
        /// </summary>
        public  double  Consume
        {
            get
            {
                return  _fConsume;
            }
            set
            {
                  _fConsume = value;
            }
         }
        #endregion

        #region 车位信息
        private string _fParkingNos;

        /// <summary>
        /// 车位信息
        /// </summary>
        public  string  ParkingNos
        {
            get
            {
                return  _fParkingNos;
            }
            set
            {
                  _fParkingNos = value;
            }
         }
        #endregion

        #region 车位数量
        private int _fParkingAmount;

        /// <summary>
        /// 车位数量
        /// </summary>
        public  int  ParkingAmount
        {
            get
            {
                return  _fParkingAmount;
            }
            set
            {
                  _fParkingAmount = value;
            }
         }
        #endregion

        #region 费率
        private double _fAmountPerMonth;

        /// <summary>
        /// 费率
        /// </summary>
        public  double  AmountPerMonth
        {
            get
            {
                return  _fAmountPerMonth;
            }
            set
            {
                  _fAmountPerMonth = value;
            }
         }
        #endregion

        #region 处理状态(0待处理,1已处理)
        private int _fState;

        /// <summary>
        /// 处理状态(0待处理,1已处理)
        /// </summary>
        public  int  State
        {
            get
            {
                return  _fState;
            }
            set
            {
                  _fState = value;
            }
         }
        #endregion

        #region 记录时间
        private DateTime _fRowTime;

        /// <summary>
        /// 记录时间
        /// </summary>
        public  DateTime  RowTime
        {
            get
            {
                return  _fRowTime;
            }
            set
            {
                  _fRowTime = value;
            }
         }
        #endregion

     }
}

