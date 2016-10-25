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
    public partial class OrdersExtreCarexitDb
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

        #region 入场时间
        private DateTime _fEntranceTime;

        /// <summary>
        /// 入场时间
        /// </summary>
        public  DateTime  EntranceTime
        {
            get
            {
                return  _fEntranceTime;
            }
            set
            {
                  _fEntranceTime = value;
            }
         }
        #endregion

        #region 出场时间
        private DateTime _fExitTime;

        /// <summary>
        /// 出场时间
        /// </summary>
        public  DateTime  ExitTime
        {
            get
            {
                return  _fExitTime;
            }
            set
            {
                  _fExitTime = value;
            }
         }
        #endregion

        #region 抵扣券id
        private string _fDeductionId;

        /// <summary>
        /// 抵扣券id
        /// </summary>
        public  string  DeductionId
        {
            get
            {
                return  _fDeductionId;
            }
            set
            {
                  _fDeductionId = value;
            }
         }
        #endregion

     }
}

