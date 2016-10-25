using System;

/*
* 由自动生成工具完成
* 描述:[settlement_cycle]结算周期
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Settlement
{
    /// <summary>
    /// [settlement_cycle]结算周期
    /// </summary>
    [Serializable]
    public partial class SettlementCycleDb
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

        #region 起始时间
        private DateTime _fStartTime;

        /// <summary>
        /// 起始时间
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

        #region 结束时间
        private DateTime _fEndTime;

        /// <summary>
        /// 结束时间
        /// </summary>
        public  DateTime  EndTime
        {
            get
            {
                return  _fEndTime;
            }
            set
            {
                  _fEndTime = value;
            }
         }
        #endregion

     }
}

