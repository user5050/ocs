using System;

/*
* 由自动生成工具完成
* 描述:[offline_project]离线项目管理
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Offline
{
    /// <summary>
    /// [offline_project]离线项目管理
    /// </summary>
    [Serializable]
    public partial class OfflineProjectDb
    {
        #region 自增编号
        private int _fID;

        /// <summary>
        /// 自增编号
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

        #region 停车场名称
        private string _fParkName;

        /// <summary>
        /// 停车场名称
        /// </summary>
        public  string  ParkName
        {
            get
            {
                return  _fParkName;
            }
            set
            {
                  _fParkName = value;
            }
         }
        #endregion

        #region 项目编码
        private string _fProjectCode;

        /// <summary>
        /// 项目编码
        /// </summary>
        public  string  ProjectCode
        {
            get
            {
                return  _fProjectCode;
            }
            set
            {
                  _fProjectCode = value;
            }
         }
        #endregion

        #region 项目名称
        private string _fProjectName;

        /// <summary>
        /// 项目名称
        /// </summary>
        public  string  ProjectName
        {
            get
            {
                return  _fProjectName;
            }
            set
            {
                  _fProjectName = value;
            }
         }
        #endregion

        #region 注册号
        private string _fRegisterNo;

        /// <summary>
        /// 注册号
        /// </summary>
        public  string  RegisterNo
        {
            get
            {
                return  _fRegisterNo;
            }
            set
            {
                  _fRegisterNo = value;
            }
         }
        #endregion

        #region 过期日期
        private DateTime _fExpireDate;

        /// <summary>
        /// 过期日期
        /// </summary>
        public  DateTime  ExpireDate
        {
            get
            {
                return  _fExpireDate;
            }
            set
            {
                  _fExpireDate = value;
            }
         }
        #endregion

        #region 注册码
        private string _fRegisterCode;

        /// <summary>
        /// 注册码
        /// </summary>
        public  string  RegisterCode
        {
            get
            {
                return  _fRegisterCode;
            }
            set
            {
                  _fRegisterCode = value;
            }
         }
        #endregion

        #region 操作员ID
        private int _fOperatorId;

        /// <summary>
        /// 操作员ID
        /// </summary>
        public  int  OperatorId
        {
            get
            {
                return  _fOperatorId;
            }
            set
            {
                  _fOperatorId = value;
            }
         }
        #endregion

        #region 最后一次操作时间
        private DateTime _fOperatetime;

        /// <summary>
        /// 最后一次操作时间
        /// </summary>
        public  DateTime  Operatetime
        {
            get
            {
                return  _fOperatetime;
            }
            set
            {
                  _fOperatetime = value;
            }
         }
        #endregion

        #region 项目版本号
        private string _fProjectversion;

        /// <summary>
        /// 项目版本号
        /// </summary>
        public  string  Projectversion
        {
            get
            {
                return  _fProjectversion;
            }
            set
            {
                  _fProjectversion = value;
            }
         }
        #endregion

     }
}

