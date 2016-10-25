using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db;

/*
* 由自动生成工具完成
* 描述:VIEW Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal
{
    /// <summary>
    /// VIEW Dal帮助类
    /// </summary>
    [Serializable]
    public partial class PaymentcacheviewDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from paymentcacheview;";
        //新增插入语句
        protected const string SqlInsert = "insert into paymentcacheview(`OrderNo`,`OrderTime`,`OrderMoney`,`ParkCode`,`ParkName`,`City`,`CarNo`,`UserName`,`PaymentType`,`Purpose`,`Description`) values(?OrderNo,?OrderTime,?OrderMoney,?ParkCode,?ParkName,?City,?CarNo,?UserName,?PaymentType,?Purpose,?Description);";
        #endregion

        #region 参数
        protected const string ParamOrderNo = "?OrderNo";
        protected const string ParamOrderTime = "?OrderTime";
        protected const string ParamOrderMoney = "?OrderMoney";
        protected const string ParamParkCode = "?ParkCode";
        protected const string ParamParkName = "?ParkName";
        protected const string ParamCity = "?City";
        protected const string ParamCarNo = "?CarNo";
        protected const string ParamUserName = "?UserName";
        protected const string ParamPaymentType = "?PaymentType";
        protected const string ParamPurpose = "?Purpose";
        protected const string ParamDescription = "?Description";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of PaymentcacheviewDb</returns>
        public static List<PaymentcacheviewDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="paymentcacheview">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(PaymentcacheviewDb paymentcacheview)
        {
            var param= GetInsertParams(paymentcacheview);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(PaymentcacheviewDb paymentcacheview)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamOrderNo,paymentcacheview.OrderNo),
                    new MySqlParameter(ParamOrderTime,paymentcacheview.OrderTime),
                    new MySqlParameter(ParamOrderMoney,paymentcacheview.OrderMoney),
                    new MySqlParameter(ParamParkCode,paymentcacheview.ParkCode),
                    new MySqlParameter(ParamParkName,paymentcacheview.ParkName),
                    new MySqlParameter(ParamCity,paymentcacheview.City),
                    new MySqlParameter(ParamCarNo,paymentcacheview.CarNo),
                    new MySqlParameter(ParamUserName,paymentcacheview.UserName),
                    new MySqlParameter(ParamPaymentType,paymentcacheview.PaymentType),
                    new MySqlParameter(ParamPurpose,paymentcacheview.Purpose),
                    new MySqlParameter(ParamDescription,paymentcacheview.Description)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>PaymentcacheviewDb</returns>
        public static PaymentcacheviewDb  ConvertToObject(DataRow dr)
        {
            var data = new PaymentcacheviewDb
                {
                    OrderNo = DbChange.ToString(dr["OrderNo"]),
                    OrderTime = DbChange.ToDateTime(dr["OrderTime"],DateTime.MinValue),
                    OrderMoney = DbChange.ToDecimal(dr["OrderMoney"],0),
                    ParkCode = DbChange.ToString(dr["ParkCode"]),
                    ParkName = DbChange.ToString(dr["ParkName"]),
                    City = DbChange.ToString(dr["City"]),
                    CarNo = DbChange.ToString(dr["CarNo"]),
                    UserName = DbChange.ToString(dr["UserName"]),
                    PaymentType = DbChange.ToInt(dr["PaymentType"],0),
                    Purpose = DbChange.ToInt(dr["Purpose"],0),
                    Description = DbChange.ToString(dr["Description"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of PaymentcacheviewDb</returns>
        public static List<PaymentcacheviewDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<PaymentcacheviewDb>(); 
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
