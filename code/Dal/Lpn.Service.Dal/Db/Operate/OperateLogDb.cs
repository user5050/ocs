using System;

/*
* 由自动生成工具完成
* 描述:[operate_log]操作日志
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Operate
{
    /// <summary>
    /// [operate_log]操作日志
    /// </summary>
    [Serializable]
    public partial class OperateLogDb
    {
        #region 日志编号
        private int _fID;

        /// <summary>
        /// 日志编号
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

        #region 日志类型
        private string _fLogType;

        /// <summary>
        /// 日志类型
        /// </summary>
        public  string  LogType
        {
            get
            {
                return  _fLogType;
            }
            set
            {
                  _fLogType = value;
            }
         }
        #endregion

        #region 记录时间
        private DateTime _fLogTime;

        /// <summary>
        /// 记录时间
        /// </summary>
        public  DateTime  LogTime
        {
            get
            {
                return  _fLogTime;
            }
            set
            {
                  _fLogTime = value;
            }
         }
        #endregion

        #region 日志信息
        private string _fLogInfo;

        /// <summary>
        /// 日志信息
        /// </summary>
        public  string  LogInfo
        {
            get
            {
                return  _fLogInfo;
            }
            set
            {
                  _fLogInfo = value;
            }
         }
        #endregion

        #region 用户编号
        private int _fUserID;

        /// <summary>
        /// 用户编号
        /// </summary>
        public  int  UserID
        {
            get
            {
                return  _fUserID;
            }
            set
            {
                  _fUserID = value;
            }
         }
        #endregion

     }
}

