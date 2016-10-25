using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Orders;

/*
* 由自动生成工具完成
* 描述:月租支付订单额外信息表 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Orders
{
    /// <summary>
    /// 月租支付订单额外信息表 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class OrdersExtreRenewalmonthDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from orders_extre_renewalmonth;";
        //新增插入语句
        protected const string SqlInsert = "insert into orders_extre_renewalmonth(`OrderNo`,`TillDate`,`RenewalMonths`,`MonthlySort`) values(?OrderNo,?TillDate,?RenewalMonths,?MonthlySort);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from orders_extre_renewalmonth where `OrderNo`=?OrderNo;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update orders_extre_renewalmonth set `TillDate`=?TillDate,`RenewalMonths`=?RenewalMonths,`MonthlySort`=?MonthlySort where `OrderNo`=?OrderNo;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from orders_extre_renewalmonth  where `OrderNo`=?OrderNo;";
        #endregion

        #region 参数
        protected const string ParamOrderNo = "?OrderNo";
        protected const string ParamTillDate = "?TillDate";
        protected const string ParamRenewalMonths = "?RenewalMonths";
        protected const string ParamMonthlySort = "?MonthlySort";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of OrdersExtreRenewalmonthDb</returns>
        public static List<OrdersExtreRenewalmonthDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="ordersextrerenewalmonth">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(OrdersExtreRenewalmonthDb ordersextrerenewalmonth)
        {
            var param= GetInsertParams(ordersextrerenewalmonth);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="orderNo">订单编号</param> 
        /// <returns>OrdersExtreRenewalmonthDb</returns>
        public static OrdersExtreRenewalmonthDb  GetByPriKey(string orderNo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,orderNo)
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
        /// <param name="ordersextrerenewalmonth">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(OrdersExtreRenewalmonthDb ordersextrerenewalmonth)
        {
            var param= GetUpdateParams(ordersextrerenewalmonth);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="orderNo">订单编号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string orderNo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,orderNo)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(OrdersExtreRenewalmonthDb ordersextrerenewalmonth)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,ordersextrerenewalmonth.OrderNo),
                    new MySqlParameter(ParamTillDate,ordersextrerenewalmonth.TillDate),
                    new MySqlParameter(ParamRenewalMonths,ordersextrerenewalmonth.RenewalMonths),
                    new MySqlParameter(ParamMonthlySort,ordersextrerenewalmonth.MonthlySort)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(OrdersExtreRenewalmonthDb ordersextrerenewalmonth)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,ordersextrerenewalmonth.OrderNo),
                    new MySqlParameter(ParamTillDate,ordersextrerenewalmonth.TillDate),
                    new MySqlParameter(ParamRenewalMonths,ordersextrerenewalmonth.RenewalMonths),
                    new MySqlParameter(ParamMonthlySort,ordersextrerenewalmonth.MonthlySort)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>OrdersExtreRenewalmonthDb</returns>
        public static OrdersExtreRenewalmonthDb  ConvertToObject(DataRow dr)
        {
            var data = new OrdersExtreRenewalmonthDb
                {
                    OrderNo = DbChange.ToString(dr["OrderNo"]),
                    TillDate = DbChange.ToDateTime(dr["TillDate"],DateTime.MinValue),
                    RenewalMonths = DbChange.ToInt(dr["RenewalMonths"],0),
                    MonthlySort = DbChange.ToInt(dr["MonthlySort"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of OrdersExtreRenewalmonthDb</returns>
        public static List<OrdersExtreRenewalmonthDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<OrdersExtreRenewalmonthDb>(); 
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
