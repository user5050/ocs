using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Helper.Http;
using OneCoin.Service.Model.Db.Product;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/22
*/
namespace OneCoin.Service.Dal.Dal.Product
{
    /// <summary>
    ///  Dal帮助类
    /// </summary> 
    public partial class ProductGameWinnerDal
    {
        #region SQL
        //获取整个表数据
        protected const string SqlPrvGameWinner = "SELECT * FROM product_game_winner WHERE pid=?pid ORDER BY rowtime DESC LIMIT 0,1;";

        //获取整个表数据
        protected const string SqlGameWinners = "SELECT * FROM product_game_winner WHERE pid=?pid ORDER BY rowtime DESC LIMIT ?Skip,?Take;";

        protected const string SqlGameWinnersFormatter = "SELECT * FROM product_game_winner GameNo in('{0}')";
        #endregion

        #region 参数

        protected const string ParamSkip = "?Skip";
        protected const string ParamTake = "?Take";
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="productId">活动期号</param> 
        /// <returns>ProductGameWinnerDb</returns>
        public static ProductGameWinnerDb GetPrvGameWinner(string productId)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamPid,productId)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlPrvGameWinner, param);

            //判断是否存在数据
            if (null != dr && dr.Rows.Count > 0)
            {
                return ConvertToObject(dr.Rows[0]);
            }

            return null;
        }


        public static List<ProductGameWinnerDb> GetGameWinners(string productId, int skip, int take)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamSkip,skip),
                    new MySqlParameter(ParamTake,take),
                    new MySqlParameter(ParamPid,productId)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGameWinners, param);

            //判断是否存在数据
            return ConvertToObjects(dr); 
        }


        public static List<ProductGameWinnerDb> GetGameWinners(List<string> gameNos)
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, string.Format(SqlGameWinnersFormatter, Spanner.Join(gameNos, "','")));

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="productgamewinner">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool Insert(MySqlConnection conn,ProductGameWinnerDb productgamewinner)
        {
            var param = GetInsertParams(productgamewinner);
            var result = DbHelper.ExecuteNonQuery(conn, SqlInsert,true, param);

            return result > 0;
        }
        #endregion

    }
}
