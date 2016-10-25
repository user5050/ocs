using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Oms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class OmsFeedbackDb
    {
        #region 反馈类型 1:改进建议；2:支付问题；3:软件异常；4:月租车位；5:消息管理；6:其他问题
        private int _fType;

        /// <summary>
        /// 反馈类型 1:改进建议；2:支付问题；3:软件异常；4:月租车位；5:消息管理；6:其他问题
        /// </summary>
        public  int  Type
        {
            get
            {
                return  _fType;
            }
            set
            {
                  _fType = value;
            }
         }
        #endregion

        #region Id
        private int _fId;

        /// <summary>
        /// Id
        /// </summary>
        public  int  Id
        {
            get
            {
                return  _fId;
            }
            set
            {
                  _fId = value;
            }
         }
        #endregion

        #region 反馈来源 1:微信；2:app
        private int _fSource;

        /// <summary>
        /// 反馈来源 1:微信；2:app
        /// </summary>
        public  int  Source
        {
            get
            {
                return  _fSource;
            }
            set
            {
                  _fSource = value;
            }
         }
        #endregion

        #region 手机号
        private string _fMobile;

        /// <summary>
        /// 手机号
        /// </summary>
        public  string  Mobile
        {
            get
            {
                return  _fMobile;
            }
            set
            {
                  _fMobile = value;
            }
         }
        #endregion

        #region 反馈时间
        private DateTime _fFeedback_time;

        /// <summary>
        /// 反馈时间
        /// </summary>
        public  DateTime  Feedback_time
        {
            get
            {
                return  _fFeedback_time;
            }
            set
            {
                  _fFeedback_time = value;
            }
         }
        #endregion

        #region 版本号
        private string _fVersion_name;

        /// <summary>
        /// 版本号
        /// </summary>
        public  string  Version_name
        {
            get
            {
                return  _fVersion_name;
            }
            set
            {
                  _fVersion_name = value;
            }
         }
        #endregion

        #region 设备名称
        private string _fDevice_type;

        /// <summary>
        /// 设备名称
        /// </summary>
        public  string  Device_type
        {
            get
            {
                return  _fDevice_type;
            }
            set
            {
                  _fDevice_type = value;
            }
         }
        #endregion

        #region 网络类型
        private string _fNetwork_type;

        /// <summary>
        /// 网络类型
        /// </summary>
        public  string  Network_type
        {
            get
            {
                return  _fNetwork_type;
            }
            set
            {
                  _fNetwork_type = value;
            }
         }
        #endregion

        #region 反馈内容
        private string _fContent;

        /// <summary>
        /// 反馈内容
        /// </summary>
        public  string  Content
        {
            get
            {
                return  _fContent;
            }
            set
            {
                  _fContent = value;
            }
         }
        #endregion

        #region 1:已处理；0:未处理
        private int _fStatus;

        /// <summary>
        /// 1:已处理；0:未处理
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

        #region 最近修改时间
        private DateTime _fLast_modify_time;

        /// <summary>
        /// 最近修改时间
        /// </summary>
        public  DateTime  Last_modify_time
        {
            get
            {
                return  _fLast_modify_time;
            }
            set
            {
                  _fLast_modify_time = value;
            }
         }
        #endregion

     }
}

