using System;

/*
* 由自动生成工具完成
* 描述:[charge_settlement_info]e泊账户充值的月对账单
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Charge
{
    /// <summary>
    /// [charge_settlement_info]e泊账户充值的月对账单
    /// </summary>
    [Serializable]
    public partial class ChargeSettlementInfoDb
    {
        #region 对账单编号
        private int _fSettlementID;

        /// <summary>
        /// 对账单编号
        /// </summary>
        public  int  SettlementID
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

        #region 年
        private int _fYear;

        /// <summary>
        /// 年
        /// </summary>
        public  int  Year
        {
            get
            {
                return  _fYear;
            }
            set
            {
                  _fYear = value;
            }
         }
        #endregion

        #region 月
        private int _fMonth;

        /// <summary>
        /// 月
        /// </summary>
        public  int  Month
        {
            get
            {
                return  _fMonth;
            }
            set
            {
                  _fMonth = value;
            }
         }
        #endregion

        #region 充值总金额
        private decimal _fAllMoney;

        /// <summary>
        /// 充值总金额
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

