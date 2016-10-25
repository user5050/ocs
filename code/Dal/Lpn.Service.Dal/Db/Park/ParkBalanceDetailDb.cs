using System;

/*
* 由自动生成工具完成
* 描述:[park_balance_detail]停车场结算详细信息
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Park
{
    /// <summary>
    /// [park_balance_detail]停车场结算详细信息
    /// </summary>
    [Serializable]
    public partial class ParkBalanceDetailDb
    {
        #region 标识
        private string _fId;

        /// <summary>
        /// 标识
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

        #region 停车场编码
        private string _fParkbalance_id;

        /// <summary>
        /// 停车场编码
        /// </summary>
        public  string  Parkbalance_id
        {
            get
            {
                return  _fParkbalance_id;
            }
            set
            {
                  _fParkbalance_id = value;
            }
         }
        #endregion

        #region 电子支付临停总金额
        private decimal _fEbotemptotal;

        /// <summary>
        /// 电子支付临停总金额
        /// </summary>
        public  decimal  Ebotemptotal
        {
            get
            {
                return  _fEbotemptotal;
            }
            set
            {
                  _fEbotemptotal = value;
            }
         }
        #endregion

        #region 电子支付临停优惠券金额
        private decimal _fEbotempcoupon;

        /// <summary>
        /// 电子支付临停优惠券金额
        /// </summary>
        public  decimal  Ebotempcoupon
        {
            get
            {
                return  _fEbotempcoupon;
            }
            set
            {
                  _fEbotempcoupon = value;
            }
         }
        #endregion

        #region 电子支付月租总金额
        private decimal _fEbomonthtotal;

        /// <summary>
        /// 电子支付月租总金额
        /// </summary>
        public  decimal  Ebomonthtotal
        {
            get
            {
                return  _fEbomonthtotal;
            }
            set
            {
                  _fEbomonthtotal = value;
            }
         }
        #endregion

        #region 电子支付月租优惠券金额
        private decimal _fEbomonthcoupon;

        /// <summary>
        /// 电子支付月租优惠券金额
        /// </summary>
        public  decimal  Ebomonthcoupon
        {
            get
            {
                return  _fEbomonthcoupon;
            }
            set
            {
                  _fEbomonthcoupon = value;
            }
         }
        #endregion

        #region 电子支付闲时月租总金额
        private decimal _fEbofreetotal;

        /// <summary>
        /// 电子支付闲时月租总金额
        /// </summary>
        public  decimal  Ebofreetotal
        {
            get
            {
                return  _fEbofreetotal;
            }
            set
            {
                  _fEbofreetotal = value;
            }
         }
        #endregion

        #region 电子支付闲时月租优惠券金额
        private decimal _fEbofreecoupon;

        /// <summary>
        /// 电子支付闲时月租优惠券金额
        /// </summary>
        public  decimal  Ebofreecoupon
        {
            get
            {
                return  _fEbofreecoupon;
            }
            set
            {
                  _fEbofreecoupon = value;
            }
         }
        #endregion

        #region 电子支付忙时月租总金额
        private decimal _fEbobusytotal;

        /// <summary>
        /// 电子支付忙时月租总金额
        /// </summary>
        public  decimal  Ebobusytotal
        {
            get
            {
                return  _fEbobusytotal;
            }
            set
            {
                  _fEbobusytotal = value;
            }
         }
        #endregion

        #region 电子支付忙时月租优惠券金额
        private decimal _fEbobusycoupon;

        /// <summary>
        /// 电子支付忙时月租优惠券金额
        /// </summary>
        public  decimal  Ebobusycoupon
        {
            get
            {
                return  _fEbobusycoupon;
            }
            set
            {
                  _fEbobusycoupon = value;
            }
         }
        #endregion

        #region 电子支付闲时超时临停总金额
        private decimal _fEbofreetemptotal;

        /// <summary>
        /// 电子支付闲时超时临停总金额
        /// </summary>
        public  decimal  Ebofreetemptotal
        {
            get
            {
                return  _fEbofreetemptotal;
            }
            set
            {
                  _fEbofreetemptotal = value;
            }
         }
        #endregion

        #region 电子支付闲时超时临停优惠券金额
        private decimal _fEbofreetempcoupon;

        /// <summary>
        /// 电子支付闲时超时临停优惠券金额
        /// </summary>
        public  decimal  Ebofreetempcoupon
        {
            get
            {
                return  _fEbofreetempcoupon;
            }
            set
            {
                  _fEbofreetempcoupon = value;
            }
         }
        #endregion

        #region 电子支付忙时超时临停总金额
        private decimal _fEbobusytemptotal;

        /// <summary>
        /// 电子支付忙时超时临停总金额
        /// </summary>
        public  decimal  Ebobusytemptotal
        {
            get
            {
                return  _fEbobusytemptotal;
            }
            set
            {
                  _fEbobusytemptotal = value;
            }
         }
        #endregion

        #region 电子支付忙时超时临停优惠券金额
        private decimal _fEbobusytempcoupon;

        /// <summary>
        /// 电子支付忙时超时临停优惠券金额
        /// </summary>
        public  decimal  Ebobusytempcoupon
        {
            get
            {
                return  _fEbobusytempcoupon;
            }
            set
            {
                  _fEbobusytempcoupon = value;
            }
         }
        #endregion

        #region 本地支付闲时月租总金额
        private decimal _fLocalfreetotal;

        /// <summary>
        /// 本地支付闲时月租总金额
        /// </summary>
        public  decimal  Localfreetotal
        {
            get
            {
                return  _fLocalfreetotal;
            }
            set
            {
                  _fLocalfreetotal = value;
            }
         }
        #endregion

        #region 本地支付闲时月租优惠券金额
        private decimal _fLocalfreecoupon;

        /// <summary>
        /// 本地支付闲时月租优惠券金额
        /// </summary>
        public  decimal  Localfreecoupon
        {
            get
            {
                return  _fLocalfreecoupon;
            }
            set
            {
                  _fLocalfreecoupon = value;
            }
         }
        #endregion

        #region 本地支付忙时月租总金额
        private decimal _fLocalbusytotal;

        /// <summary>
        /// 本地支付忙时月租总金额
        /// </summary>
        public  decimal  Localbusytotal
        {
            get
            {
                return  _fLocalbusytotal;
            }
            set
            {
                  _fLocalbusytotal = value;
            }
         }
        #endregion

        #region 本地支付忙时月租优惠券金额
        private decimal _fLocalbusycoupon;

        /// <summary>
        /// 本地支付忙时月租优惠券金额
        /// </summary>
        public  decimal  Localbusycoupon
        {
            get
            {
                return  _fLocalbusycoupon;
            }
            set
            {
                  _fLocalbusycoupon = value;
            }
         }
        #endregion

        #region 本地支付闲时超时临停总金额
        private decimal _fLocalfreetemptotal;

        /// <summary>
        /// 本地支付闲时超时临停总金额
        /// </summary>
        public  decimal  Localfreetemptotal
        {
            get
            {
                return  _fLocalfreetemptotal;
            }
            set
            {
                  _fLocalfreetemptotal = value;
            }
         }
        #endregion

        #region 本地支付闲时超时临停优惠券金额
        private decimal _fLocalfreetempcoupon;

        /// <summary>
        /// 本地支付闲时超时临停优惠券金额
        /// </summary>
        public  decimal  Localfreetempcoupon
        {
            get
            {
                return  _fLocalfreetempcoupon;
            }
            set
            {
                  _fLocalfreetempcoupon = value;
            }
         }
        #endregion

        #region 本地支付忙时超时临停总金额
        private decimal _fLocalbusytemptotal;

        /// <summary>
        /// 本地支付忙时超时临停总金额
        /// </summary>
        public  decimal  Localbusytemptotal
        {
            get
            {
                return  _fLocalbusytemptotal;
            }
            set
            {
                  _fLocalbusytemptotal = value;
            }
         }
        #endregion

        #region 本地支付忙时超时临停优惠券金额
        private decimal _fLocalbusytempcoupon;

        /// <summary>
        /// 本地支付忙时超时临停优惠券金额
        /// </summary>
        public  decimal  Localbusytempcoupon
        {
            get
            {
                return  _fLocalbusytempcoupon;
            }
            set
            {
                  _fLocalbusytempcoupon = value;
            }
         }
        #endregion

        #region 临停结算费率
        private decimal _fParkfee;

        /// <summary>
        /// 临停结算费率
        /// </summary>
        public  decimal  Parkfee
        {
            get
            {
                return  _fParkfee;
            }
            set
            {
                  _fParkfee = value;
            }
         }
        #endregion

        #region 月租结算费率
        private decimal _fMonthfee;

        /// <summary>
        /// 月租结算费率
        /// </summary>
        public  decimal  Monthfee
        {
            get
            {
                return  _fMonthfee;
            }
            set
            {
                  _fMonthfee = value;
            }
         }
        #endregion

        #region 闲时月租分成比例
        private decimal _fFreefee;

        /// <summary>
        /// 闲时月租分成比例
        /// </summary>
        public  decimal  Freefee
        {
            get
            {
                return  _fFreefee;
            }
            set
            {
                  _fFreefee = value;
            }
         }
        #endregion

        #region 忙时月租分成比例
        private decimal _fBusyfee;

        /// <summary>
        /// 忙时月租分成比例
        /// </summary>
        public  decimal  Busyfee
        {
            get
            {
                return  _fBusyfee;
            }
            set
            {
                  _fBusyfee = value;
            }
         }
        #endregion

        #region 闲时月租超时分成比例
        private decimal _fOverfreefee;

        /// <summary>
        /// 闲时月租超时分成比例
        /// </summary>
        public  decimal  Overfreefee
        {
            get
            {
                return  _fOverfreefee;
            }
            set
            {
                  _fOverfreefee = value;
            }
         }
        #endregion

        #region 忙时月租超时分成比例
        private decimal _fOverbusyfee;

        /// <summary>
        /// 忙时月租超时分成比例
        /// </summary>
        public  decimal  Overbusyfee
        {
            get
            {
                return  _fOverbusyfee;
            }
            set
            {
                  _fOverbusyfee = value;
            }
         }
        #endregion

        #region 结算金额
        private decimal _fBalancemoney;

        /// <summary>
        /// 结算金额
        /// </summary>
        public  decimal  Balancemoney
        {
            get
            {
                return  _fBalancemoney;
            }
            set
            {
                  _fBalancemoney = value;
            }
         }
        #endregion

        #region 对帐单起始时间
        private DateTime _fStarttime;

        /// <summary>
        /// 对帐单起始时间
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

        #region 对帐单结束时间
        private DateTime _fEndtime;

        /// <summary>
        /// 对帐单结束时间
        /// </summary>
        public  DateTime  Endtime
        {
            get
            {
                return  _fEndtime;
            }
            set
            {
                  _fEndtime = value;
            }
         }
        #endregion

        #region 引流数量
        private decimal _fActivitycount;

        /// <summary>
        /// 引流数量
        /// </summary>
        public  decimal  Activitycount
        {
            get
            {
                return  _fActivitycount;
            }
            set
            {
                  _fActivitycount = value;
            }
         }
        #endregion

        #region 引流单价
        private decimal _fActivityprice;

        /// <summary>
        /// 引流单价
        /// </summary>
        public  decimal  Activityprice
        {
            get
            {
                return  _fActivityprice;
            }
            set
            {
                  _fActivityprice = value;
            }
         }
        #endregion

        #region 包时长抵扣金额
        private decimal _fActivitytimededu;

        /// <summary>
        /// 包时长抵扣金额
        /// </summary>
        public  decimal  Activitytimededu
        {
            get
            {
                return  _fActivitytimededu;
            }
            set
            {
                  _fActivitytimededu = value;
            }
         }
        #endregion

        #region Localmembertotal
        private decimal _fLocalmembertotal;

        /// <summary>
        /// Localmembertotal
        /// </summary>
        public  decimal  Localmembertotal
        {
            get
            {
                return  _fLocalmembertotal;
            }
            set
            {
                  _fLocalmembertotal = value;
            }
         }
        #endregion

        #region Ebomembertotal
        private decimal _fEbomembertotal;

        /// <summary>
        /// Ebomembertotal
        /// </summary>
        public  decimal  Ebomembertotal
        {
            get
            {
                return  _fEbomembertotal;
            }
            set
            {
                  _fEbomembertotal = value;
            }
         }
        #endregion

        #region Memberfee
        private decimal _fMemberfee;

        /// <summary>
        /// Memberfee
        /// </summary>
        public  decimal  Memberfee
        {
            get
            {
                return  _fMemberfee;
            }
            set
            {
                  _fMemberfee = value;
            }
         }
        #endregion

     }
}

