using System;

/*
* 由自动生成工具完成
* 描述:月租支付订单额外信息表
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Orders
{
    /// <summary>
    /// 月租支付订单额外信息表
    /// </summary>
    [Serializable]
    public partial class OrdersExtreRenewalmonthDb
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

        #region 月租车到期时间
        private DateTime _fTillDate;

        /// <summary>
        /// 月租车到期时间
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

        #region 月租车续费月份
        private int _fRenewalMonths;

        /// <summary>
        /// 月租车续费月份
        /// </summary>
        public  int  RenewalMonths
        {
            get
            {
                return  _fRenewalMonths;
            }
            set
            {
                  _fRenewalMonths = value;
            }
         }
        #endregion

        #region 时段月租时段模式
        private int _fMonthlySort;

        /// <summary>
        /// 时段月租时段模式
        /// </summary>
        public  int  MonthlySort
        {
            get
            {
                return  _fMonthlySort;
            }
            set
            {
                  _fMonthlySort = value;
            }
         }
        #endregion

     }
}

