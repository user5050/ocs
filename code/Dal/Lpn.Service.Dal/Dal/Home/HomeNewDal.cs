﻿using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Model.Db.Home;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Dal.Dal.Home
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    [Serializable]
    public partial class HomeNewDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from home_news;";
        //新增插入语句
        protected const string SqlInsert = "insert into home_news(`Title`,`Content`,`Type`,`StartTime`,`ExpiredTime`,`RowTime`) values(?Title,?Content,?Type,?StartTime,?ExpiredTime,?RowTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from home_news where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update home_news set `Title`=?Title,`Content`=?Content,`Type`=?Type,`StartTime`=?StartTime,`ExpiredTime`=?ExpiredTime,`RowTime`=?RowTime where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from home_news  where `Id`=?Id;";
        #endregion

        #region 参数
        protected const string ParamId = "?Id";
        protected const string ParamTitle = "?Title";
        protected const string ParamContent = "?Content";
        protected const string ParamType = "?Type";
        protected const string ParamStartTime = "?StartTime";
        protected const string ParamExpiredTime = "?ExpiredTime";
        protected const string ParamRowTime = "?RowTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of HomeNewDb</returns>
        public static List<HomeNewDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="homenew">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(HomeNewDb homenew)
        {
            var param= GetInsertParams(homenew);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>HomeNewDb</returns>
        public static HomeNewDb  GetByPriKey(int id)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,id)
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
        /// <param name="homenew">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(HomeNewDb homenew)
        {
            var param= GetUpdateParams(homenew);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(int id)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,id)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(HomeNewDb homenew)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,homenew.Id),
                    new MySqlParameter(ParamTitle,homenew.Title),
                    new MySqlParameter(ParamContent,homenew.Content),
                    new MySqlParameter(ParamType,homenew.Type),
                    new MySqlParameter(ParamStartTime,homenew.StartTime),
                    new MySqlParameter(ParamExpiredTime,homenew.ExpiredTime),
                    new MySqlParameter(ParamRowTime,homenew.RowTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(HomeNewDb homenew)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamTitle,homenew.Title),
                    new MySqlParameter(ParamContent,homenew.Content),
                    new MySqlParameter(ParamType,homenew.Type),
                    new MySqlParameter(ParamStartTime,homenew.StartTime),
                    new MySqlParameter(ParamExpiredTime,homenew.ExpiredTime),
                    new MySqlParameter(ParamRowTime,homenew.RowTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>HomeNewDb</returns>
        public static HomeNewDb  ConvertToObject(DataRow dr)
        {
            var data = new HomeNewDb
                {
                    Id = DbChange.ToInt(dr["Id"],0),
                    Title = DbChange.ToString(dr["Title"]),
                    Content = DbChange.ToString(dr["Content"]),
                    Type = DbChange.ToInt(dr["Type"],0),
                    StartTime = DbChange.ToDateTime(dr["StartTime"],DateTime.MinValue),
                    ExpiredTime = DbChange.ToDateTime(dr["ExpiredTime"],DateTime.MinValue),
                    RowTime = DbChange.ToDateTime(dr["RowTime"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of HomeNewDb</returns>
        public static List<HomeNewDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<HomeNewDb>(); 
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
