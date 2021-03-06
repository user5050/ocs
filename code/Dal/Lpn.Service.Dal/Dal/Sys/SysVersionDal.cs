﻿using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Sys;

/*
* 由自动生成工具完成
* 描述:[sys_versions]停车场版本管理 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Sys
{
    /// <summary>
    /// [sys_versions]停车场版本管理 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class SysVersionDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from sysversions;";
        //新增插入语句
        protected const string SqlInsert = "insert into sysversions(`ParkName`,`ParkCode`,`CurrentVersion`,`NewVersion`,`LastUpdateTime`,`LocationName`,`OperatorID`,`OperatorName`,`Mark`,`ExpireDate`,`RenewalLastTime`,`RenewalTimes`,`RenewalUser`) values(?ParkName,?ParkCode,?CurrentVersion,?NewVersion,?LastUpdateTime,?LocationName,?OperatorID,?OperatorName,?Mark,?ExpireDate,?RenewalLastTime,?RenewalTimes,?RenewalUser);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from sysversions where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update sysversions set `ParkName`=?ParkName,`ParkCode`=?ParkCode,`CurrentVersion`=?CurrentVersion,`NewVersion`=?NewVersion,`LastUpdateTime`=?LastUpdateTime,`LocationName`=?LocationName,`OperatorID`=?OperatorID,`OperatorName`=?OperatorName,`Mark`=?Mark,`ExpireDate`=?ExpireDate,`RenewalLastTime`=?RenewalLastTime,`RenewalTimes`=?RenewalTimes,`RenewalUser`=?RenewalUser where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from sysversions  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamParkName = "?ParkName";
        protected const string ParamParkCode = "?ParkCode";
        protected const string ParamCurrentVersion = "?CurrentVersion";
        protected const string ParamNewVersion = "?NewVersion";
        protected const string ParamLastUpdateTime = "?LastUpdateTime";
        protected const string ParamLocationName = "?LocationName";
        protected const string ParamOperatorID = "?OperatorID";
        protected const string ParamOperatorName = "?OperatorName";
        protected const string ParamMark = "?Mark";
        protected const string ParamExpireDate = "?ExpireDate";
        protected const string ParamRenewalLastTime = "?RenewalLastTime";
        protected const string ParamRenewalTimes = "?RenewalTimes";
        protected const string ParamRenewalUser = "?RenewalUser";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of SysVersionDb</returns>
        public static List<SysVersionDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="sysversion">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(SysVersionDb sysversion)
        {
            var param= GetInsertParams(sysversion);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">自增ID</param> 
        /// <returns>SysVersionDb</returns>
        public static SysVersionDb  GetByPriKey(int id)
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
        /// <param name="sysversion">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(SysVersionDb sysversion)
        {
            var param= GetUpdateParams(sysversion);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">自增ID</param> 
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
        public static MySqlParameter[]  GetUpdateParams(SysVersionDb sysversion)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,sysversion.ID),
                    new MySqlParameter(ParamParkName,sysversion.ParkName),
                    new MySqlParameter(ParamParkCode,sysversion.ParkCode),
                    new MySqlParameter(ParamCurrentVersion,sysversion.CurrentVersion),
                    new MySqlParameter(ParamNewVersion,sysversion.NewVersion),
                    new MySqlParameter(ParamLastUpdateTime,sysversion.LastUpdateTime),
                    new MySqlParameter(ParamLocationName,sysversion.LocationName),
                    new MySqlParameter(ParamOperatorID,sysversion.OperatorID),
                    new MySqlParameter(ParamOperatorName,sysversion.OperatorName),
                    new MySqlParameter(ParamMark,sysversion.Mark),
                    new MySqlParameter(ParamExpireDate,sysversion.ExpireDate),
                    new MySqlParameter(ParamRenewalLastTime,sysversion.RenewalLastTime),
                    new MySqlParameter(ParamRenewalTimes,sysversion.RenewalTimes),
                    new MySqlParameter(ParamRenewalUser,sysversion.RenewalUser)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(SysVersionDb sysversion)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkName,sysversion.ParkName),
                    new MySqlParameter(ParamParkCode,sysversion.ParkCode),
                    new MySqlParameter(ParamCurrentVersion,sysversion.CurrentVersion),
                    new MySqlParameter(ParamNewVersion,sysversion.NewVersion),
                    new MySqlParameter(ParamLastUpdateTime,sysversion.LastUpdateTime),
                    new MySqlParameter(ParamLocationName,sysversion.LocationName),
                    new MySqlParameter(ParamOperatorID,sysversion.OperatorID),
                    new MySqlParameter(ParamOperatorName,sysversion.OperatorName),
                    new MySqlParameter(ParamMark,sysversion.Mark),
                    new MySqlParameter(ParamExpireDate,sysversion.ExpireDate),
                    new MySqlParameter(ParamRenewalLastTime,sysversion.RenewalLastTime),
                    new MySqlParameter(ParamRenewalTimes,sysversion.RenewalTimes),
                    new MySqlParameter(ParamRenewalUser,sysversion.RenewalUser)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>SysVersionDb</returns>
        public static SysVersionDb  ConvertToObject(DataRow dr)
        {
            var data = new SysVersionDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    ParkName = DbChange.ToString(dr["ParkName"]),
                    ParkCode = DbChange.ToString(dr["ParkCode"]),
                    CurrentVersion = DbChange.ToString(dr["CurrentVersion"]),
                    NewVersion = DbChange.ToString(dr["NewVersion"]),
                    LastUpdateTime = DbChange.ToString(dr["LastUpdateTime"]),
                    LocationName = DbChange.ToString(dr["LocationName"]),
                    OperatorID = DbChange.ToInt(dr["OperatorID"],0),
                    OperatorName = DbChange.ToString(dr["OperatorName"]),
                    Mark = DbChange.ToString(dr["Mark"]),
                    ExpireDate = DbChange.ToString(dr["ExpireDate"]),
                    RenewalLastTime = DbChange.ToString(dr["RenewalLastTime"]),
                    RenewalTimes = DbChange.ToInt(dr["RenewalTimes"],0),
                    RenewalUser = DbChange.ToString(dr["RenewalUser"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of SysVersionDb</returns>
        public static List<SysVersionDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<SysVersionDb>(); 
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
