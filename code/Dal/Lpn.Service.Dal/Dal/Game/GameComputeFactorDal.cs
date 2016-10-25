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
    public partial class GameComputeFactorDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from game_compute_factor;";
        //新增插入语句
        protected const string SqlInsert = "insert into game_compute_factor(`GameNo`,`SSEPrice`,`StockNo1`,`StockNo2`,`StockNo3`,`StockPrice1`,`StockPrice2`,`StockPrice3`,`Result`) values(?GameNo,?SSEPrice,?StockNo1,?StockNo2,?StockNo3,?StockPrice1,?StockPrice2,?StockPrice3,?Result);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from game_compute_factor where `GameNo`=?GameNo;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update game_compute_factor set `SSEPrice`=?SSEPrice,`StockNo1`=?StockNo1,`StockNo2`=?StockNo2,`StockNo3`=?StockNo3,`StockPrice1`=?StockPrice1,`StockPrice2`=?StockPrice2,`StockPrice3`=?StockPrice3,`Result`=?Result where `GameNo`=?GameNo;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from game_compute_factor  where `GameNo`=?GameNo;";
        #endregion

        #region 参数
        protected const string ParamGameNo = "?GameNo";
        protected const string ParamSSEPrice = "?SSEPrice";
        protected const string ParamStockNo1 = "?StockNo1";
        protected const string ParamStockNo2 = "?StockNo2";
        protected const string ParamStockNo3 = "?StockNo3";
        protected const string ParamStockPrice1 = "?StockPrice1";
        protected const string ParamStockPrice2 = "?StockPrice2";
        protected const string ParamStockPrice3 = "?StockPrice3";
        protected const string ParamResult = "?Result";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of GameComputeFactorDb</returns>
        public static List<GameComputeFactorDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="gamecomputefactor">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(GameComputeFactorDb gamecomputefactor)
        {
            var param= GetInsertParams(gamecomputefactor);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="gameNo">期号</param> 
        /// <returns>GameComputeFactorDb</returns>
        public static GameComputeFactorDb  GetByPriKey(string gameNo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamGameNo,gameNo)
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
        /// <param name="gamecomputefactor">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(GameComputeFactorDb gamecomputefactor)
        {
            var param= GetUpdateParams(gamecomputefactor);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="gameNo">期号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string gameNo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamGameNo,gameNo)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(GameComputeFactorDb gamecomputefactor)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamGameNo,gamecomputefactor.GameNo),
                    new MySqlParameter(ParamSSEPrice,gamecomputefactor.SSEPrice),
                    new MySqlParameter(ParamStockNo1,gamecomputefactor.StockNo1),
                    new MySqlParameter(ParamStockNo2,gamecomputefactor.StockNo2),
                    new MySqlParameter(ParamStockNo3,gamecomputefactor.StockNo3),
                    new MySqlParameter(ParamStockPrice1,gamecomputefactor.StockPrice1),
                    new MySqlParameter(ParamStockPrice2,gamecomputefactor.StockPrice2),
                    new MySqlParameter(ParamStockPrice3,gamecomputefactor.StockPrice3),
                    new MySqlParameter(ParamResult,gamecomputefactor.Result)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(GameComputeFactorDb gamecomputefactor)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamGameNo,gamecomputefactor.GameNo),
                    new MySqlParameter(ParamSSEPrice,gamecomputefactor.SSEPrice),
                    new MySqlParameter(ParamStockNo1,gamecomputefactor.StockNo1),
                    new MySqlParameter(ParamStockNo2,gamecomputefactor.StockNo2),
                    new MySqlParameter(ParamStockNo3,gamecomputefactor.StockNo3),
                    new MySqlParameter(ParamStockPrice1,gamecomputefactor.StockPrice1),
                    new MySqlParameter(ParamStockPrice2,gamecomputefactor.StockPrice2),
                    new MySqlParameter(ParamStockPrice3,gamecomputefactor.StockPrice3),
                    new MySqlParameter(ParamResult,gamecomputefactor.Result)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>GameComputeFactorDb</returns>
        public static GameComputeFactorDb  ConvertToObject(DataRow dr)
        {
            var data = new GameComputeFactorDb
                {
                    GameNo = DbChange.ToString(dr["GameNo"]),
                    SSEPrice = DbChange.ToDouble(dr["SSEPrice"],0D),
                    StockNo1 = DbChange.ToString(dr["StockNo1"]),
                    StockNo2 = DbChange.ToString(dr["StockNo2"]),
                    StockNo3 = DbChange.ToString(dr["StockNo3"]),
                    StockPrice1 = DbChange.ToDouble(dr["StockPrice1"],0D),
                    StockPrice2 = DbChange.ToDouble(dr["StockPrice2"],0D),
                    StockPrice3 = DbChange.ToDouble(dr["StockPrice3"],0D),
                    Result = DbChange.ToInt(dr["Result"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of GameComputeFactorDb</returns>
        public static List<GameComputeFactorDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<GameComputeFactorDb>(); 
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
