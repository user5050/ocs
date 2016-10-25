using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Payment;

/*
* 由自动生成工具完成
* 描述:[payment_role_for_park]停车场支付权限 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Payment
{
    /// <summary>
    /// [payment_role_for_park]停车场支付权限 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class PaymentRoleForParkDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from paymentroleforpark;";
        //新增插入语句
        protected const string SqlInsert = "insert into paymentroleforpark(`ParkID`,`RoleID`) values(?ParkID,?RoleID);";
        #endregion

        #region 参数
        protected const string ParamParkID = "?ParkID";
        protected const string ParamRoleID = "?RoleID";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of PaymentRoleForParkDb</returns>
        public static List<PaymentRoleForParkDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="paymentroleforpark">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(PaymentRoleForParkDb paymentroleforpark)
        {
            var param= GetInsertParams(paymentroleforpark);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(PaymentRoleForParkDb paymentroleforpark)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkID,paymentroleforpark.ParkID),
                    new MySqlParameter(ParamRoleID,paymentroleforpark.RoleID)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>PaymentRoleForParkDb</returns>
        public static PaymentRoleForParkDb  ConvertToObject(DataRow dr)
        {
            var data = new PaymentRoleForParkDb
                {
                    ParkID = DbChange.ToInt(dr["ParkID"],0),
                    RoleID = DbChange.ToInt(dr["RoleID"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of PaymentRoleForParkDb</returns>
        public static List<PaymentRoleForParkDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<PaymentRoleForParkDb>(); 
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
