using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Coupon
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class CouponActivityGiftDb
    {
        #region 礼包id
        private int _fId;

        /// <summary>
        /// 礼包id
        /// </summary>
        public  int  Id
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

        #region 礼包所属优惠券获取ID
        private int _fCouponActivityId;

        /// <summary>
        /// 礼包所属优惠券获取ID
        /// </summary>
        public  int  CouponActivityId
        {
            get
            {
                return  _fCouponActivityId;
            }
            set
            {
                  _fCouponActivityId = value;
            }
         }
        #endregion

        #region 优惠券名称
        private string _fName;

        /// <summary>
        /// 优惠券名称
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

        #region 数量
        private int _fNumber;

        /// <summary>
        /// 数量
        /// </summary>
        public  int  Number
        {
            get
            {
                return  _fNumber;
            }
            set
            {
                  _fNumber = value;
            }
         }
        #endregion

        #region 使用范围类型
        private int _fRangeType;

        /// <summary>
        /// 使用范围类型
        /// </summary>
        public  int  RangeType
        {
            get
            {
                return  _fRangeType;
            }
            set
            {
                  _fRangeType = value;
            }
         }
        #endregion

        #region 使用范围(英文半角逗号分割，通用不限制)
        private string _fUseRange;

        /// <summary>
        /// 使用范围(英文半角逗号分割，通用不限制)
        /// </summary>
        public  string  UseRange
        {
            get
            {
                return  _fUseRange;
            }
            set
            {
                  _fUseRange = value;
            }
         }
        #endregion

        #region 停车场限制类型(-1不限制1指定停车场2只在优惠券获得的停车场使用)
        private int _fParkLimitType;

        /// <summary>
        /// 停车场限制类型(-1不限制1指定停车场2只在优惠券获得的停车场使用)
        /// </summary>
        public  int  ParkLimitType
        {
            get
            {
                return  _fParkLimitType;
            }
            set
            {
                  _fParkLimitType = value;
            }
         }
        #endregion

        #region 停车场编码(ParkLimitType=0有效,逗号分割)
        private string _fParkCodes;

        /// <summary>
        /// 停车场编码(ParkLimitType=0有效,逗号分割)
        /// </summary>
        public  string  ParkCodes
        {
            get
            {
                return  _fParkCodes;
            }
            set
            {
                  _fParkCodes = value;
            }
         }
        #endregion

        #region 优惠券有效方式
        private int _fWay;

        /// <summary>
        /// 优惠券有效方式
        /// </summary>
        public  int  Way
        {
            get
            {
                return  _fWay;
            }
            set
            {
                  _fWay = value;
            }
         }
        #endregion

        #region 使用有效起始时间
        private DateTime _fStartDate;

        /// <summary>
        /// 使用有效起始时间
        /// </summary>
        public  DateTime  StartDate
        {
            get
            {
                return  _fStartDate;
            }
            set
            {
                  _fStartDate = value;
            }
         }
        #endregion

        #region 使用有效结束时间
        private DateTime _fEndDate;

        /// <summary>
        /// 使用有效结束时间
        /// </summary>
        public  DateTime  EndDate
        {
            get
            {
                return  _fEndDate;
            }
            set
            {
                  _fEndDate = value;
            }
         }
        #endregion

        #region 有效期天数
        private int _fDays;

        /// <summary>
        /// 有效期天数
        /// </summary>
        public  int  Days
        {
            get
            {
                return  _fDays;
            }
            set
            {
                  _fDays = value;
            }
         }
        #endregion

        #region 摘要
        private string _fSummary;

        /// <summary>
        /// 摘要
        /// </summary>
        public  string  Summary
        {
            get
            {
                return  _fSummary;
            }
            set
            {
                  _fSummary = value;
            }
         }
        #endregion

        #region 创建时间
        private DateTime _fRowTime;

        /// <summary>
        /// 创建时间
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

        #region 创建者
        private string _fOperator;

        /// <summary>
        /// 创建者
        /// </summary>
        public  string  Operator
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

     }
}

