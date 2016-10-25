using System;

/*
* 由自动生成工具完成
* 描述:[auto_payment_history]自动扣费历史记录
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Auto
{
    /// <summary>
    /// [auto_payment_history]自动扣费历史记录
    /// </summary>
    [Serializable]
    public partial class AutoPaymentHistoryDb
    {
        #region 自动扣费历史记录编号
        private int _fID;

        /// <summary>
        /// 自动扣费历史记录编号
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

        #region 停车场编码
        private string _fParkCode;

        /// <summary>
        /// 停车场编码
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

        #region 车牌号
        private string _fVehicleNo;

        /// <summary>
        /// 车牌号
        /// </summary>
        public  string  VehicleNo
        {
            get
            {
                return  _fVehicleNo;
            }
            set
            {
                  _fVehicleNo = value;
            }
         }
        #endregion

        #region 可支付最大金额
        private string _fMaxAutoPayment;

        /// <summary>
        /// 可支付最大金额
        /// </summary>
        public  string  MaxAutoPayment
        {
            get
            {
                return  _fMaxAutoPayment;
            }
            set
            {
                  _fMaxAutoPayment = value;
            }
         }
        #endregion

        #region 帐户最小余额
        private string _fMinMoney;

        /// <summary>
        /// 帐户最小余额
        /// </summary>
        public  string  MinMoney
        {
            get
            {
                return  _fMinMoney;
            }
            set
            {
                  _fMinMoney = value;
            }
         }
        #endregion

        #region 当前帐户余额
        private string _fPayment;

        /// <summary>
        /// 当前帐户余额
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

        #region 用户编号
        private int _fUserId;

        /// <summary>
        /// 用户编号
        /// </summary>
        public  int  UserId
        {
            get
            {
                return  _fUserId;
            }
            set
            {
                  _fUserId = value;
            }
         }
        #endregion

        #region 状态(0：未同步 1:已同步 2:已结算)
        private int _fStatus;

        /// <summary>
        /// 状态(0：未同步 1:已同步 2:已结算)
        /// </summary>
        public  int  Status
        {
            get
            {
                return  _fStatus;
            }
            set
            {
                  _fStatus = value;
            }
         }
        #endregion

        #region 优惠金额
        private int _fCouponMoney;

        /// <summary>
        /// 优惠金额
        /// </summary>
        public  int  CouponMoney
        {
            get
            {
                return  _fCouponMoney;
            }
            set
            {
                  _fCouponMoney = value;
            }
         }
        #endregion

        #region 优惠编号
        private string _fCouponDescription;

        /// <summary>
        /// 优惠编号
        /// </summary>
        public  string  CouponDescription
        {
            get
            {
                return  _fCouponDescription;
            }
            set
            {
                  _fCouponDescription = value;
            }
         }
        #endregion

     }
}

