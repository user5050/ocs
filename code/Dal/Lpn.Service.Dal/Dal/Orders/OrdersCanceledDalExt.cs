using System.Collections.Generic;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Model.Db.Orders;
using MySql.Data.MySqlClient;

namespace OneCoin.Service.Dal.Dal.Orders
{
    public partial class OrdersCanceledDal
    {

        #region SQL

        //根据主键更新整行数据
        protected const string SqlUpdateStatus = "update orders_canceled  set   `Description`=?Description,`IsProcessed`=?IsProcessed,`IsChecked`=?IsChecked  where `OrderNo`=?OrderNo;";

        //获取我的撤费的订单
        protected const string SqlGetSuccessByUserId = "select * from orders_canceled where  `OrderNo` < ?StartNo and   userid=?UserId  order by  `OrderNo` desc  limit ?take;";

        #endregion

        #region 参数 
        protected const string ParamStartNo = "?StartNo";
        protected const string ParamTake = "?Take";
        #endregion

        #region 新增数据

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="orderscanceled">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool Insert(MySqlConnection conn,OrdersCanceledDb orderscanceled)
        {
            var param = GetInsertParams(orderscanceled);

            var result = DbHelper.ExecuteNonQuery(conn, SqlInsert, true, param);

            return result > 0;
        }
        #endregion

        #region 更新状态

        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="orderNo"></param>
        /// <param name="isProcessed"></param>
        /// <param name="isChecked"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public static bool UpdateStatus(MySqlConnection conn, string orderNo, int isProcessed, int isChecked,string desc)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,orderNo), 
                    new MySqlParameter(ParamIsProcessed,isProcessed),
                    new MySqlParameter(ParamDescription,desc),
                    new MySqlParameter(ParamIsChecked,isChecked)
                };

            var result = DbHelper.ExecuteNonQuery(conn, SqlUpdateStatus, true, param);

            return result > 0;
        }

       
        #endregion

        #region 获取我的撤费的订单

        /// <summary>
        /// 获取我的撤费的订单
        /// </summary>
        public static List<OrdersCanceledDb> GetSuccessByUserId(int userId,  string startNo, int take)
        {
            var param = new[]
                {  
                    new MySqlParameter(ParamUserID,userId),
                    new MySqlParameter(ParamStartNo,startNo),
                    new MySqlParameter(ParamTake,take)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetSuccessByUserId, param);

            return ConvertToObjects(dr);
        }
        #endregion
    }
}
