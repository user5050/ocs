using System;

/*
* 由自动生成工具完成
* 描述:[park_status]停车场状态
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Park
{
    /// <summary>
    /// [park_status]停车场状态
    /// </summary>
    [Serializable]
    public partial class ParkStatuDb
    {
        #region 停车场状态编号
        private int _fID;

        /// <summary>
        /// 停车场状态编号
        /// </summary>
        public  int  ID
        {
            get
            {
                return  _fID;
            }
            set
            {
                  _fID = value;
            }
         }
        #endregion

        #region 停车场编码
        private string _fParkCode;

        /// <summary>
        /// 停车场编码
        /// </summary>
        public  string  ParkCode
        {
            get
            {
                return  _fParkCode;
            }
            set
            {
                  _fParkCode = value;
            }
         }
        #endregion

        #region 停车场运行状态
        private int _fStatus;

        /// <summary>
        /// 停车场运行状态
        /// </summary>
        public  int  Status
        {
            get
            {
                return  _fStatus;
            }
            set
            {
                  _fStatus = value;
            }
         }
        #endregion

        #region 系统运行状态
        private int _fSystemStatus;

        /// <summary>
        /// 系统运行状态
        /// </summary>
        public  int  SystemStatus
        {
            get
            {
                return  _fSystemStatus;
            }
            set
            {
                  _fSystemStatus = value;
            }
         }
        #endregion

        #region 状态更新时间
        private DateTime _fEventTime;

        /// <summary>
        /// 状态更新时间
        /// </summary>
        public  DateTime  EventTime
        {
            get
            {
                return  _fEventTime;
            }
            set
            {
                  _fEventTime = value;
            }
         }
        #endregion

     }
}

