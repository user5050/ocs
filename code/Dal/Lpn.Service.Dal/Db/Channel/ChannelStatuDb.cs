using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Channel
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class ChannelStatuDb
    {
        #region ParkId
        private int _fParkId;

        /// <summary>
        /// ParkId
        /// </summary>
        public  int  ParkId
        {
            get
            {
                return  _fParkId;
            }
            set
            {
                  _fParkId = value;
            }
         }
        #endregion

        #region 通道ID
        private int _fChannelId;

        /// <summary>
        /// 通道ID
        /// </summary>
        public  int  ChannelId
        {
            get
            {
                return  _fChannelId;
            }
            set
            {
                  _fChannelId = value;
            }
         }
        #endregion

        #region 通道名称
        private string _fChannelName;

        /// <summary>
        /// 通道名称
        /// </summary>
        public  string  ChannelName
        {
            get
            {
                return  _fChannelName;
            }
            set
            {
                  _fChannelName = value;
            }
         }
        #endregion

        #region 工作站最后一次在线时间
        private DateTime _fWSLastOnline;

        /// <summary>
        /// 工作站最后一次在线时间
        /// </summary>
        public  DateTime  WSLastOnline
        {
            get
            {
                return  _fWSLastOnline;
            }
            set
            {
                  _fWSLastOnline = value;
            }
         }
        #endregion

        #region 工作站名称
        private string _fWSName;

        /// <summary>
        /// 工作站名称
        /// </summary>
        public  string  WSName
        {
            get
            {
                return  _fWSName;
            }
            set
            {
                  _fWSName = value;
            }
         }
        #endregion

        #region 摄像机状态
        private int _fCameraStatus;

        /// <summary>
        /// 摄像机状态
        /// </summary>
        public  int  CameraStatus
        {
            get
            {
                return  _fCameraStatus;
            }
            set
            {
                  _fCameraStatus = value;
            }
         }
        #endregion

        #region 道闸状态
        private int _fChannelStatus;

        /// <summary>
        /// 道闸状态
        /// </summary>
        public  int  ChannelStatus
        {
            get
            {
                return  _fChannelStatus;
            }
            set
            {
                  _fChannelStatus = value;
            }
         }
        #endregion

        #region 语音板状态
        private int _fVoiceStatus;

        /// <summary>
        /// 语音板状态
        /// </summary>
        public  int  VoiceStatus
        {
            get
            {
                return  _fVoiceStatus;
            }
            set
            {
                  _fVoiceStatus = value;
            }
         }
        #endregion

        #region 条屏状态
        private int _fScreenStatus;

        /// <summary>
        /// 条屏状态
        /// </summary>
        public  int  ScreenStatus
        {
            get
            {
                return  _fScreenStatus;
            }
            set
            {
                  _fScreenStatus = value;
            }
         }
        #endregion

        #region 满位屏状态
        private int _fFullScrennStatus;

        /// <summary>
        /// 满位屏状态
        /// </summary>
        public  int  FullScrennStatus
        {
            get
            {
                return  _fFullScrennStatus;
            }
            set
            {
                  _fFullScrennStatus = value;
            }
         }
        #endregion

        #region 工作站状态
        private int _fWSStatus;

        /// <summary>
        /// 工作站状态
        /// </summary>
        public  int  WSStatus
        {
            get
            {
                return  _fWSStatus;
            }
            set
            {
                  _fWSStatus = value;
            }
         }
        #endregion

        #region 摄像机最后在线时间
        private DateTime _fCameraLastOnline;

        /// <summary>
        /// 摄像机最后在线时间
        /// </summary>
        public  DateTime  CameraLastOnline
        {
            get
            {
                return  _fCameraLastOnline;
            }
            set
            {
                  _fCameraLastOnline = value;
            }
         }
        #endregion

     }
}

