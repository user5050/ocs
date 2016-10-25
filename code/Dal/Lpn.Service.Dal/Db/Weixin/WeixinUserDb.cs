using System;

/*
* 由自动生成工具完成
* 描述:微信用户表
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Weixin
{
    /// <summary>
    /// 微信用户表
    /// </summary>
    [Serializable]
    public partial class WeixinUserDb
    {
        #region 微信用户编号
        private int _fID;

        /// <summary>
        /// 微信用户编号
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

        #region 用户编号
        private int _fUID;

        /// <summary>
        /// 用户编号
        /// </summary>
        public  int  UID
        {
            get
            {
                return  _fUID;
            }
            set
            {
                  _fUID = value;
            }
         }
        #endregion

        #region 用户模板权限
        private string _fUserName;

        /// <summary>
        /// 用户模板权限
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

        #region 微信口令
        private string _fCode;

        /// <summary>
        /// 微信口令
        /// </summary>
        public  string  Code
        {
            get
            {
                return  _fCode;
            }
            set
            {
                  _fCode = value;
            }
         }
        #endregion

        #region 绑定时间
        private DateTime _fOperateDate;

        /// <summary>
        /// 绑定时间
        /// </summary>
        public  DateTime  OperateDate
        {
            get
            {
                return  _fOperateDate;
            }
            set
            {
                  _fOperateDate = value;
            }
         }
        #endregion

     }
}

