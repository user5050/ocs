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
    public partial class OrdersExtreVipDb
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

        #region 续费月数
        private int _fRewardMonths;

        /// <summary>
        /// 续费月数
        /// </summary>
        public  int  RewardMonths
        {
            get
            {
                return  _fRewardMonths;
            }
            set
            {
                  _fRewardMonths = value;
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

     }
}

