using System;

/*
* 由自动生成工具完成
* 描述:[park_lock]车位锁信息表
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Park
{
    /// <summary>
    /// [park_lock]车位锁信息表
    /// </summary>
    [Serializable]
    public partial class ParkLockDb
    {
        #region 车位锁信息编号
        private int _fLockId;

        /// <summary>
        /// 车位锁信息编号
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

        #region 绑定码
        private string _fBindNo;

        /// <summary>
        /// 绑定码
        /// </summary>
        public  string  BindNo
        {
            get
            {
                return  _fBindNo;
            }
            set
            {
                  _fBindNo = value;
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

        #region 录入时间
        private DateTime _fCreateTime;

        /// <summary>
        /// 录入时间
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

        #region 录入用户编号
        private int _fCreator;

        /// <summary>
        /// 录入用户编号
        /// </summary>
        public  int  Creator
        {
            get
            {
                return  _fCreator;
            }
            set
            {
                  _fCreator = value;
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

