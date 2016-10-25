using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Model.Db.Game;

/*
* 由自动生成工具完成
* 描述:排除的日期 Dal帮助类
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Dal.Dal.Game
{
    /// <summary>
    /// 排除的日期 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class GameStockComputeEldtimeDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from game_stock_compute_eldtime;";
        //新增插入语句
        protected const string SqlInsert = "insert into game_stock_compute_eldtime(`Date`) values(?Date);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from game_stock_compute_eldtime where `Date`=?Date;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update game_stock_compute_eldtime set  where `Date`=?Date;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from game_stock_compute_eldtime  where `Date`=?Date;";
        #endregion

        #region 参数
        protected const string ParamDate = "?Date";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of GameStockComputeEldtimeDb</returns>
        public static List<GameStockComputeEldtimeDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="gamestockcomputeeldtime">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(GameStockComputeEldtimeDb gamestockcomputeeldtime)
        {
            var param= GetInsertParams(gamestockcomputeeldtime);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="date"></param> 
        /// <returns>GameStockComputeEldtimeDb</returns>
        public static GameStockComputeEldtimeDb  GetByPriKey(DateTime date)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamDate,date)
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
        /// <param name="gamestockcomputeeldtime">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(GameStockComputeEldtimeDb gamestockcomputeeldtime)
        {
            var param= GetUpdateParams(gamestockcomputeeldtime);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="date"></param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(DateTime date)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamDate,date)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(GameStockComputeEldtimeDb gamestockcomputeeldtime)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamDate,gamestockcomputeeldtime.Date)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(GameStockComputeEldtimeDb gamestockcomputeeldtime)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamDate,gamestockcomputeeldtime.Date)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>GameStockComputeEldtimeDb</returns>
        public static GameStockComputeEldtimeDb  ConvertToObject(DataRow dr)
        {
            var data = new GameStockComputeEldtimeDb
                {
                    Date = DbChange.ToDateTime(dr["Date"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of GameStockComputeEldtimeDb</returns>
        public static List<GameStockComputeEldtimeDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<GameStockComputeEldtimeDb>(); 
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
