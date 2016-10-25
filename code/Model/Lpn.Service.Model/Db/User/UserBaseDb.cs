using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Model.Db.User
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class UserBaseDb
    {
        #region Id
        private string _fId;

        /// <summary>
        /// Id
        /// </summary>
        public  string  Id
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

        #region 头像地址
        private string _fHead;

        /// <summary>
        /// 头像地址
        /// </summary>
        public  string  Head
        {
            get
            {
                return  _fHead;
            }
            set
            {
                  _fHead = value;
            }
         }
        #endregion

        #region 昵称
        private string _fName;

        /// <summary>
        /// 昵称
        /// </summary>
        public  string  Name
        {
            get
            {
                return  _fName;
            }
            set
            {
                  _fName = value;
            }
         }
        #endregion

        #region 手机号码
        private string _fMobile;

        /// <summary>
        /// 手机号码
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

        #region 客户端类型(1andriod2ios)
        private int _fClientType;

        /// <summary>
        /// 客户端类型(1andriod2ios)
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

        #region 设备标识
        private string _fDeviceToken;

        /// <summary>
        /// 设备标识
        /// </summary>
        public  string  DeviceToken
        {
            get
            {
                return  _fDeviceToken;
            }
            set
            {
                  _fDeviceToken = value;
            }
         }
        #endregion

        #region 注册时间
        private DateTime _fRegTime;

        /// <summary>
        /// 注册时间
        /// </summary>
        public  DateTime  RegTime
        {
            get
            {
                return  _fRegTime;
            }
            set
            {
                  _fRegTime = value;
            }
         }
        #endregion

        #region 状态(0无效1有效)
        private int _fState;

        /// <summary>
        /// 状态(0无效1有效)
        /// </summary>
        public  int  State
        {
            get
            {
                return  _fState;
            }
            set
            {
                  _fState = value;
            }
         }
        #endregion

     }
}

