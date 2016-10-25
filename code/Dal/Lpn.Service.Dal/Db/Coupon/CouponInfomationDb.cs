using System;

/*
* 由自动生成工具完成
* 描述:[coupon_infomation]优惠券信息
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Coupon
{
    /// <summary>
    /// [coupon_infomation]优惠券信息
    /// </summary>
    [Serializable]
    public partial class CouponInfomationDb
    {
        #region 优惠券信息编号
        private string _fCouponID;

        /// <summary>
        /// 优惠券信息编号
        /// </summary>
        public  string  CouponID
        {
            get
            {
                return  _fCouponID;
            }
            set
            {
                  _fCouponID = value;
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

        #region 用户编号
        private int _fUserID;

        /// <summary>
        /// 用户编号
        /// </summary>
        public  int  UserID
        {
            get
            {
                return  _fUserID;
            }
            set
            {
                  _fUserID = value;
            }
         }
        #endregion

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

        #region 生成日期
        private DateTime _fCreattime;

        /// <summary>
        /// 生成日期
        /// </summary>
        public  DateTime  Creattime
        {
            get
            {
                return  _fCreattime;
            }
            set
            {
                  _fCreattime = value;
            }
         }
        #endregion

        #region 使用开始日期
        private DateTime _fStarttime;

        /// <summary>
        /// 使用开始日期
        /// </summary>
        public  DateTime  Starttime
        {
            get
            {
                return  _fStarttime;
            }
            set
            {
                  _fStarttime = value;
            }
         }
        #endregion

        #region 使用结束日期
        private DateTime _fExpiretime;

        /// <summary>
        /// 使用结束日期
        /// </summary>
        public  DateTime  Expiretime
        {
            get
            {
                return  _fExpiretime;
            }
            set
            {
                  _fExpiretime = value;
            }
         }
        #endregion

        #region 领取有效结束日期
        private DateTime _fEffectivetime;

        /// <summary>
        /// 领取有效结束日期
        /// </summary>
        public  DateTime  Effectivetime
        {
            get
            {
                return  _fEffectivetime;
            }
            set
            {
                  _fEffectivetime = value;
            }
         }
        #endregion

        #region 状态
        private int _fState;

        /// <summary>
        /// 状态
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

        #region 昵称
        private string _fNickName;

        /// <summary>
        /// 昵称
        /// </summary>
        public  string  NickName
        {
            get
            {
                return  _fNickName;
            }
            set
            {
                  _fNickName = value;
            }
         }
        #endregion

        #region 头像链接地址
        private string _fHeadUrl;

        /// <summary>
        /// 头像链接地址
        /// </summary>
        public  string  HeadUrl
        {
            get
            {
                return  _fHeadUrl;
            }
            set
            {
                  _fHeadUrl = value;
            }
         }
        #endregion

        #region 随机评论
        private string _fRandomStr;

        /// <summary>
        /// 随机评论
        /// </summary>
        public  string  RandomStr
        {
            get
            {
                return  _fRandomStr;
            }
            set
            {
                  _fRandomStr = value;
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

        #region 停车场限制类型(-1不限制0指定停车场1只在优惠券获得的停车场使用)
        private int _fParkLimitType;

        /// <summary>
        /// 停车场限制类型(-1不限制0指定停车场1只在优惠券获得的停车场使用)
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

        #region 是否已查看
        private int _fIsView;

        /// <summary>
        /// 是否已查看
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

