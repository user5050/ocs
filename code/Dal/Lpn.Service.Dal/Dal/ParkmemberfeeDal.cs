using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ParkmemberfeeDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parkmemberfee;";
        //新增插入语句
        protected const string SqlInsert = "insert into parkmemberfee(`FeePerMoon`,`FeePerSeason`,`FeePerYear`,`FreeDays`,`ParkID`) values(?FeePerMoon,?FeePerSeason,?FeePerYear,?FreeDays,?ParkID);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from parkmemberfee where `id`=?id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update parkmemberfee set `FeePerMoon`=?FeePerMoon,`FeePerSeason`=?FeePerSeason,`FeePerYear`=?FeePerYear,`FreeDays`=?FreeDays,`ParkID`=?ParkID where `id`=?id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from parkmemberfee  where `id`=?id;";
        #endregion

        #region 参数
        protected const string Paramid = "?id";
        protected const string ParamFeePerMoon = "?FeePerMoon";
        protected const string ParamFeePerSeason = "?FeePerSeason";
        protected const string ParamFeePerYear = "?FeePerYear";
        protected const string ParamFreeDays = "?FreeDays";
        protected const string ParamParkID = "?ParkID";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParkmemberfeeDb</returns>
        public static List<ParkmemberfeeDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parkmemberfee">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParkmemberfeeDb parkmemberfee)
        {
            var param= GetInsertParams(parkmemberfee);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>ParkmemberfeeDb</returns>
        public static ParkmemberfeeDb  GetByPriKey(int id)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramid,id)
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
        /// <param name="parkmemberfee">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ParkmemberfeeDb parkmemberfee)
        {
            var param= GetUpdateParams(parkmemberfee);
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
                    new MySqlParameter(Paramid,id)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(ParkmemberfeeDb parkmemberfee)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramid,parkmemberfee.Id),
                    new MySqlParameter(ParamFeePerMoon,parkmemberfee.FeePerMoon),
                    new MySqlParameter(ParamFeePerSeason,parkmemberfee.FeePerSeason),
                    new MySqlParameter(ParamFeePerYear,parkmemberfee.FeePerYear),
                    new MySqlParameter(ParamFreeDays,parkmemberfee.FreeDays),
                    new MySqlParameter(ParamParkID,parkmemberfee.ParkID)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParkmemberfeeDb parkmemberfee)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamFeePerMoon,parkmemberfee.FeePerMoon),
                    new MySqlParameter(ParamFeePerSeason,parkmemberfee.FeePerSeason),
                    new MySqlParameter(ParamFeePerYear,parkmemberfee.FeePerYear),
                    new MySqlParameter(ParamFreeDays,parkmemberfee.FreeDays),
                    new MySqlParameter(ParamParkID,parkmemberfee.ParkID)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParkmemberfeeDb</returns>
        public static ParkmemberfeeDb  ConvertToObject(DataRow dr)
        {
            var data = new ParkmemberfeeDb
                {
                    Id = DbChange.ToInt(dr["id"],0),
                    FeePerMoon = DbChange.ToDecimal(dr["FeePerMoon"],0),
                    FeePerSeason = DbChange.ToDecimal(dr["FeePerSeason"],0),
                    FeePerYear = DbChange.ToDecimal(dr["FeePerYear"],0),
                    FreeDays = DbChange.ToInt(dr["FreeDays"],0),
                    ParkID = DbChange.ToInt(dr["ParkID"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ParkmemberfeeDb</returns>
        public static List<ParkmemberfeeDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParkmemberfeeDb>(); 
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
