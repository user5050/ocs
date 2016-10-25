using System;

/*
* 由自动生成工具完成
* 描述:VIEW
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db
{
    /// <summary>
    /// VIEW
    /// </summary>
    [Serializable]
    public partial class VsysversionDb
    {
        #region 停车场编码
        private string _fParkcode;

        /// <summary>
        /// 停车场编码
        /// </summary>
        public  string  Parkcode
        {
            get
            {
                return  _fParkcode;
            }
            set
            {
                  _fParkcode = value;
            }
         }
        #endregion

        #region 停车场名称
        private string _fParkname;

        /// <summary>
        /// 停车场名称
        /// </summary>
        public  string  Parkname
        {
            get
            {
                return  _fParkname;
            }
            set
            {
                  _fParkname = value;
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
        private int _fOperatorid;

        /// <summary>
        /// 操作员ID
        /// </summary>
        public  int  Operatorid
        {
            get
            {
                return  _fOperatorid;
            }
            set
            {
                  _fOperatorid = value;
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

        #region 自增ID
        private int _fSid;

        /// <summary>
        /// 自增ID
        /// </summary>
        public  int  Sid
        {
            get
            {
                return  _fSid;
            }
            set
            {
                  _fSid = value;
            }
         }
        #endregion

        #region 停车场编号
        private int _fId;

        /// <summary>
        /// 停车场编号
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

        #region Payed
        private string _fPayed;

        /// <summary>
        /// Payed
        /// </summary>
        public  string  Payed
        {
            get
            {
                return  _fPayed;
            }
            set
            {
                  _fPayed = value;
            }
         }
        #endregion

     }
}

