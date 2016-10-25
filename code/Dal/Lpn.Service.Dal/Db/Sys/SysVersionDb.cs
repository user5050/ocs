using System;

/*
* 由自动生成工具完成
* 描述:[sys_versions]停车场版本管理
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Sys
{
    /// <summary>
    /// [sys_versions]停车场版本管理
    /// </summary>
    [Serializable]
    public partial class SysVersionDb
    {
        #region 自增ID
        private int _fID;

        /// <summary>
        /// 自增ID
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

        #region 当前版本号
        private string _fCurrentVersion;

        /// <summary>
        /// 当前版本号
        /// </summary>
        public  string  CurrentVersion
        {
            get
            {
                return  _fCurrentVersion;
            }
            set
            {
                  _fCurrentVersion = value;
            }
         }
        #endregion

        #region 待升级版本号
        private string _fNewVersion;

        /// <summary>
        /// 待升级版本号
        /// </summary>
        public  string  NewVersion
        {
            get
            {
                return  _fNewVersion;
            }
            set
            {
                  _fNewVersion = value;
            }
         }
        #endregion

        #region 最后一次升级时间
        private string _fLastUpdateTime;

        /// <summary>
        /// 最后一次升级时间
        /// </summary>
        public  string  LastUpdateTime
        {
            get
            {
                return  _fLastUpdateTime;
            }
            set
            {
                  _fLastUpdateTime = value;
            }
         }
        #endregion

        #region 当前版本号
        private string _fLocationName;

        /// <summary>
        /// 当前版本号
        /// </summary>
        public  string  LocationName
        {
            get
            {
                return  _fLocationName;
            }
            set
            {
                  _fLocationName = value;
            }
         }
        #endregion

        #region 操作员ID
        private int _fOperatorID;

        /// <summary>
        /// 操作员ID
        /// </summary>
        public  int  OperatorID
        {
            get
            {
                return  _fOperatorID;
            }
            set
            {
                  _fOperatorID = value;
            }
         }
        #endregion

        #region 操作员名称
        private string _fOperatorName;

        /// <summary>
        /// 操作员名称
        /// </summary>
        public  string  OperatorName
        {
            get
            {
                return  _fOperatorName;
            }
            set
            {
                  _fOperatorName = value;
            }
         }
        #endregion

        #region 备注
        private string _fMark;

        /// <summary>
        /// 备注
        /// </summary>
        public  string  Mark
        {
            get
            {
                return  _fMark;
            }
            set
            {
                  _fMark = value;
            }
         }
        #endregion

        #region 过期时间
        private string _fExpireDate;

        /// <summary>
        /// 过期时间
        /// </summary>
        public  string  ExpireDate
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

        #region RenewalLastTime
        private string _fRenewalLastTime;

        /// <summary>
        /// RenewalLastTime
        /// </summary>
        public  string  RenewalLastTime
        {
            get
            {
                return  _fRenewalLastTime;
            }
            set
            {
                  _fRenewalLastTime = value;
            }
         }
        #endregion

        #region RenewalTimes
        private int _fRenewalTimes;

        /// <summary>
        /// RenewalTimes
        /// </summary>
        public  int  RenewalTimes
        {
            get
            {
                return  _fRenewalTimes;
            }
            set
            {
                  _fRenewalTimes = value;
            }
         }
        #endregion

        #region RenewalUser
        private string _fRenewalUser;

        /// <summary>
        /// RenewalUser
        /// </summary>
        public  string  RenewalUser
        {
            get
            {
                return  _fRenewalUser;
            }
            set
            {
                  _fRenewalUser = value;
            }
         }
        #endregion

     }
}

