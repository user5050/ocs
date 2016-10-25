using System;

/*
* 由自动生成工具完成
* 描述:[park_settlement_rate]停车场结算费率
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Park
{
    /// <summary>
    /// [park_settlement_rate]停车场结算费率
    /// </summary>
    [Serializable]
    public partial class ParkSettlementRateDb
    {
        #region 停车场编号
        private int _fParkID;

        /// <summary>
        /// 停车场编号
        /// </summary>
        public  int  ParkID
        {
            get
            {
                return  _fParkID;
            }
            set
            {
                  _fParkID = value;
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

        #region 操作人员
        private int _fOperator;

        /// <summary>
        /// 操作人员
        /// </summary>
        public  int  Operator
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

