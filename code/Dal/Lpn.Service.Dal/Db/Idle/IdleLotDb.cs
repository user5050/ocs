using System;

/*
* 由自动生成工具完成
* 描述:[idle_lots]空闲泊位
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Idle
{
    /// <summary>
    /// [idle_lots]空闲泊位
    /// </summary>
    [Serializable]
    public partial class IdleLotDb
    {
        #region 空闲泊位编号
        private int _fID;

        /// <summary>
        /// 空闲泊位编号
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

        #region 对外经营泊位空闲数
        private int _fOperateCount;

        /// <summary>
        /// 对外经营泊位空闲数
        /// </summary>
        public  int  OperateCount
        {
            get
            {
                return  _fOperateCount;
            }
            set
            {
                  _fOperateCount = value;
            }
         }
        #endregion

        #region VIP泊位空闲数
        private int _fVipCount;

        /// <summary>
        /// VIP泊位空闲数
        /// </summary>
        public  int  VipCount
        {
            get
            {
                return  _fVipCount;
            }
            set
            {
                  _fVipCount = value;
            }
         }
        #endregion

        #region 发生时间
        private DateTime _fEventTime;

        /// <summary>
        /// 发生时间
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

