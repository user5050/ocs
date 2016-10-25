using System;

/*
* 由自动生成工具完成
* 描述:[sys_user]管理用户信息
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Sys
{
    /// <summary>
    /// [sys_user]管理用户信息
    /// </summary>
    [Serializable]
    public partial class SysUserDb
    {
        #region 管理员编号
        private int _fID;

        /// <summary>
        /// 管理员编号
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

        #region 用户名
        private string _fUserName;

        /// <summary>
        /// 用户名
        /// </summary>
        public  string  UserName
        {
            get
            {
                return  _fUserName;
            }
            set
            {
                  _fUserName = value;
            }
         }
        #endregion

        #region 密码
        private string _fUserPwd;

        /// <summary>
        /// 密码
        /// </summary>
        public  string  UserPwd
        {
            get
            {
                return  _fUserPwd;
            }
            set
            {
                  _fUserPwd = value;
            }
         }
        #endregion

        #region 真实姓名
        private string _fRealName;

        /// <summary>
        /// 真实姓名
        /// </summary>
        public  string  RealName
        {
            get
            {
                return  _fRealName;
            }
            set
            {
                  _fRealName = value;
            }
         }
        #endregion

        #region 电话
        private string _fTel;

        /// <summary>
        /// 电话
        /// </summary>
        public  string  Tel
        {
            get
            {
                return  _fTel;
            }
            set
            {
                  _fTel = value;
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

        #region 邮箱地址
        private string _fEmail;

        /// <summary>
        /// 邮箱地址
        /// </summary>
        public  string  Email
        {
            get
            {
                return  _fEmail;
            }
            set
            {
                  _fEmail = value;
            }
         }
        #endregion

        #region 角色权限编号
        private int _fRoleID;

        /// <summary>
        /// 角色权限编号
        /// </summary>
        public  int  RoleID
        {
            get
            {
                return  _fRoleID;
            }
            set
            {
                  _fRoleID = value;
            }
         }
        #endregion

        #region 是否审核
        private int _fChecked;

        /// <summary>
        /// 是否审核
        /// </summary>
        public  int  Checked
        {
            get
            {
                return  _fChecked;
            }
            set
            {
                  _fChecked = value;
            }
         }
        #endregion

        #region 是否启用
        private int _fEnabled;

        /// <summary>
        /// 是否启用
        /// </summary>
        public  int  Enabled
        {
            get
            {
                return  _fEnabled;
            }
            set
            {
                  _fEnabled = value;
            }
         }
        #endregion

        #region 昵称
        private string _fNickName;

        /// <summary>
        /// 昵称
        /// </summary>
        public  string  NickName
        {
            get
            {
                return  _fNickName;
            }
            set
            {
                  _fNickName = value;
            }
         }
        #endregion

        #region 头像地址
        private string _fImg;

        /// <summary>
        /// 头像地址
        /// </summary>
        public  string  Img
        {
            get
            {
                return  _fImg;
            }
            set
            {
                  _fImg = value;
            }
         }
        #endregion

        #region 性别
        private string _fSex;

        /// <summary>
        /// 性别
        /// </summary>
        public  string  Sex
        {
            get
            {
                return  _fSex;
            }
            set
            {
                  _fSex = value;
            }
         }
        #endregion

        #region 手机唯一标识
        private string _fUUID;

        /// <summary>
        /// 手机唯一标识
        /// </summary>
        public  string  UUID
        {
            get
            {
                return  _fUUID;
            }
            set
            {
                  _fUUID = value;
            }
         }
        #endregion

        #region 驾驶证号
        private string _fDriverLicence;

        /// <summary>
        /// 驾驶证号
        /// </summary>
        public  string  DriverLicence
        {
            get
            {
                return  _fDriverLicence;
            }
            set
            {
                  _fDriverLicence = value;
            }
         }
        #endregion

        #region 苹果口令
        private string _fIOSToken;

        /// <summary>
        /// 苹果口令
        /// </summary>
        public  string  IOSToken
        {
            get
            {
                return  _fIOSToken;
            }
            set
            {
                  _fIOSToken = value;
            }
         }
        #endregion

        #region 微信口令
        private string _fOpenID;

        /// <summary>
        /// 微信口令
        /// </summary>
        public  string  OpenID
        {
            get
            {
                return  _fOpenID;
            }
            set
            {
                  _fOpenID = value;
            }
         }
        #endregion

        #region 账号注册时间
        private DateTime _fRegTime;

        /// <summary>
        /// 账号注册时间
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

        #region 微信公众号绑定时间
        private DateTime _fWeiXinRegTime;

        /// <summary>
        /// 微信公众号绑定时间
        /// </summary>
        public  DateTime  WeiXinRegTime
        {
            get
            {
                return  _fWeiXinRegTime;
            }
            set
            {
                  _fWeiXinRegTime = value;
            }
         }
        #endregion

        #region 注册设备类型(1 IOS 2 安卓 3 IOS微信  4  安卓微信
        private int _fRegType;

        /// <summary>
        /// 注册设备类型(1 IOS 2 安卓 3 IOS微信  4  安卓微信
        /// </summary>
        public  int  RegType
        {
            get
            {
                return  _fRegType;
            }
            set
            {
                  _fRegType = value;
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

        #region 首次绑定车牌时间
        private DateTime _fBindCarTime;

        /// <summary>
        /// 首次绑定车牌时间
        /// </summary>
        public  DateTime  BindCarTime
        {
            get
            {
                return  _fBindCarTime;
            }
            set
            {
                  _fBindCarTime = value;
            }
         }
        #endregion

        #region 所在城市
        private string _fCity;

        /// <summary>
        /// 所在城市
        /// </summary>
        public  string  City
        {
            get
            {
                return  _fCity;
            }
            set
            {
                  _fCity = value;
            }
         }
        #endregion

     }
}

