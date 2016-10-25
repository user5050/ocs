using System;

/*
* 由自动生成工具完成
* 描述:[park_settlement_info_detail]对账单详细结算信息
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Park
{
    /// <summary>
    /// [park_settlement_info_detail]对账单详细结算信息
    /// </summary>
    [Serializable]
    public partial class ParkSettlementInfoDetailDb
    {
        #region 对账单详细结算信息编号
        private decimal _fSettlementID;

        /// <summary>
        /// 对账单详细结算信息编号
        /// </summary>
        public  decimal  SettlementID
        {
            get
            {
                return  _fSettlementID;
            }
            set
            {
                  _fSettlementID = value;
            }
         }
        #endregion

        #region 结算费率
        private decimal _fSettlementRate;

        /// <summary>
        /// 结算费率
        /// </summary>
        public  decimal  SettlementRate
        {
            get
            {
                return  _fSettlementRate;
            }
            set
            {
                  _fSettlementRate = value;
            }
         }
        #endregion

        #region 结算类别
        private int _fSettlementSort;

        /// <summary>
        /// 结算类别
        /// </summary>
        public  int  SettlementSort
        {
            get
            {
                return  _fSettlementSort;
            }
            set
            {
                  _fSettlementSort = value;
            }
         }
        #endregion

        #region 总金额
        private decimal _fAllMoney;

        /// <summary>
        /// 总金额
        /// </summary>
        public  decimal  AllMoney
        {
            get
            {
                return  _fAllMoney;
            }
            set
            {
                  _fAllMoney = value;
            }
         }
        #endregion

        #region 手续费率
        private decimal _fHandlingFee;

        /// <summary>
        /// 手续费率
        /// </summary>
        public  decimal  HandlingFee
        {
            get
            {
                return  _fHandlingFee;
            }
            set
            {
                  _fHandlingFee = value;
            }
         }
        #endregion

        #region 交易笔数
        private int _fPaymentCount;

        /// <summary>
        /// 交易笔数
        /// </summary>
        public  int  PaymentCount
        {
            get
            {
                return  _fPaymentCount;
            }
            set
            {
                  _fPaymentCount = value;
            }
         }
        #endregion

        #region 生成时间
        private DateTime _fOperateTime;

        /// <summary>
        /// 生成时间
        /// </summary>
        public  DateTime  OperateTime
        {
            get
            {
                return  _fOperateTime;
            }
            set
            {
                  _fOperateTime = value;
            }
         }
        #endregion

     }
}

