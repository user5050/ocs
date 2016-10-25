using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Sys;

/*
* 由自动生成工具完成
* 描述:[sys_user]管理用户信息 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Sys
{
    /// <summary>
    /// [sys_user]管理用户信息 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class SysUserDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from sysuser;";
        //新增插入语句
        protected const string SqlInsert = "insert into sysuser(`UserName`,`UserPwd`,`RealName`,`Tel`,`Mobile`,`Email`,`RoleID`,`Checked`,`Enabled`,`NickName`,`Img`,`Sex`,`UUID`,`DriverLicence`,`IOSToken`,`OpenID`,`RegTime`,`WeiXinRegTime`,`RegType`,`CreateTime`,`BindCarTime`,`City`) values(?UserName,?UserPwd,?RealName,?Tel,?Mobile,?Email,?RoleID,?Checked,?Enabled,?NickName,?Img,?Sex,?UUID,?DriverLicence,?IOSToken,?OpenID,?RegTime,?WeiXinRegTime,?RegType,?CreateTime,?BindCarTime,?City);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from sysuser where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update sysuser set `UserName`=?UserName,`UserPwd`=?UserPwd,`RealName`=?RealName,`Tel`=?Tel,`Mobile`=?Mobile,`Email`=?Email,`RoleID`=?RoleID,`Checked`=?Checked,`Enabled`=?Enabled,`NickName`=?NickName,`Img`=?Img,`Sex`=?Sex,`UUID`=?UUID,`DriverLicence`=?DriverLicence,`IOSToken`=?IOSToken,`OpenID`=?OpenID,`RegTime`=?RegTime,`WeiXinRegTime`=?WeiXinRegTime,`RegType`=?RegType,`CreateTime`=?CreateTime,`BindCarTime`=?BindCarTime,`City`=?City where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from sysuser  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamUserName = "?UserName";
        protected const string ParamUserPwd = "?UserPwd";
        protected const string ParamRealName = "?RealName";
        protected const string ParamTel = "?Tel";
        protected const string ParamMobile = "?Mobile";
        protected const string ParamEmail = "?Email";
        protected const string ParamRoleID = "?RoleID";
        protected const string ParamChecked = "?Checked";
        protected const string ParamEnabled = "?Enabled";
        protected const string ParamNickName = "?NickName";
        protected const string ParamImg = "?Img";
        protected const string ParamSex = "?Sex";
        protected const string ParamUUID = "?UUID";
        protected const string ParamDriverLicence = "?DriverLicence";
        protected const string ParamIOSToken = "?IOSToken";
        protected const string ParamOpenID = "?OpenID";
        protected const string ParamRegTime = "?RegTime";
        protected const string ParamWeiXinRegTime = "?WeiXinRegTime";
        protected const string ParamRegType = "?RegType";
        protected const string ParamCreateTime = "?CreateTime";
        protected const string ParamBindCarTime = "?BindCarTime";
        protected const string ParamCity = "?City";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of SysUserDb</returns>
        public static List<SysUserDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="sysuser">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(SysUserDb sysuser)
        {
            var param= GetInsertParams(sysuser);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">管理员编号</param> 
        /// <returns>SysUserDb</returns>
        public static SysUserDb  GetByPriKey(int id)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,id)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetByPriKey,param);

            //判断是否存在数据
            if (null != dr && dr.Rows.Count > 0)
            {
                return ConvertToObject(dr.Rows[0]);
            }

            return null;
        }
        #endregion

        #region 根据主键更新查询数据
        /// <summary>
        /// 根据主键更新查询数据
        /// </summary>
        /// <param name="sysuser">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(SysUserDb sysuser)
        {
            var param= GetUpdateParams(sysuser);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">管理员编号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(int id)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,id)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(SysUserDb sysuser)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,sysuser.ID),
                    new MySqlParameter(ParamUserName,sysuser.UserName),
                    new MySqlParameter(ParamUserPwd,sysuser.UserPwd),
                    new MySqlParameter(ParamRealName,sysuser.RealName),
                    new MySqlParameter(ParamTel,sysuser.Tel),
                    new MySqlParameter(ParamMobile,sysuser.Mobile),
                    new MySqlParameter(ParamEmail,sysuser.Email),
                    new MySqlParameter(ParamRoleID,sysuser.RoleID),
                    new MySqlParameter(ParamChecked,sysuser.Checked),
                    new MySqlParameter(ParamEnabled,sysuser.Enabled),
                    new MySqlParameter(ParamNickName,sysuser.NickName),
                    new MySqlParameter(ParamImg,sysuser.Img),
                    new MySqlParameter(ParamSex,sysuser.Sex),
                    new MySqlParameter(ParamUUID,sysuser.UUID),
                    new MySqlParameter(ParamDriverLicence,sysuser.DriverLicence),
                    new MySqlParameter(ParamIOSToken,sysuser.IOSToken),
                    new MySqlParameter(ParamOpenID,sysuser.OpenID),
                    new MySqlParameter(ParamRegTime,sysuser.RegTime),
                    new MySqlParameter(ParamWeiXinRegTime,sysuser.WeiXinRegTime),
                    new MySqlParameter(ParamRegType,sysuser.RegType),
                    new MySqlParameter(ParamCreateTime,sysuser.CreateTime),
                    new MySqlParameter(ParamBindCarTime,sysuser.BindCarTime),
                    new MySqlParameter(ParamCity,sysuser.City)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(SysUserDb sysuser)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUserName,sysuser.UserName),
                    new MySqlParameter(ParamUserPwd,sysuser.UserPwd),
                    new MySqlParameter(ParamRealName,sysuser.RealName),
                    new MySqlParameter(ParamTel,sysuser.Tel),
                    new MySqlParameter(ParamMobile,sysuser.Mobile),
                    new MySqlParameter(ParamEmail,sysuser.Email),
                    new MySqlParameter(ParamRoleID,sysuser.RoleID),
                    new MySqlParameter(ParamChecked,sysuser.Checked),
                    new MySqlParameter(ParamEnabled,sysuser.Enabled),
                    new MySqlParameter(ParamNickName,sysuser.NickName),
                    new MySqlParameter(ParamImg,sysuser.Img),
                    new MySqlParameter(ParamSex,sysuser.Sex),
                    new MySqlParameter(ParamUUID,sysuser.UUID),
                    new MySqlParameter(ParamDriverLicence,sysuser.DriverLicence),
                    new MySqlParameter(ParamIOSToken,sysuser.IOSToken),
                    new MySqlParameter(ParamOpenID,sysuser.OpenID),
                    new MySqlParameter(ParamRegTime,sysuser.RegTime),
                    new MySqlParameter(ParamWeiXinRegTime,sysuser.WeiXinRegTime),
                    new MySqlParameter(ParamRegType,sysuser.RegType),
                    new MySqlParameter(ParamCreateTime,sysuser.CreateTime),
                    new MySqlParameter(ParamBindCarTime,sysuser.BindCarTime),
                    new MySqlParameter(ParamCity,sysuser.City)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>SysUserDb</returns>
        public static SysUserDb  ConvertToObject(DataRow dr)
        {
            var data = new SysUserDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    UserName = DbChange.ToString(dr["UserName"]),
                    UserPwd = DbChange.ToString(dr["UserPwd"]),
                    RealName = DbChange.ToString(dr["RealName"]),
                    Tel = DbChange.ToString(dr["Tel"]),
                    Mobile = DbChange.ToString(dr["Mobile"]),
                    Email = DbChange.ToString(dr["Email"]),
                    RoleID = DbChange.ToInt(dr["RoleID"],0),
                    Checked = DbChange.ToInt(dr["Checked"],-1),
                    Enabled = DbChange.ToInt(dr["Enabled"],-1),
                    NickName = DbChange.ToString(dr["NickName"]),
                    Img = DbChange.ToString(dr["Img"]),
                    Sex = DbChange.ToString(dr["Sex"]),
                    UUID = DbChange.ToString(dr["UUID"]),
                    DriverLicence = DbChange.ToString(dr["DriverLicence"]),
                    IOSToken = DbChange.ToString(dr["IOSToken"]),
                    OpenID = DbChange.ToString(dr["OpenID"]),
                    RegTime = DbChange.ToDateTime(dr["RegTime"],DateTime.MinValue),
                    WeiXinRegTime = DbChange.ToDateTime(dr["WeiXinRegTime"],DateTime.MinValue),
                    RegType = DbChange.ToInt(dr["RegType"],0),
                    CreateTime = DbChange.ToDateTime(dr["CreateTime"],DateTime.MinValue),
                    BindCarTime = DbChange.ToDateTime(dr["BindCarTime"],DateTime.MinValue),
                    City = DbChange.ToString(dr["City"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of SysUserDb</returns>
        public static List<SysUserDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<SysUserDb>(); 
            if (null != dt && dt.Rows.Count > 0)
            {
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    datas.Add(ConvertToObject(dt.Rows[i]));
                }
            }

            return datas;
        }
        #endregion

     }
}
