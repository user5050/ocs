using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Park;

/*
* 由自动生成工具完成
* 描述:[park_settlement_info_detail]对账单详细结算信息 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Park
{
    /// <summary>
    /// [park_settlement_info_detail]对账单详细结算信息 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ParkSettlementInfoDetailDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parksettlementinfodetail;";
        //新增插入语句
        protected const string SqlInsert = "insert into parksettlementinfodetail(`SettlementID`,`SettlementRate`,`SettlementSort`,`AllMoney`,`HandlingFee`,`PaymentCount`,`OperateTime`) values(?SettlementID,?SettlementRate,?SettlementSort,?AllMoney,?HandlingFee,?PaymentCount,?OperateTime);";
        #endregion

        #region 参数
        protected const string ParamSettlementID = "?SettlementID";
        protected const string ParamSettlementRate = "?SettlementRate";
        protected const string ParamSettlementSort = "?SettlementSort";
        protected const string ParamAllMoney = "?AllMoney";
        protected const string ParamHandlingFee = "?HandlingFee";
        protected const string ParamPaymentCount = "?PaymentCount";
        protected const string ParamOperateTime = "?OperateTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParkSettlementInfoDetailDb</returns>
        public static List<ParkSettlementInfoDetailDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parksettlementinfodetail">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParkSettlementInfoDetailDb parksettlementinfodetail)
        {
            var param= GetInsertParams(parksettlementinfodetail);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParkSettlementInfoDetailDb parksettlementinfodetail)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamSettlementID,parksettlementinfodetail.SettlementID),
                    new MySqlParameter(ParamSettlementRate,parksettlementinfodetail.SettlementRate),
                    new MySqlParameter(ParamSettlementSort,parksettlementinfodetail.SettlementSort),
                    new MySqlParameter(ParamAllMoney,parksettlementinfodetail.AllMoney),
                    new MySqlParameter(ParamHandlingFee,parksettlementinfodetail.HandlingFee),
                    new MySqlParameter(ParamPaymentCount,parksettlementinfodetail.PaymentCount),
                    new MySqlParameter(ParamOperateTime,parksettlementinfodetail.OperateTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParkSettlementInfoDetailDb</returns>
        public static ParkSettlementInfoDetailDb  ConvertToObject(DataRow dr)
        {
            var data = new ParkSettlementInfoDetailDb
                {
                    SettlementID = DbChange.ToDecimal(dr["SettlementID"],0),
                    SettlementRate = DbChange.ToDecimal(dr["SettlementRate"],0),
                    SettlementSort = DbChange.ToInt(dr["SettlementSort"],0),
                    AllMoney = DbChange.ToDecimal(dr["AllMoney"],0),
                    HandlingFee = DbChange.ToDecimal(dr["HandlingFee"],0),
                    PaymentCount = DbChange.ToInt(dr["PaymentCount"],0),
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
        /// <returns>List of ParkSettlementInfoDetailDb</returns>
        public static List<ParkSettlementInfoDetailDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParkSettlementInfoDetailDb>(); 
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
