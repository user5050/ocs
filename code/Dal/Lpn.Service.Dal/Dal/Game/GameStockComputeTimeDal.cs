using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Model.Db.Game;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Dal.Dal.Game
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    [Serializable]
    public partial class GameStockComputeTimeDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from game_stock_compute_time;";
        //新增插入语句
        protected const string SqlInsert = "insert into game_stock_compute_time(`ComputeTime`,`LastUpdateTime`,`ComputeEndTime`) values(?ComputeTime,?LastUpdateTime,?ComputeEndTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from game_stock_compute_time where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update game_stock_compute_time set `ComputeTime`=?ComputeTime,`LastUpdateTime`=?LastUpdateTime,`ComputeEndTime`=?ComputeEndTime where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from game_stock_compute_time  where `Id`=?Id;";
        #endregion

        #region 参数
        protected const string ParamId = "?Id";
        protected const string ParamComputeTime = "?ComputeTime";
        protected const string ParamLastUpdateTime = "?LastUpdateTime";
        protected const string ParamComputeEndTime = "?ComputeEndTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of GameStockComputeTimeDb</returns>
        public static List<GameStockComputeTimeDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="gamestockcomputetime">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(GameStockComputeTimeDb gamestockcomputetime)
        {
            var param= GetInsertParams(gamestockcomputetime);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>GameStockComputeTimeDb</returns>
        public static GameStockComputeTimeDb  GetByPriKey(int id)
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
        /// <param name="gamestockcomputetime">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(GameStockComputeTimeDb gamestockcomputetime)
        {
            var param= GetUpdateParams(gamestockcomputetime);
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
        public static MySqlParameter[]  GetUpdateParams(GameStockComputeTimeDb gamestockcomputetime)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,gamestockcomputetime.Id),
                    new MySqlParameter(ParamComputeTime,gamestockcomputetime.ComputeTime),
                    new MySqlParameter(ParamLastUpdateTime,gamestockcomputetime.LastUpdateTime),
                    new MySqlParameter(ParamComputeEndTime,gamestockcomputetime.ComputeEndTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(GameStockComputeTimeDb gamestockcomputetime)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamComputeTime,gamestockcomputetime.ComputeTime),
                    new MySqlParameter(ParamLastUpdateTime,gamestockcomputetime.LastUpdateTime),
                    new MySqlParameter(ParamComputeEndTime,gamestockcomputetime.ComputeEndTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>GameStockComputeTimeDb</returns>
        public static GameStockComputeTimeDb  ConvertToObject(DataRow dr)
        {
            var data = new GameStockComputeTimeDb
                {
                    Id = DbChange.ToInt(dr["Id"],0),
                    ComputeTime = DbChange.ToDateTime(dr["ComputeTime"],DateTime.MinValue),
                    LastUpdateTime = DbChange.ToDateTime(dr["LastUpdateTime"],DateTime.MinValue),
                    ComputeEndTime = DbChange.ToDateTime(dr["ComputeEndTime"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of GameStockComputeTimeDb</returns>
        public static List<GameStockComputeTimeDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<GameStockComputeTimeDb>(); 
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
