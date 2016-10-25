using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Charge;

/*
* 由自动生成工具完成
* 描述:[charge_settlement_info]e泊账户充值的月对账单 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Charge
{
    /// <summary>
    /// [charge_settlement_info]e泊账户充值的月对账单 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ChargeSettlementInfoDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from chargesettlementinfo;";
        //新增插入语句
        protected const string SqlInsert = "insert into chargesettlementinfo(`Year`,`Month`,`AllMoney`,`OperateTime`) values(?Year,?Month,?AllMoney,?OperateTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from chargesettlementinfo where `SettlementID`=?SettlementID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update chargesettlementinfo set `Year`=?Year,`Month`=?Month,`AllMoney`=?AllMoney,`OperateTime`=?OperateTime where `SettlementID`=?SettlementID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from chargesettlementinfo  where `SettlementID`=?SettlementID;";
        #endregion

        #region 参数
        protected const string ParamSettlementID = "?SettlementID";
        protected const string ParamYear = "?Year";
        protected const string ParamMonth = "?Month";
        protected const string ParamAllMoney = "?AllMoney";
        protected const string ParamOperateTime = "?OperateTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ChargeSettlementInfoDb</returns>
        public static List<ChargeSettlementInfoDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="chargesettlementinfo">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ChargeSettlementInfoDb chargesettlementinfo)
        {
            var param= GetInsertParams(chargesettlementinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="settlementID">对账单编号</param> 
        /// <returns>ChargeSettlementInfoDb</returns>
        public static ChargeSettlementInfoDb  GetByPriKey(int settlementID)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamSettlementID,settlementID)
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
        /// <param name="chargesettlementinfo">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ChargeSettlementInfoDb chargesettlementinfo)
        {
            var param= GetUpdateParams(chargesettlementinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="settlementID">对账单编号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(int settlementID)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamSettlementID,settlementID)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(ChargeSettlementInfoDb chargesettlementinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamSettlementID,chargesettlementinfo.SettlementID),
                    new MySqlParameter(ParamYear,chargesettlementinfo.Year),
                    new MySqlParameter(ParamMonth,chargesettlementinfo.Month),
                    new MySqlParameter(ParamAllMoney,chargesettlementinfo.AllMoney),
                    new MySqlParameter(ParamOperateTime,chargesettlementinfo.OperateTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ChargeSettlementInfoDb chargesettlementinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamYear,chargesettlementinfo.Year),
                    new MySqlParameter(ParamMonth,chargesettlementinfo.Month),
                    new MySqlParameter(ParamAllMoney,chargesettlementinfo.AllMoney),
                    new MySqlParameter(ParamOperateTime,chargesettlementinfo.OperateTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ChargeSettlementInfoDb</returns>
        public static ChargeSettlementInfoDb  ConvertToObject(DataRow dr)
        {
            var data = new ChargeSettlementInfoDb
                {
                    SettlementID = DbChange.ToInt(dr["SettlementID"],0),
                    Year = DbChange.ToInt(dr["Year"],0),
                    Month = DbChange.ToInt(dr["Month"],0),
                    AllMoney = DbChange.ToDecimal(dr["AllMoney"],0),
                    OperateTime = DbChange.ToDateTime(dr["OperateTime"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ChargeSettlementInfoDb</returns>
        public static List<ChargeSettlementInfoDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ChargeSettlementInfoDb>(); 
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
