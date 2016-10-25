using System;

/*
* 由自动生成工具完成
* 描述:[pre_account_info]预修改停车场结算信息表
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Pre
{
    /// <summary>
    /// [pre_account_info]预修改停车场结算信息表
    /// </summary>
    [Serializable]
    public partial class PreAccountInfoDb
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

        #region 临停缴费结算费率
        private decimal _fSettlementRate1;

        /// <summary>
        /// 临停缴费结算费率
        /// </summary>
        public  decimal  SettlementRate1
        {
            get
            {
                return  _fSettlementRate1;
            }
            set
            {
                  _fSettlementRate1 = value;
            }
         }
        #endregion

        #region 月租续费结算费率
        private decimal _fSettlementRate2;

        /// <summary>
        /// 月租续费结算费率
        /// </summary>
        public  decimal  SettlementRate2
        {
            get
            {
                return  _fSettlementRate2;
            }
            set
            {
                  _fSettlementRate2 = value;
            }
         }
        #endregion

        #region 公共预约结算费率
        private decimal _fSettlementRate3;

        /// <summary>
        /// 公共预约结算费率
        /// </summary>
        public  decimal  SettlementRate3
        {
            get
            {
                return  _fSettlementRate3;
            }
            set
            {
                  _fSettlementRate3 = value;
            }
         }
        #endregion

        #region 出租车位结算费率
        private decimal _fSettlementRate4;

        /// <summary>
        /// 出租车位结算费率
        /// </summary>
        public  decimal  SettlementRate4
        {
            get
            {
                return  _fSettlementRate4;
            }
            set
            {
                  _fSettlementRate4 = value;
            }
         }
        #endregion

        #region 结算周期
        private int _fSettlementInterval;

        /// <summary>
        /// 结算周期
        /// </summary>
        public  int  SettlementInterval
        {
            get
            {
                return  _fSettlementInterval;
            }
            set
            {
                  _fSettlementInterval = value;
            }
         }
        #endregion

        #region 生效时间
        private DateTime _fEffectTime;

        /// <summary>
        /// 生效时间
        /// </summary>
        public  DateTime  EffectTime
        {
            get
            {
                return  _fEffectTime;
            }
            set
            {
                  _fEffectTime = value;
            }
         }
        #endregion

     }
}

