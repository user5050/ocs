﻿using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Data;

/*
* 由自动生成工具完成
* 描述:[data_statistics]快速出场统计信息 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Data
{
    /// <summary>
    /// [data_statistics]快速出场统计信息 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class DataStatisticDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from datastatistics;";
        //新增插入语句
        protected const string SqlInsert = "insert into datastatistics(`ID`,`OnCount`,`OffCount`) values(?ID,?OnCount,?OffCount);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from datastatistics where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update datastatistics set `OnCount`=?OnCount,`OffCount`=?OffCount where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from datastatistics  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamOnCount = "?OnCount";
        protected const string ParamOffCount = "?OffCount";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of DataStatisticDb</returns>
        public static List<DataStatisticDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="datastatistic">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(DataStatisticDb datastatistic)
        {
            var param= GetInsertParams(datastatistic);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">快速出场统计信息编号</param> 
        /// <returns>DataStatisticDb</returns>
        public static DataStatisticDb  GetByPriKey(int id)
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
        /// <param name="datastatistic">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(DataStatisticDb datastatistic)
        {
            var param= GetUpdateParams(datastatistic);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">快速出场统计信息编号</param> 
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
        public static MySqlParameter[]  GetUpdateParams(DataStatisticDb datastatistic)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,datastatistic.ID),
                    new MySqlParameter(ParamOnCount,datastatistic.OnCount),
                    new MySqlParameter(ParamOffCount,datastatistic.OffCount)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(DataStatisticDb datastatistic)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,datastatistic.ID),
                    new MySqlParameter(ParamOnCount,datastatistic.OnCount),
                    new MySqlParameter(ParamOffCount,datastatistic.OffCount)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>DataStatisticDb</returns>
        public static DataStatisticDb  ConvertToObject(DataRow dr)
        {
            var data = new DataStatisticDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    OnCount = DbChange.ToInt(dr["OnCount"],0),
                    OffCount = DbChange.ToInt(dr["OffCount"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of DataStatisticDb</returns>
        public static List<DataStatisticDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<DataStatisticDb>(); 
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
