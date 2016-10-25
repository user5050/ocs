using System;

/*
* 由自动生成工具完成
* 描述:车辆支付订单额外信息表
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Orders
{
    /// <summary>
    /// 车辆支付订单额外信息表
    /// </summary>
    [Serializable]
    public partial class OrdersExtreVipDeferredDb
    {
        #region 订单编号
        private string _fOrderNo;

        /// <summary>
        /// 订单编号
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

        #region 补缴金额
        private double _fMoney;

        /// <summary>
        /// 补缴金额
        /// </summary>
        public  double  Money
        {
            get
            {
                return  _fMoney;
            }
            set
            {
                  _fMoney = value;
            }
         }
        #endregion

        #region 到期时间
        private DateTime _fTillDate;

        /// <summary>
        /// 到期时间
        /// </summary>
        public  DateTime  TillDate
        {
            get
            {
                return  _fTillDate;
            }
            set
            {
                  _fTillDate = value;
            }
         }
        #endregion

        #region 补交月数
        private int _fForMonth;

        /// <summary>
        /// 补交月数
        /// </summary>
        public  int  ForMonth
        {
            get
            {
                return  _fForMonth;
            }
            set
            {
                  _fForMonth = value;
            }
         }
        #endregion

        #region 会员优惠天数
        private int _fFreeDays;

        /// <summary>
        /// 会员优惠天数
        /// </summary>
        public  int  FreeDays
        {
            get
            {
                return  _fFreeDays;
            }
            set
            {
                  _fFreeDays = value;
            }
         }
        #endregion

     }
}

