using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Park;

/*
* 由自动生成工具完成
* 描述:[park_settlement_rate]停车场结算费率 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Park
{
    /// <summary>
    /// [park_settlement_rate]停车场结算费率 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ParkSettlementRateDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parksettlementrate;";
        //新增插入语句
        protected const string SqlInsert = "insert into parksettlementrate(`ParkID`,`SettlementRate`,`SettlementSort`,`Operator`) values(?ParkID,?SettlementRate,?SettlementSort,?Operator);";
        #endregion

        #region 参数
        protected const string ParamParkID = "?ParkID";
        protected const string ParamSettlementRate = "?SettlementRate";
        protected const string ParamSettlementSort = "?SettlementSort";
        protected const string ParamOperator = "?Operator";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParkSettlementRateDb</returns>
        public static List<ParkSettlementRateDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parksettlementrate">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParkSettlementRateDb parksettlementrate)
        {
            var param= GetInsertParams(parksettlementrate);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParkSettlementRateDb parksettlementrate)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkID,parksettlementrate.ParkID),
                    new MySqlParameter(ParamSettlementRate,parksettlementrate.SettlementRate),
                    new MySqlParameter(ParamSettlementSort,parksettlementrate.SettlementSort),
                    new MySqlParameter(ParamOperator,parksettlementrate.Operator)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParkSettlementRateDb</returns>
        public static ParkSettlementRateDb  ConvertToObject(DataRow dr)
        {
            var data = new ParkSettlementRateDb
                {
                    ParkID = DbChange.ToInt(dr["ParkID"],0),
                    SettlementRate = DbChange.ToDecimal(dr["SettlementRate"],0),
                    SettlementSort = DbChange.ToInt(dr["SettlementSort"],0),
                    Operator = DbChange.ToInt(dr["Operator"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ParkSettlementRateDb</returns>
        public static List<ParkSettlementRateDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParkSettlementRateDb>(); 
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
