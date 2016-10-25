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
    public partial class ParklockmangeviewDb
    {
        #region 车位号
        private string _fParkLocation;

        /// <summary>
        /// 车位号
        /// </summary>
        public  string  ParkLocation
        {
            get
            {
                return  _fParkLocation;
            }
            set
            {
                  _fParkLocation = value;
            }
         }
        #endregion

        #region 车位锁名称
        private string _fLockName;

        /// <summary>
        /// 车位锁名称
        /// </summary>
        public  string  LockName
        {
            get
            {
                return  _fLockName;
            }
            set
            {
                  _fLockName = value;
            }
         }
        #endregion

        #region 创建时间
        private DateTime _fCreateTime;

        /// <summary>
        /// 创建时间
        /// </summary>
        public  DateTime  CreateTime
        {
            get
            {
                return  _fCreateTime;
            }
            set
            {
                  _fCreateTime = value;
            }
         }
        #endregion

        #region 状态
        private int _fStatus;

        /// <summary>
        /// 状态
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

        #region 提交者
        private int _fConfirmUser;

        /// <summary>
        /// 提交者
        /// </summary>
        public  int  ConfirmUser
        {
            get
            {
                return  _fConfirmUser;
            }
            set
            {
                  _fConfirmUser = value;
            }
         }
        #endregion

        #region 车位锁编码
        private string _fLockCode;

        /// <summary>
        /// 车位锁编码
        /// </summary>
        public  string  LockCode
        {
            get
            {
                return  _fLockCode;
            }
            set
            {
                  _fLockCode = value;
            }
         }
        #endregion

        #region 提取码
        private string _fLockRandomCode;

        /// <summary>
        /// 提取码
        /// </summary>
        public  string  LockRandomCode
        {
            get
            {
                return  _fLockRandomCode;
            }
            set
            {
                  _fLockRandomCode = value;
            }
         }
        #endregion

        #region 用户名
        private string _fUsername;

        /// <summary>
        /// 用户名
        /// </summary>
        public  string  Username
        {
            get
            {
                return  _fUsername;
            }
            set
            {
                  _fUsername = value;
            }
         }
        #endregion

        #region 车位锁管理编号
        private int _fId;

        /// <summary>
        /// 车位锁管理编号
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

     }
}

