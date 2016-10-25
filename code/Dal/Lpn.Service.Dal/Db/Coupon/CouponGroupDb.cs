using System;

/*
* 由自动生成工具完成
* 描述:[coupon_group]优惠组
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Coupon
{
    /// <summary>
    /// [coupon_group]优惠组
    /// </summary>
    [Serializable]
    public partial class CouponGroupDb
    {
        #region 优惠组编号
        private string _fCouponGroupID;

        /// <summary>
        /// 优惠组编号
        /// </summary>
        public  string  CouponGroupID
        {
            get
            {
                return  _fCouponGroupID;
            }
            set
            {
                  _fCouponGroupID = value;
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

        #region 用户id
        private int _fUserId;

        /// <summary>
        /// 用户id
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
        private decimal _fCouponMoney;

        /// <summary>
        /// 优惠金额
        /// </summary>
        public  decimal  CouponMoney
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
        private decimal _fMoney1;

        /// <summary>
        /// 1元
        /// </summary>
        public  decimal  Money1
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
        private decimal _fMoney2;

        /// <summary>
        /// 2元
        /// </summary>
        public  decimal  Money2
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
        private decimal _fMoney3;

        /// <summary>
        /// 5元
        /// </summary>
        public  decimal  Money3
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

        #region 生成日期
        private DateTime _fCreatTime;

        /// <summary>
        /// 生成日期
        /// </summary>
        public  DateTime  CreatTime
        {
            get
            {
                return  _fCreatTime;
            }
            set
            {
                  _fCreatTime = value;
            }
         }
        #endregion

        #region 使用开始日期
        private DateTime _fStartTime;

        /// <summary>
        /// 使用开始日期
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

        #region 使用结束日期
        private DateTime _fExpireTime;

        /// <summary>
        /// 使用结束日期
        /// </summary>
        public  DateTime  ExpireTime
        {
            get
            {
                return  _fExpireTime;
            }
            set
            {
                  _fExpireTime = value;
            }
         }
        #endregion

        #region 领取有效结束日期
        private DateTime _fEffectiveTime;

        /// <summary>
        /// 领取有效结束日期
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

        #region 是否测试数据
        private int _fIsTest;

        /// <summary>
        /// 是否测试数据
        /// </summary>
        public  int  IsTest
        {
            get
            {
                return  _fIsTest;
            }
            set
            {
                  _fIsTest = value;
            }
         }
        #endregion

        #region 1元剩余个数
        private int _fNum1Remainder;

        /// <summary>
        /// 1元剩余个数
        /// </summary>
        public  int  Num1Remainder
        {
            get
            {
                return  _fNum1Remainder;
            }
            set
            {
                  _fNum1Remainder = value;
            }
         }
        #endregion

        #region 2元剩余个数
        private int _fNum2Remainder;

        /// <summary>
        /// 2元剩余个数
        /// </summary>
        public  int  Num2Remainder
        {
            get
            {
                return  _fNum2Remainder;
            }
            set
            {
                  _fNum2Remainder = value;
            }
         }
        #endregion

        #region 5元剩余个数
        private int _fNum3Remainder;

        /// <summary>
        /// 5元剩余个数
        /// </summary>
        public  int  Num3Remainder
        {
            get
            {
                return  _fNum3Remainder;
            }
            set
            {
                  _fNum3Remainder = value;
            }
         }
        #endregion

        #region 订单号
        private string _fOrderNo;

        /// <summary>
        /// 订单号
        /// </summary>
        public  string  OrderNo
        {
            get
            {
                return  _fOrderNo;
            }
            set
            {
                  _fOrderNo = value;
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

        #region 活动id
        private string _fActivityId;

        /// <summary>
        /// 活动id
        /// </summary>
        public  string  ActivityId
        {
            get
            {
                return  _fActivityId;
            }
            set
            {
                  _fActivityId = value;
            }
         }
        #endregion

     }
}

