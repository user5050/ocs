using System;

/*
* 由自动生成工具完成
* 描述:[coupon_template]优惠模板
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Coupon
{
    /// <summary>
    /// [coupon_template]优惠模板
    /// </summary>
    [Serializable]
    public partial class CouponTemplateDb
    {
        #region 优惠模板编号
        private string _fCouponTemplateID;

        /// <summary>
        /// 优惠模板编号
        /// </summary>
        public  string  CouponTemplateID
        {
            get
            {
                return  _fCouponTemplateID;
            }
            set
            {
                  _fCouponTemplateID = value;
            }
         }
        #endregion

        #region 优惠模板名称
        private string _fCouponName;

        /// <summary>
        /// 优惠模板名称
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

        #region 优惠类型
        private int _fCouponType;

        /// <summary>
        /// 优惠类型
        /// </summary>
        public  int  CouponType
        {
            get
            {
                return  _fCouponType;
            }
            set
            {
                  _fCouponType = value;
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

        #region 1元
        private int _fMoney1;

        /// <summary>
        /// 1元
        /// </summary>
        public  int  Money1
        {
            get
            {
                return  _fMoney1;
            }
            set
            {
                  _fMoney1 = value;
            }
         }
        #endregion

        #region 2元
        private int _fMoney2;

        /// <summary>
        /// 2元
        /// </summary>
        public  int  Money2
        {
            get
            {
                return  _fMoney2;
            }
            set
            {
                  _fMoney2 = value;
            }
         }
        #endregion

        #region 5元
        private int _fMoney3;

        /// <summary>
        /// 5元
        /// </summary>
        public  int  Money3
        {
            get
            {
                return  _fMoney3;
            }
            set
            {
                  _fMoney3 = value;
            }
         }
        #endregion

        #region 1元个数
        private int _fNum1;

        /// <summary>
        /// 1元个数
        /// </summary>
        public  int  Num1
        {
            get
            {
                return  _fNum1;
            }
            set
            {
                  _fNum1 = value;
            }
         }
        #endregion

        #region 2元个数
        private int _fNum2;

        /// <summary>
        /// 2元个数
        /// </summary>
        public  int  Num2
        {
            get
            {
                return  _fNum2;
            }
            set
            {
                  _fNum2 = value;
            }
         }
        #endregion

        #region 5元个数
        private int _fNum3;

        /// <summary>
        /// 5元个数
        /// </summary>
        public  int  Num3
        {
            get
            {
                return  _fNum3;
            }
            set
            {
                  _fNum3 = value;
            }
         }
        #endregion

        #region 领取有效期
        private DateTime _fEffectiveTime;

        /// <summary>
        /// 领取有效期
        /// </summary>
        public  DateTime  EffectiveTime
        {
            get
            {
                return  _fEffectiveTime;
            }
            set
            {
                  _fEffectiveTime = value;
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

        #region 链接地址
        private string _fUrl;

        /// <summary>
        /// 链接地址
        /// </summary>
        public  string  Url
        {
            get
            {
                return  _fUrl;
            }
            set
            {
                  _fUrl = value;
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

        #region 限制周数
        private string _fWeeks;

        /// <summary>
        /// 限制周数
        /// </summary>
        public  string  Weeks
        {
            get
            {
                return  _fWeeks;
            }
            set
            {
                  _fWeeks = value;
            }
         }
        #endregion

     }
}

