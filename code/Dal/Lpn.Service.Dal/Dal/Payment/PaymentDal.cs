using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Payment;

/*
* 由自动生成工具完成
* 描述:[payment_]支付信息 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Payment
{
    /// <summary>
    /// [payment_]支付信息 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class PaymentDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from payment;";
        //新增插入语句
        protected const string SqlInsert = "insert into payment(`UserID`,`Payment`,`PayAccount`) values(?UserID,?Payment,?PayAccount);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from payment where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update payment set `UserID`=?UserID,`Payment`=?Payment,`PayAccount`=?PayAccount where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from payment  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamUserID = "?UserID";
        protected const string ParamPayment = "?Payment";
        protected const string ParamPayAccount = "?PayAccount";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of PaymentDb</returns>
        public static List<PaymentDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="payment">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(PaymentDb payment)
        {
            var param= GetInsertParams(payment);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">支付编号</param> 
        /// <returns>PaymentDb</returns>
        public static PaymentDb  GetByPriKey(int id)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,id)
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
        /// <param name="payment">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(PaymentDb payment)
        {
            var param= GetUpdateParams(payment);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">支付编号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(int id)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,id)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(PaymentDb payment)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,payment.ID),
                    new MySqlParameter(ParamUserID,payment.UserID),
                    new MySqlParameter(ParamPayment,payment.Payment),
                    new MySqlParameter(ParamPayAccount,payment.PayAccount)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(PaymentDb payment)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUserID,payment.UserID),
                    new MySqlParameter(ParamPayment,payment.Payment),
                    new MySqlParameter(ParamPayAccount,payment.PayAccount)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>PaymentDb</returns>
        public static PaymentDb  ConvertToObject(DataRow dr)
        {
            var data = new PaymentDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    UserID = DbChange.ToInt(dr["UserID"],0),
                    Payment = DbChange.ToString(dr["Payment"]),
                    PayAccount = DbChange.ToString(dr["PayAccount"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of PaymentDb</returns>
        public static List<PaymentDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<PaymentDb>(); 
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
