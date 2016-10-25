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
    public partial class ProductGameWinnerDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from product_game_winner;";
        //新增插入语句
        protected const string SqlInsert = "insert into product_game_winner(`GameNo`,`Uid`,`Pid`,`BuyAmount`,`RowTime`,`WinNo`) values(?GameNo,?Uid,?Pid,?BuyAmount,?RowTime,?WinNo);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from product_game_winner where `GameNo`=?GameNo;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update product_game_winner set `Uid`=?Uid,`Pid`=?Pid,`BuyAmount`=?BuyAmount,`RowTime`=?RowTime,`WinNo`=?WinNo where `GameNo`=?GameNo;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from product_game_winner  where `GameNo`=?GameNo;";
        #endregion

        #region 参数
        protected const string ParamGameNo = "?GameNo";
        protected const string ParamUid = "?Uid";
        protected const string ParamPid = "?Pid";
        protected const string ParamBuyAmount = "?BuyAmount";
        protected const string ParamRowTime = "?RowTime";
        protected const string ParamWinNo = "?WinNo";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ProductGameWinnerDb</returns>
        public static List<ProductGameWinnerDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="productgamewinner">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ProductGameWinnerDb productgamewinner)
        {
            var param= GetInsertParams(productgamewinner);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="gameNo">活动期号</param> 
        /// <returns>ProductGameWinnerDb</returns>
        public static ProductGameWinnerDb  GetByPriKey(string gameNo)
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
        /// <param name="productgamewinner">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ProductGameWinnerDb productgamewinner)
        {
            var param= GetUpdateParams(productgamewinner);
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
        public static MySqlParameter[]  GetUpdateParams(ProductGameWinnerDb productgamewinner)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamGameNo,productgamewinner.GameNo),
                    new MySqlParameter(ParamUid,productgamewinner.Uid),
                    new MySqlParameter(ParamPid,productgamewinner.Pid),
                    new MySqlParameter(ParamBuyAmount,productgamewinner.BuyAmount),
                    new MySqlParameter(ParamRowTime,productgamewinner.RowTime),
                    new MySqlParameter(ParamWinNo,productgamewinner.WinNo)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ProductGameWinnerDb productgamewinner)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamGameNo,productgamewinner.GameNo),
                    new MySqlParameter(ParamUid,productgamewinner.Uid),
                    new MySqlParameter(ParamPid,productgamewinner.Pid),
                    new MySqlParameter(ParamBuyAmount,productgamewinner.BuyAmount),
                    new MySqlParameter(ParamRowTime,productgamewinner.RowTime),
                    new MySqlParameter(ParamWinNo,productgamewinner.WinNo)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ProductGameWinnerDb</returns>
        public static ProductGameWinnerDb  ConvertToObject(DataRow dr)
        {
            var data = new ProductGameWinnerDb
                {
                    GameNo = DbChange.ToString(dr["GameNo"]),
                    Uid = DbChange.ToString(dr["Uid"]),
                    Pid = DbChange.ToString(dr["Pid"]),
                    BuyAmount = DbChange.ToInt(dr["BuyAmount"],0),
                    RowTime = DbChange.ToDateTime(dr["RowTime"],DateTime.MinValue),
                    WinNo = DbChange.ToInt(dr["WinNo"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ProductGameWinnerDb</returns>
        public static List<ProductGameWinnerDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ProductGameWinnerDb>(); 
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
