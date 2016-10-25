using System;

/*
* 由自动生成工具完成
* 描述:[park_lock_mamange]车位锁管理
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Park
{
    /// <summary>
    /// [park_lock_mamange]车位锁管理
    /// </summary>
    [Serializable]
    public partial class ParkLockMamangeDb
    {
        #region 车位锁管理编号
        private int _fID;

        /// <summary>
        /// 车位锁管理编号
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

        #region 车位锁ID
        private int _fLockId;

        /// <summary>
        /// 车位锁ID
        /// </summary>
        public  int  LockId
        {
            get
            {
                return  _fLockId;
            }
            set
            {
                  _fLockId = value;
            }
         }
        #endregion

        #region 用户编号
        private int _fBindUserId;

        /// <summary>
        /// 用户编号
        /// </summary>
        public  int  BindUserId
        {
            get
            {
                return  _fBindUserId;
            }
            set
            {
                  _fBindUserId = value;
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

        #region 客户端类型
        private int _fClientType;

        /// <summary>
        /// 客户端类型
        /// </summary>
        public  int  ClientType
        {
            get
            {
                return  _fClientType;
            }
            set
            {
                  _fClientType = value;
            }
         }
        #endregion

     }
}

