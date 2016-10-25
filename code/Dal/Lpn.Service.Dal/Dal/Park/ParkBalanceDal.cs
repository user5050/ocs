using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Park;

/*
* 由自动生成工具完成
* 描述:[park_balance]停车场结算信息 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Park
{
    /// <summary>
    /// [park_balance]停车场结算信息 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ParkBalanceDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parkbalance;";
        //新增插入语句
        protected const string SqlInsert = "insert into parkbalance(`parkbalance_id`,`balancetime`,`balancemoney`,`circle`,`starttime`,`endtime`,`balance_id`,`parkcode`,`paymentstatus`,`operator`,`operatetime`) values(?parkbalance_id,?balancetime,?balancemoney,?circle,?starttime,?endtime,?balance_id,?parkcode,?paymentstatus,?operator,?operatetime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from parkbalance where `parkbalance_id`=?parkbalance_id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update parkbalance set `balancetime`=?balancetime,`balancemoney`=?balancemoney,`circle`=?circle,`starttime`=?starttime,`endtime`=?endtime,`balance_id`=?balance_id,`parkcode`=?parkcode,`paymentstatus`=?paymentstatus,`operator`=?operator,`operatetime`=?operatetime where `parkbalance_id`=?parkbalance_id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from parkbalance  where `parkbalance_id`=?parkbalance_id;";
        #endregion

        #region 参数
        protected const string Paramparkbalance_id = "?parkbalance_id";
        protected const string Parambalancetime = "?balancetime";
        protected const string Parambalancemoney = "?balancemoney";
        protected const string Paramcircle = "?circle";
        protected const string Paramstarttime = "?starttime";
        protected const string Paramendtime = "?endtime";
        protected const string Parambalance_id = "?balance_id";
        protected const string Paramparkcode = "?parkcode";
        protected const string Parampaymentstatus = "?paymentstatus";
        protected const string Paramoperator = "?operator";
        protected const string Paramoperatetime = "?operatetime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParkBalanceDb</returns>
        public static List<ParkBalanceDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parkbalance">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParkBalanceDb parkbalance)
        {
            var param= GetInsertParams(parkbalance);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="parkbalance_id">标识</param> 
        /// <returns>ParkBalanceDb</returns>
        public static ParkBalanceDb  GetByPriKey(string parkbalance_id)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramparkbalance_id,parkbalance_id)
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
        /// <param name="parkbalance">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ParkBalanceDb parkbalance)
        {
            var param= GetUpdateParams(parkbalance);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="parkbalance_id">标识</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string parkbalance_id)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramparkbalance_id,parkbalance_id)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(ParkBalanceDb parkbalance)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramparkbalance_id,parkbalance.Parkbalance_id),
                    new MySqlParameter(Parambalancetime,parkbalance.Balancetime),
                    new MySqlParameter(Parambalancemoney,parkbalance.Balancemoney),
                    new MySqlParameter(Paramcircle,parkbalance.Circle),
                    new MySqlParameter(Paramstarttime,parkbalance.Starttime),
                    new MySqlParameter(Paramendtime,parkbalance.Endtime),
                    new MySqlParameter(Parambalance_id,parkbalance.Balance_id),
                    new MySqlParameter(Paramparkcode,parkbalance.Parkcode),
                    new MySqlParameter(Parampaymentstatus,parkbalance.Paymentstatus),
                    new MySqlParameter(Paramoperator,parkbalance.Operator),
                    new MySqlParameter(Paramoperatetime,parkbalance.Operatetime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParkBalanceDb parkbalance)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramparkbalance_id,parkbalance.Parkbalance_id),
                    new MySqlParameter(Parambalancetime,parkbalance.Balancetime),
                    new MySqlParameter(Parambalancemoney,parkbalance.Balancemoney),
                    new MySqlParameter(Paramcircle,parkbalance.Circle),
                    new MySqlParameter(Paramstarttime,parkbalance.Starttime),
                    new MySqlParameter(Paramendtime,parkbalance.Endtime),
                    new MySqlParameter(Parambalance_id,parkbalance.Balance_id),
                    new MySqlParameter(Paramparkcode,parkbalance.Parkcode),
                    new MySqlParameter(Parampaymentstatus,parkbalance.Paymentstatus),
                    new MySqlParameter(Paramoperator,parkbalance.Operator),
                    new MySqlParameter(Paramoperatetime,parkbalance.Operatetime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParkBalanceDb</returns>
        public static ParkBalanceDb  ConvertToObject(DataRow dr)
        {
            var data = new ParkBalanceDb
                {
                    Parkbalance_id = DbChange.ToString(dr["parkbalance_id"]),
                    Balancetime = DbChange.ToString(dr["balancetime"]),
                    Balancemoney = DbChange.ToDecimal(dr["balancemoney"],0),
                    Circle = DbChange.ToString(dr["circle"]),
                    Starttime = DbChange.ToDateTime(dr["starttime"],DateTime.MinValue),
                    Endtime = DbChange.ToDateTime(dr["endtime"],DateTime.MinValue),
                    Balance_id = DbChange.ToInt(dr["balance_id"],0),
                    Parkcode = DbChange.ToString(dr["parkcode"]),
                    Paymentstatus = DbChange.ToInt(dr["paymentstatus"],0),
                    Operator = DbChange.ToInt(dr["operator"],0),
                    Operatetime = DbChange.ToDateTime(dr["operatetime"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ParkBalanceDb</returns>
        public static List<ParkBalanceDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParkBalanceDb>(); 
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
