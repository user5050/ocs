using System;

/*
* 由自动生成工具完成
* 描述:[sys_role]角色权限信息
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Sys
{
    /// <summary>
    /// [sys_role]角色权限信息
    /// </summary>
    [Serializable]
    public partial class SysRoleDb
    {
        #region 角色权限编号
        private int _fID;

        /// <summary>
        /// 角色权限编号
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

        #region 角色名称
        private string _fRoleName;

        /// <summary>
        /// 角色名称
        /// </summary>
        public  string  RoleName
        {
            get
            {
                return  _fRoleName;
            }
            set
            {
                  _fRoleName = value;
            }
         }
        #endregion

     }
}

