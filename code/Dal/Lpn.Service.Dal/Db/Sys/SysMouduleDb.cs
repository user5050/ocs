using System;

/*
* 由自动生成工具完成
* 描述:[sys_moudule]Web权限模块
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Sys
{
    /// <summary>
    /// [sys_moudule]Web权限模块
    /// </summary>
    [Serializable]
    public partial class SysMouduleDb
    {
        #region 模块编号
        private int _fID;

        /// <summary>
        /// 模块编号
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

        #region 父模块编号
        private int _fPID;

        /// <summary>
        /// 父模块编号
        /// </summary>
        public  int  PID
        {
            get
            {
                return  _fPID;
            }
            set
            {
                  _fPID = value;
            }
         }
        #endregion

        #region 角色权限编号
        private string _fRoleID;

        /// <summary>
        /// 角色权限编号
        /// </summary>
        public  string  RoleID
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

        #region 模块编码
        private string _fMouduleCode;

        /// <summary>
        /// 模块编码
        /// </summary>
        public  string  MouduleCode
        {
            get
            {
                return  _fMouduleCode;
            }
            set
            {
                  _fMouduleCode = value;
            }
         }
        #endregion

        #region 模块名称
        private string _fMouduleName;

        /// <summary>
        /// 模块名称
        /// </summary>
        public  string  MouduleName
        {
            get
            {
                return  _fMouduleName;
            }
            set
            {
                  _fMouduleName = value;
            }
         }
        #endregion

        #region 模块链接
        private string _fMouduleUrl;

        /// <summary>
        /// 模块链接
        /// </summary>
        public  string  MouduleUrl
        {
            get
            {
                return  _fMouduleUrl;
            }
            set
            {
                  _fMouduleUrl = value;
            }
         }
        #endregion

     }
}

