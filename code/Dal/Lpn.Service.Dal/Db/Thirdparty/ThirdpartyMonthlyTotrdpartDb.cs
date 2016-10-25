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
    public partial class ThirdpartyMonthlyTotrdpartDb
    {
        #region 合作商
        private string _fPartnerId;

        /// <summary>
        /// 合作商
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

        #region 三方用户标示
        private string _fTrdUserToken;

        /// <summary>
        /// 三方用户标示
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

        #region 开始时间
        private DateTime _fStartTime;

        /// <summary>
        /// 开始时间
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

        #region 到期时间
        private DateTime _fTillTime;

        /// <summary>
        /// 到期时间
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

        #region 购买月数
        private int _fAmount;

        /// <summary>
        /// 购买月数
        /// </summary>
        public  int  Amount
        {
            get
            {
                return  _fAmount;
            }
            set
            {
                  _fAmount = value;
            }
         }
        #endregion

        #region 续费车位数
        private int _fParkingAmount;

        /// <summary>
        /// 续费车位数
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

        #region 续费金额
        private double _fConsume;

        /// <summary>
        /// 续费金额
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

        #region 续费时间
        private DateTime _fTime;

        /// <summary>
        /// 续费时间
        /// </summary>
        public  DateTime  Time
        {
            get
            {
                return  _fTime;
            }
            set
            {
                  _fTime = value;
            }
         }
        #endregion

        #region 是否已上报
        private int _fIsSync;

        /// <summary>
        /// 是否已上报
        /// </summary>
        public  int  IsSync
        {
            get
            {
                return  _fIsSync;
            }
            set
            {
                  _fIsSync = value;
            }
         }
        #endregion

     }
}

