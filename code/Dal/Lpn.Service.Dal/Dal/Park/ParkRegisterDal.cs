﻿using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Park;

/*
* 由自动生成工具完成
* 描述:[park_register]停车场注册信息 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Park
{
    /// <summary>
    /// [park_register]停车场注册信息 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ParkRegisterDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parkregister;";
        //新增插入语句
        protected const string SqlInsert = "insert into parkregister(`ParkCode`,`Mac`) values(?ParkCode,?Mac);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from parkregister where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update parkregister set `ParkCode`=?ParkCode,`Mac`=?Mac where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from parkregister  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamParkCode = "?ParkCode";
        protected const string ParamMac = "?Mac";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParkRegisterDb</returns>
        public static List<ParkRegisterDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parkregister">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParkRegisterDb parkregister)
        {
            var param= GetInsertParams(parkregister);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">停车场注册信息编号</param> 
        /// <returns>ParkRegisterDb</returns>
        public static ParkRegisterDb  GetByPriKey(int id)
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
        /// <param name="parkregister">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ParkRegisterDb parkregister)
        {
            var param= GetUpdateParams(parkregister);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">停车场注册信息编号</param> 
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
        public static MySqlParameter[]  GetUpdateParams(ParkRegisterDb parkregister)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,parkregister.ID),
                    new MySqlParameter(ParamParkCode,parkregister.ParkCode),
                    new MySqlParameter(ParamMac,parkregister.Mac)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParkRegisterDb parkregister)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkCode,parkregister.ParkCode),
                    new MySqlParameter(ParamMac,parkregister.Mac)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParkRegisterDb</returns>
        public static ParkRegisterDb  ConvertToObject(DataRow dr)
        {
            var data = new ParkRegisterDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    ParkCode = DbChange.ToString(dr["ParkCode"]),
                    Mac = DbChange.ToString(dr["Mac"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ParkRegisterDb</returns>
        public static List<ParkRegisterDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParkRegisterDb>(); 
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
