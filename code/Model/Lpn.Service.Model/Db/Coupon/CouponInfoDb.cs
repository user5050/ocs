using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Model.Db.Coupon
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class CouponInfoDb
    {
        #region 优惠券id
        private string _fId;

        /// <summary>
        /// 优惠券id
        /// </summary>
        public  string  Id
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

        #region 用户id
        private string _fUid;

        /// <summary>
        /// 用户id
        /// </summary>
        public  string  Uid
        {
            get
            {
                return  _fUid;
            }
            set
            {
                  _fUid = value;
            }
         }
        #endregion

        #region 优惠券名称
        private string _fCouponName;

        /// <summary>
        /// 优惠券名称
        /// </summary>
        public  string  CouponName
        {
            get
            {
                return  _fCouponName;
            }
            set
            {
                  _fCouponName = value;
            }
         }
        #endregion

        #region 面额
        private int _fAmount;

        /// <summary>
        /// 面额
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

        #region 订单最小使用额度
        private int _fMinOrderMoney;

        /// <summary>
        /// 订单最小使用额度
        /// </summary>
        public  int  MinOrderMoney
        {
            get
            {
                return  _fMinOrderMoney;
            }
            set
            {
                  _fMinOrderMoney = value;
            }
         }
        #endregion

        #region 过期时间
        private DateTime _fExpiredTime;

        /// <summary>
        /// 过期时间
        /// </summary>
        public  DateTime  ExpiredTime
        {
            get
            {
                return  _fExpiredTime;
            }
            set
            {
                  _fExpiredTime = value;
            }
         }
        #endregion

        #region 状态(0无效1有效2已使用)
        private int _fState;

        /// <summary>
        /// 状态(0无效1有效2已使用)
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

        #region 是否已读(0否1是)
        private int _fIsView;

        /// <summary>
        /// 是否已读(0否1是)
        /// </summary>
        public  int  IsView
        {
            get
            {
                return  _fIsView;
            }
            set
            {
                  _fIsView = value;
            }
         }
        #endregion

     }
}

