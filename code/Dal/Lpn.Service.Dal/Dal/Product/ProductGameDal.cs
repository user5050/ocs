using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Model.Db.Product;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Dal.Dal.Product
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ProductGameDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from product_game;";
        //新增插入语句
        protected const string SqlInsert = "insert into product_game(`GameNo`,`Pid`,`TotalMoney`,`UserCnt`,`RowTime`,`EndTime`,`State`,`StockNo1`,`StockName1`,`StockNo2`,`StockName2`,`StockNo3`,`StockName3`) values(?GameNo,?Pid,?TotalMoney,?UserCnt,?RowTime,?EndTime,?State,?StockNo1,?StockName1,?StockNo2,?StockName2,?StockNo3,?StockName3);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from product_game where `GameNo`=?GameNo;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update product_game set `Pid`=?Pid,`TotalMoney`=?TotalMoney,`UserCnt`=?UserCnt,`RowTime`=?RowTime,`EndTime`=?EndTime,`State`=?State,`StockNo1`=?StockNo1,`StockName1`=?StockName1,`StockNo2`=?StockNo2,`StockName2`=?StockName2,`StockNo3`=?StockNo3,`StockName3`=?StockName3 where `GameNo`=?GameNo;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from product_game  where `GameNo`=?GameNo;";
        #endregion

        #region 参数
        protected const string ParamGameNo = "?GameNo";
        protected const string ParamPid = "?Pid";
        protected const string ParamTotalMoney = "?TotalMoney";
        protected const string ParamUserCnt = "?UserCnt";
        protected const string ParamRowTime = "?RowTime";
        protected const string ParamEndTime = "?EndTime";
        protected const string ParamState = "?State";
        protected const string ParamStockNo1 = "?StockNo1";
        protected const string ParamStockName1 = "?StockName1";
        protected const string ParamStockNo2 = "?StockNo2";
        protected const string ParamStockName2 = "?StockName2";
        protected const string ParamStockNo3 = "?StockNo3";
        protected const string ParamStockName3 = "?StockName3";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ProductGameDb</returns>
        public static List<ProductGameDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="productgame">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ProductGameDb productgame)
        {
            var param= GetInsertParams(productgame);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="gameNo">活动期号</param> 
        /// <returns>ProductGameDb</returns>
        public static ProductGameDb  GetByPriKey(string gameNo)
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
        /// <param name="productgame">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ProductGameDb productgame)
        {
            var param= GetUpdateParams(productgame);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="gameNo">活动期号</param> 
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
        public static MySqlParameter[]  GetUpdateParams(ProductGameDb productgame)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamGameNo,productgame.GameNo),
                    new MySqlParameter(ParamPid,productgame.Pid),
                    new MySqlParameter(ParamTotalMoney,productgame.TotalMoney),
                    new MySqlParameter(ParamUserCnt,productgame.UserCnt),
                    new MySqlParameter(ParamRowTime,productgame.RowTime),
                    new MySqlParameter(ParamEndTime,productgame.EndTime),
                    new MySqlParameter(ParamState,productgame.State),
                    new MySqlParameter(ParamStockNo1,productgame.StockNo1),
                    new MySqlParameter(ParamStockName1,productgame.StockName1),
                    new MySqlParameter(ParamStockNo2,productgame.StockNo2),
                    new MySqlParameter(ParamStockName2,productgame.StockName2),
                    new MySqlParameter(ParamStockNo3,productgame.StockNo3),
                    new MySqlParameter(ParamStockName3,productgame.StockName3)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ProductGameDb productgame)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamGameNo,productgame.GameNo),
                    new MySqlParameter(ParamPid,productgame.Pid),
                    new MySqlParameter(ParamTotalMoney,productgame.TotalMoney),
                    new MySqlParameter(ParamUserCnt,productgame.UserCnt),
                    new MySqlParameter(ParamRowTime,productgame.RowTime),
                    new MySqlParameter(ParamEndTime,productgame.EndTime),
                    new MySqlParameter(ParamState,productgame.State),
                    new MySqlParameter(ParamStockNo1,productgame.StockNo1),
                    new MySqlParameter(ParamStockName1,productgame.StockName1),
                    new MySqlParameter(ParamStockNo2,productgame.StockNo2),
                    new MySqlParameter(ParamStockName2,productgame.StockName2),
                    new MySqlParameter(ParamStockNo3,productgame.StockNo3),
                    new MySqlParameter(ParamStockName3,productgame.StockName3)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ProductGameDb</returns>
        public static ProductGameDb  ConvertToObject(DataRow dr)
        {
            var data = new ProductGameDb
                {
                    GameNo = DbChange.ToString(dr["GameNo"]),
                    Pid = DbChange.ToString(dr["Pid"]),
                    TotalMoney = DbChange.ToInt(dr["TotalMoney"],0),
                    UserCnt = DbChange.ToInt(dr["UserCnt"],0),
                    RowTime = DbChange.ToDateTime(dr["RowTime"],DateTime.MinValue),
                    EndTime = DbChange.ToDateTime(dr["EndTime"],DateTime.MinValue),
                    State = DbChange.ToInt(dr["State"],0),
                    StockNo1 = DbChange.ToString(dr["StockNo1"]),
                    StockName1 = DbChange.ToString(dr["StockName1"]),
                    StockNo2 = DbChange.ToString(dr["StockNo2"]),
                    StockName2 = DbChange.ToString(dr["StockName2"]),
                    StockNo3 = DbChange.ToString(dr["StockNo3"]),
                    StockName3 = DbChange.ToString(dr["StockName3"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ProductGameDb</returns>
        public static List<ProductGameDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ProductGameDb>(); 
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
