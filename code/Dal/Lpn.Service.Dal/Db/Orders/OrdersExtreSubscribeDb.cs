using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Orders
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class OrdersExtreSubscribeDb
    {
        #region 订单号
        private string _fOrderNo;

        /// <summary>
        /// 订单号
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

        #region 预约入场时间
        private DateTime _fStartTime;

        /// <summary>
        /// 预约入场时间
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

        #region 预约出场时间
        private DateTime _fEndTime;

        /// <summary>
        /// 预约出场时间
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

        #region 预约时间
        private DateTime _fSubTime;

        /// <summary>
        /// 预约时间
        /// </summary>
        public  DateTime  SubTime
        {
            get
            {
                return  _fSubTime;
            }
            set
            {
                  _fSubTime = value;
            }
         }
        #endregion

        #region 实际入场时间
        private DateTime _fActualEnterTime;

        /// <summary>
        /// 实际入场时间
        /// </summary>
        public  DateTime  ActualEnterTime
        {
            get
            {
                return  _fActualEnterTime;
            }
            set
            {
                  _fActualEnterTime = value;
            }
         }
        #endregion

        #region 时间出场时间
        private DateTime _fActualExitTime;

        /// <summary>
        /// 时间出场时间
        /// </summary>
        public  DateTime  ActualExitTime
        {
            get
            {
                return  _fActualExitTime;
            }
            set
            {
                  _fActualExitTime = value;
            }
         }
        #endregion

        #region 车位号
        private string _fCarPort;

        /// <summary>
        /// 车位号
        /// </summary>
        public  string  CarPort
        {
            get
            {
                return  _fCarPort;
            }
            set
            {
                  _fCarPort = value;
            }
         }
        #endregion

        #region 车位描述
        private string _fCarPortDesc;

        /// <summary>
        /// 车位描述
        /// </summary>
        public  string  CarPortDesc
        {
            get
            {
                return  _fCarPortDesc;
            }
            set
            {
                  _fCarPortDesc = value;
            }
         }
        #endregion

     }
}

