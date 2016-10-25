using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Insurance;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Insurance
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    [Serializable]
    public partial class InsurancePriceDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from insurance_price;";
        //新增插入语句
        protected const string SqlInsert = "insert into insurance_price(`CarNo`,`Name`,`Tel`,`OrgPrice`,`CompulsoryPrice`,`VesselTax`,`TotalPrice`,`OrderPrice`,`RowTime`) values(?CarNo,?Name,?Tel,?OrgPrice,?CompulsoryPrice,?VesselTax,?TotalPrice,?OrderPrice,?RowTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from insurance_price where `CarNo`=?CarNo;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update insurance_price set `Name`=?Name,`Tel`=?Tel,`OrgPrice`=?OrgPrice,`CompulsoryPrice`=?CompulsoryPrice,`VesselTax`=?VesselTax,`TotalPrice`=?TotalPrice,`OrderPrice`=?OrderPrice,`RowTime`=?RowTime where `CarNo`=?CarNo;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from insurance_price  where `CarNo`=?CarNo;";
        #endregion

        #region 参数
        protected const string ParamCarNo = "?CarNo";
        protected const string ParamName = "?Name";
        protected const string ParamTel = "?Tel";
        protected const string ParamOrgPrice = "?OrgPrice";
        protected const string ParamCompulsoryPrice = "?CompulsoryPrice";
        protected const string ParamVesselTax = "?VesselTax";
        protected const string ParamTotalPrice = "?TotalPrice";
        protected const string ParamOrderPrice = "?OrderPrice";
        protected const string ParamRowTime = "?RowTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of InsurancePriceDb</returns>
        public static List<InsurancePriceDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="insuranceprice">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(InsurancePriceDb insuranceprice)
        {
            var param= GetInsertParams(insuranceprice);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="carNo">车牌</param> 
        /// <returns>InsurancePriceDb</returns>
        public static InsurancePriceDb  GetByPriKey(string carNo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCarNo,carNo)
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
        /// <param name="insuranceprice">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(InsurancePriceDb insuranceprice)
        {
            var param= GetUpdateParams(insuranceprice);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="carNo">车牌</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string carNo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCarNo,carNo)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(InsurancePriceDb insuranceprice)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCarNo,insuranceprice.CarNo),
                    new MySqlParameter(ParamName,insuranceprice.Name),
                    new MySqlParameter(ParamTel,insuranceprice.Tel),
                    new MySqlParameter(ParamOrgPrice,insuranceprice.OrgPrice),
                    new MySqlParameter(ParamCompulsoryPrice,insuranceprice.CompulsoryPrice),
                    new MySqlParameter(ParamVesselTax,insuranceprice.VesselTax),
                    new MySqlParameter(ParamTotalPrice,insuranceprice.TotalPrice),
                    new MySqlParameter(ParamOrderPrice,insuranceprice.OrderPrice),
                    new MySqlParameter(ParamRowTime,insuranceprice.RowTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(InsurancePriceDb insuranceprice)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCarNo,insuranceprice.CarNo),
                    new MySqlParameter(ParamName,insuranceprice.Name),
                    new MySqlParameter(ParamTel,insuranceprice.Tel),
                    new MySqlParameter(ParamOrgPrice,insuranceprice.OrgPrice),
                    new MySqlParameter(ParamCompulsoryPrice,insuranceprice.CompulsoryPrice),
                    new MySqlParameter(ParamVesselTax,insuranceprice.VesselTax),
                    new MySqlParameter(ParamTotalPrice,insuranceprice.TotalPrice),
                    new MySqlParameter(ParamOrderPrice,insuranceprice.OrderPrice),
                    new MySqlParameter(ParamRowTime,insuranceprice.RowTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>InsurancePriceDb</returns>
        public static InsurancePriceDb  ConvertToObject(DataRow dr)
        {
            var data = new InsurancePriceDb
                {
                    CarNo = DbChange.ToString(dr["CarNo"]),
                    Name = DbChange.ToString(dr["Name"]),
                    Tel = DbChange.ToString(dr["Tel"]),
                    OrgPrice = DbChange.ToInt(dr["OrgPrice"],0),
                    CompulsoryPrice = DbChange.ToInt(dr["CompulsoryPrice"],0),
                    VesselTax = DbChange.ToInt(dr["VesselTax"],0),
                    TotalPrice = DbChange.ToInt(dr["TotalPrice"],0),
                    OrderPrice = DbChange.ToInt(dr["OrderPrice"],0),
                    RowTime = DbChange.ToDateTime(dr["RowTime"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of InsurancePriceDb</returns>
        public static List<InsurancePriceDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<InsurancePriceDb>(); 
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
