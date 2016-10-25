using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Model.Db.Product;
using OneCoin.Service.Model.Enum.Product;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace OneCoin.Service.Dal.Dal.Product
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    public partial class ProductGameDal
    {
        #region SQL

        protected const string SqlUpdateAddUserCnt = "update product_game set `UserCnt`= `UserCnt`+ ?UserCnt where `GameNo`=?GameNo;";

        protected const string SqlUpdateToWaitCompute = "update product_game set `EndTime`=?EndTime,`State`=?State   where `GameNo`=?GameNo;";

        protected const string SqlUpdateState = "update product_game set  `State`=?State   where `GameNo`=?GameNo;";

        protected const string SqlGetWaitForCompute = "SELECT * FROM `product_game` WHERE  state=2 AND EndTime <= ?EndTime;";
        
        #endregion

        public static bool AddUserCnt(MySqlConnection conn, string gameNo, int buyCnt)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamGameNo,gameNo),
                    new MySqlParameter(ParamUserCnt,buyCnt)
                };

            var result = DbHelper.ExecuteNonQuery(conn, SqlUpdateAddUserCnt, true, param);

            return result > 0;
        }


        public static bool UpdateToWaitCompute(MySqlConnection conn, string gameNo, DateTime date)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamGameNo,gameNo),
                    new MySqlParameter(ParamState, (int)GameState.WaitForCompute),
                    new MySqlParameter(ParamEndTime,date)
                };

            var result = DbHelper.ExecuteNonQuery(conn, SqlUpdateToWaitCompute, true, param);

            return result > 0;
        }

        public static bool UpdateState(MySqlConnection conn, string gameNo,GameState gs)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamGameNo,gameNo),
                    new MySqlParameter(ParamState, (int)gs)
                };

            var result = DbHelper.ExecuteNonQuery(conn, SqlUpdateState, true, param);

            return result > 0;
        }

        #region 新增数据

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="productgame">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool Insert(MySqlConnection conn,ProductGameDb productgame)
        {
            var param = GetInsertParams(productgame);
            var result = DbHelper.ExecuteNonQuery(conn, SqlInsert, true,param);

            return result > 0;
        }
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ProductGameDb</returns>
        public static List<ProductGameDb> GetWaitForCompute(DateTime endTime)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamEndTime,endTime)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetWaitForCompute);

            return ConvertToObjects(dr);
        }
        #endregion
     }
}
