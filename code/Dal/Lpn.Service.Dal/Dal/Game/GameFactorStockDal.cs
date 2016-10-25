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
    public partial class GameFactorStockDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from game_factor_stock;";
        //新增插入语句
        protected const string SqlInsert = "insert into game_factor_stock(`StockNo`,`StockName`,`RowTime`) values(?StockNo,?StockName,?RowTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from game_factor_stock where `StockNo`=?StockNo;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update game_factor_stock set `StockName`=?StockName,`RowTime`=?RowTime where `StockNo`=?StockNo;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from game_factor_stock  where `StockNo`=?StockNo;";
        #endregion

        #region 参数
        protected const string ParamStockNo = "?StockNo";
        protected const string ParamStockName = "?StockName";
        protected const string ParamRowTime = "?RowTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of GameFactorStockDb</returns>
        public static List<GameFactorStockDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="gamefactorstock">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(GameFactorStockDb gamefactorstock)
        {
            var param= GetInsertParams(gamefactorstock);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="stockNo"></param> 
        /// <returns>GameFactorStockDb</returns>
        public static GameFactorStockDb  GetByPriKey(string stockNo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamStockNo,stockNo)
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
        /// <param name="gamefactorstock">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(GameFactorStockDb gamefactorstock)
        {
            var param= GetUpdateParams(gamefactorstock);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="stockNo"></param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string stockNo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamStockNo,stockNo)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(GameFactorStockDb gamefactorstock)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamStockNo,gamefactorstock.StockNo),
                    new MySqlParameter(ParamStockName,gamefactorstock.StockName),
                    new MySqlParameter(ParamRowTime,gamefactorstock.RowTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(GameFactorStockDb gamefactorstock)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamStockNo,gamefactorstock.StockNo),
                    new MySqlParameter(ParamStockName,gamefactorstock.StockName),
                    new MySqlParameter(ParamRowTime,gamefactorstock.RowTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>GameFactorStockDb</returns>
        public static GameFactorStockDb  ConvertToObject(DataRow dr)
        {
            var data = new GameFactorStockDb
                {
                    StockNo = DbChange.ToString(dr["StockNo"]),
                    StockName = DbChange.ToString(dr["StockName"]),
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
        /// <returns>List of GameFactorStockDb</returns>
        public static List<GameFactorStockDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<GameFactorStockDb>(); 
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
