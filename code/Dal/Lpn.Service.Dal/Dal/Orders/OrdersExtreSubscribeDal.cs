using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Orders;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Orders
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    [Serializable]
    public partial class OrdersExtreSubscribeDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from orders_extre_subscribe;";
        //新增插入语句
        protected const string SqlInsert = "insert into orders_extre_subscribe(`OrderNo`,`StartTime`,`EndTime`,`SubTime`,`ActualEnterTime`,`ActualExitTime`,`CarPort`,`CarPortDesc`) values(?OrderNo,?StartTime,?EndTime,?SubTime,?ActualEnterTime,?ActualExitTime,?CarPort,?CarPortDesc);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from orders_extre_subscribe where `OrderNo`=?OrderNo;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update orders_extre_subscribe set `StartTime`=?StartTime,`EndTime`=?EndTime,`SubTime`=?SubTime,`ActualEnterTime`=?ActualEnterTime,`ActualExitTime`=?ActualExitTime,`CarPort`=?CarPort,`CarPortDesc`=?CarPortDesc where `OrderNo`=?OrderNo;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from orders_extre_subscribe  where `OrderNo`=?OrderNo;";
        #endregion

        #region 参数
        protected const string ParamOrderNo = "?OrderNo";
        protected const string ParamStartTime = "?StartTime";
        protected const string ParamEndTime = "?EndTime";
        protected const string ParamSubTime = "?SubTime";
        protected const string ParamActualEnterTime = "?ActualEnterTime";
        protected const string ParamActualExitTime = "?ActualExitTime";
        protected const string ParamCarPort = "?CarPort";
        protected const string ParamCarPortDesc = "?CarPortDesc";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of OrdersExtreSubscribeDb</returns>
        public static List<OrdersExtreSubscribeDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="ordersextresubscribe">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(OrdersExtreSubscribeDb ordersextresubscribe)
        {
            var param= GetInsertParams(ordersextresubscribe);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="orderNo">订单号</param> 
        /// <returns>OrdersExtreSubscribeDb</returns>
        public static OrdersExtreSubscribeDb  GetByPriKey(string orderNo)
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
        /// <param name="ordersextresubscribe">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(OrdersExtreSubscribeDb ordersextresubscribe)
        {
            var param= GetUpdateParams(ordersextresubscribe);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="orderNo">订单号</param> 
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
        public static MySqlParameter[]  GetUpdateParams(OrdersExtreSubscribeDb ordersextresubscribe)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,ordersextresubscribe.OrderNo),
                    new MySqlParameter(ParamStartTime,ordersextresubscribe.StartTime),
                    new MySqlParameter(ParamEndTime,ordersextresubscribe.EndTime),
                    new MySqlParameter(ParamSubTime,ordersextresubscribe.SubTime),
                    new MySqlParameter(ParamActualEnterTime,ordersextresubscribe.ActualEnterTime),
                    new MySqlParameter(ParamActualExitTime,ordersextresubscribe.ActualExitTime),
                    new MySqlParameter(ParamCarPort,ordersextresubscribe.CarPort),
                    new MySqlParameter(ParamCarPortDesc,ordersextresubscribe.CarPortDesc)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(OrdersExtreSubscribeDb ordersextresubscribe)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,ordersextresubscribe.OrderNo),
                    new MySqlParameter(ParamStartTime,ordersextresubscribe.StartTime),
                    new MySqlParameter(ParamEndTime,ordersextresubscribe.EndTime),
                    new MySqlParameter(ParamSubTime,ordersextresubscribe.SubTime),
                    new MySqlParameter(ParamActualEnterTime,ordersextresubscribe.ActualEnterTime),
                    new MySqlParameter(ParamActualExitTime,ordersextresubscribe.ActualExitTime),
                    new MySqlParameter(ParamCarPort,ordersextresubscribe.CarPort),
                    new MySqlParameter(ParamCarPortDesc,ordersextresubscribe.CarPortDesc)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>OrdersExtreSubscribeDb</returns>
        public static OrdersExtreSubscribeDb  ConvertToObject(DataRow dr)
        {
            var data = new OrdersExtreSubscribeDb
                {
                    OrderNo = DbChange.ToString(dr["OrderNo"]),
                    StartTime = DbChange.ToDateTime(dr["StartTime"],DateTime.MinValue),
                    EndTime = DbChange.ToDateTime(dr["EndTime"],DateTime.MinValue),
                    SubTime = DbChange.ToDateTime(dr["SubTime"],DateTime.MinValue),
                    ActualEnterTime = DbChange.ToDateTime(dr["ActualEnterTime"],DateTime.MinValue),
                    ActualExitTime = DbChange.ToDateTime(dr["ActualExitTime"],DateTime.MinValue),
                    CarPort = DbChange.ToString(dr["CarPort"]),
                    CarPortDesc = DbChange.ToString(dr["CarPortDesc"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of OrdersExtreSubscribeDb</returns>
        public static List<OrdersExtreSubscribeDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<OrdersExtreSubscribeDb>(); 
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
