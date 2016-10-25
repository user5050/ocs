using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Sys;

/*
* 由自动生成工具完成
* 描述:[sys_moudule]Web权限模块 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Sys
{
    /// <summary>
    /// [sys_moudule]Web权限模块 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class SysMouduleDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from sysmoudule;";
        //新增插入语句
        protected const string SqlInsert = "insert into sysmoudule(`PID`,`RoleID`,`MouduleCode`,`MouduleName`,`MouduleUrl`) values(?PID,?RoleID,?MouduleCode,?MouduleName,?MouduleUrl);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from sysmoudule where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update sysmoudule set `PID`=?PID,`RoleID`=?RoleID,`MouduleCode`=?MouduleCode,`MouduleName`=?MouduleName,`MouduleUrl`=?MouduleUrl where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from sysmoudule  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamPID = "?PID";
        protected const string ParamRoleID = "?RoleID";
        protected const string ParamMouduleCode = "?MouduleCode";
        protected const string ParamMouduleName = "?MouduleName";
        protected const string ParamMouduleUrl = "?MouduleUrl";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of SysMouduleDb</returns>
        public static List<SysMouduleDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="sysmoudule">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(SysMouduleDb sysmoudule)
        {
            var param= GetInsertParams(sysmoudule);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">模块编号</param> 
        /// <returns>SysMouduleDb</returns>
        public static SysMouduleDb  GetByPriKey(int id)
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
        /// <param name="sysmoudule">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(SysMouduleDb sysmoudule)
        {
            var param= GetUpdateParams(sysmoudule);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">模块编号</param> 
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
        public static MySqlParameter[]  GetUpdateParams(SysMouduleDb sysmoudule)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,sysmoudule.ID),
                    new MySqlParameter(ParamPID,sysmoudule.PID),
                    new MySqlParameter(ParamRoleID,sysmoudule.RoleID),
                    new MySqlParameter(ParamMouduleCode,sysmoudule.MouduleCode),
                    new MySqlParameter(ParamMouduleName,sysmoudule.MouduleName),
                    new MySqlParameter(ParamMouduleUrl,sysmoudule.MouduleUrl)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(SysMouduleDb sysmoudule)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamPID,sysmoudule.PID),
                    new MySqlParameter(ParamRoleID,sysmoudule.RoleID),
                    new MySqlParameter(ParamMouduleCode,sysmoudule.MouduleCode),
                    new MySqlParameter(ParamMouduleName,sysmoudule.MouduleName),
                    new MySqlParameter(ParamMouduleUrl,sysmoudule.MouduleUrl)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>SysMouduleDb</returns>
        public static SysMouduleDb  ConvertToObject(DataRow dr)
        {
            var data = new SysMouduleDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    PID = DbChange.ToInt(dr["PID"],0),
                    RoleID = DbChange.ToString(dr["RoleID"]),
                    MouduleCode = DbChange.ToString(dr["MouduleCode"]),
                    MouduleName = DbChange.ToString(dr["MouduleName"]),
                    MouduleUrl = DbChange.ToString(dr["MouduleUrl"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of SysMouduleDb</returns>
        public static List<SysMouduleDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<SysMouduleDb>(); 
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
