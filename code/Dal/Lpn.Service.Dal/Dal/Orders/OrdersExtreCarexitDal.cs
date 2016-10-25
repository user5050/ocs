using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Orders;

/*
* 由自动生成工具完成
* 描述:车辆支付订单额外信息表 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Orders
{
    /// <summary>
    /// 车辆支付订单额外信息表 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class OrdersExtreCarexitDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from orders_extre_carexit;";
        //新增插入语句
        protected const string SqlInsert = "insert into orders_extre_carexit(`OrderNo`,`EntranceTime`,`ExitTime`,`DeductionId`) values(?OrderNo,?EntranceTime,?ExitTime,?DeductionId);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from orders_extre_carexit where `OrderNo`=?OrderNo;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update orders_extre_carexit set `EntranceTime`=?EntranceTime,`ExitTime`=?ExitTime,`DeductionId`=?DeductionId where `OrderNo`=?OrderNo;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from orders_extre_carexit  where `OrderNo`=?OrderNo;";
        #endregion

        #region 参数
        protected const string ParamOrderNo = "?OrderNo";
        protected const string ParamEntranceTime = "?EntranceTime";
        protected const string ParamExitTime = "?ExitTime";
        protected const string ParamDeductionId = "?DeductionId";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of OrdersExtreCarexitDb</returns>
        public static List<OrdersExtreCarexitDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="ordersextrecarexit">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(OrdersExtreCarexitDb ordersextrecarexit)
        {
            var param= GetInsertParams(ordersextrecarexit);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="orderNo">订单编号</param> 
        /// <returns>OrdersExtreCarexitDb</returns>
        public static OrdersExtreCarexitDb  GetByPriKey(string orderNo)
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
        /// <param name="ordersextrecarexit">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(OrdersExtreCarexitDb ordersextrecarexit)
        {
            var param= GetUpdateParams(ordersextrecarexit);
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
        public static MySqlParameter[]  GetUpdateParams(OrdersExtreCarexitDb ordersextrecarexit)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,ordersextrecarexit.OrderNo),
                    new MySqlParameter(ParamEntranceTime,ordersextrecarexit.EntranceTime),
                    new MySqlParameter(ParamExitTime,ordersextrecarexit.ExitTime),
                    new MySqlParameter(ParamDeductionId,ordersextrecarexit.DeductionId)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(OrdersExtreCarexitDb ordersextrecarexit)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,ordersextrecarexit.OrderNo),
                    new MySqlParameter(ParamEntranceTime,ordersextrecarexit.EntranceTime),
                    new MySqlParameter(ParamExitTime,ordersextrecarexit.ExitTime),
                    new MySqlParameter(ParamDeductionId,ordersextrecarexit.DeductionId)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>OrdersExtreCarexitDb</returns>
        public static OrdersExtreCarexitDb  ConvertToObject(DataRow dr)
        {
            var data = new OrdersExtreCarexitDb
                {
                    OrderNo = DbChange.ToString(dr["OrderNo"]),
                    EntranceTime = DbChange.ToDateTime(dr["EntranceTime"],DateTime.MinValue),
                    ExitTime = DbChange.ToDateTime(dr["ExitTime"],DateTime.MinValue),
                    DeductionId = DbChange.ToString(dr["DeductionId"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of OrdersExtreCarexitDb</returns>
        public static List<OrdersExtreCarexitDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<OrdersExtreCarexitDb>(); 
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
