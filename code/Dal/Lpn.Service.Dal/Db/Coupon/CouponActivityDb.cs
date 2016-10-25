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
    public partial class CouponActivityDb
    {
        #region 活动id
        private int _fId;

        /// <summary>
        /// 活动id
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

        #region 活动名称
        private string _fName;

        /// <summary>
        /// 活动名称
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

        #region 活动类型
        private int _fType;

        /// <summary>
        /// 活动类型
        /// </summary>
        public  int  Type
        {
            get
            {
                return  _fType;
            }
            set
            {
                  _fType = value;
            }
         }
        #endregion

        #region 活动地区(自定义)
        private string _fCity;

        /// <summary>
        /// 活动地区(自定义)
        /// </summary>
        public  string  City
        {
            get
            {
                return  _fCity;
            }
            set
            {
                  _fCity = value;
            }
         }
        #endregion

        #region 活动开始时间
        private DateTime _fStartTime;

        /// <summary>
        /// 活动开始时间
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

        #region 活动到期时间(空则不限制)
        private DateTime _fExpiredTime;

        /// <summary>
        /// 活动到期时间(空则不限制)
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

        #region 活动周限制(空则不限制)
        private string _fWeeks;

        /// <summary>
        /// 活动周限制(空则不限制)
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

        #region 支付时最低金额(-1不限制)
        private double _fMinMoney;

        /// <summary>
        /// 支付时最低金额(-1不限制)
        /// </summary>
        public  double  MinMoney
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

        #region 支付时最高金额(-1不限制)
        private double _fMaxMoney;

        /// <summary>
        /// 支付时最高金额(-1不限制)
        /// </summary>
        public  double  MaxMoney
        {
            get
            {
                return  _fMaxMoney;
            }
            set
            {
                  _fMaxMoney = value;
            }
         }
        #endregion

        #region 获取场景描述
        private string _fDescription;

        /// <summary>
        /// 获取场景描述
        /// </summary>
        public  string  Description
        {
            get
            {
                return  _fDescription;
            }
            set
            {
                  _fDescription = value;
            }
         }
        #endregion

        #region h5活动id
        private string _fActivityId;

        /// <summary>
        /// h5活动id
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

        #region h5活动url地址
        private string _fActivityUrl;

        /// <summary>
        /// h5活动url地址
        /// </summary>
        public  string  ActivityUrl
        {
            get
            {
                return  _fActivityUrl;
            }
            set
            {
                  _fActivityUrl = value;
            }
         }
        #endregion

        #region 分享内容
        private string _fShareDesc;

        /// <summary>
        /// 分享内容
        /// </summary>
        public  string  ShareDesc
        {
            get
            {
                return  _fShareDesc;
            }
            set
            {
                  _fShareDesc = value;
            }
         }
        #endregion

        #region 充值小喇叭
        private string _fRechargeDesc;

        /// <summary>
        /// 充值小喇叭
        /// </summary>
        public  string  RechargeDesc
        {
            get
            {
                return  _fRechargeDesc;
            }
            set
            {
                  _fRechargeDesc = value;
            }
         }
        #endregion

        #region 礼包数量(-1 不限制)
        private int _fGiftAmount;

        /// <summary>
        /// 礼包数量(-1 不限制)
        /// </summary>
        public  int  GiftAmount
        {
            get
            {
                return  _fGiftAmount;
            }
            set
            {
                  _fGiftAmount = value;
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

