using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Park;

/*
* 由自动生成工具完成
* 描述:[park_settlement_info]停车场结算表 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Park
{
    /// <summary>
    /// [park_settlement_info]停车场结算表 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ParkSettlementInfoDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parksettlementinfo;";
        //新增插入语句
        protected const string SqlInsert = "insert into parksettlementinfo(`ParkID`,`SettlementInterval`,`Year`,`Month`,`AllMoney`,`HandlingFee`,`ActualPayMoney`,`CertificateImg`,`CertificateMemo`,`PaymentStatus`,`Operator`,`OperateTime`,`TillDate`,`StartTime`,`EndTime`,`settelementid`,`parkcode`) values(?ParkID,?SettlementInterval,?Year,?Month,?AllMoney,?HandlingFee,?ActualPayMoney,?CertificateImg,?CertificateMemo,?PaymentStatus,?Operator,?OperateTime,?TillDate,?StartTime,?EndTime,?settelementid,?parkcode);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from parksettlementinfo where `SettlementID`=?SettlementID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update parksettlementinfo set `ParkID`=?ParkID,`SettlementInterval`=?SettlementInterval,`Year`=?Year,`Month`=?Month,`AllMoney`=?AllMoney,`HandlingFee`=?HandlingFee,`ActualPayMoney`=?ActualPayMoney,`CertificateImg`=?CertificateImg,`CertificateMemo`=?CertificateMemo,`PaymentStatus`=?PaymentStatus,`Operator`=?Operator,`OperateTime`=?OperateTime,`TillDate`=?TillDate,`StartTime`=?StartTime,`EndTime`=?EndTime,`settelementid`=?settelementid,`parkcode`=?parkcode where `SettlementID`=?SettlementID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from parksettlementinfo  where `SettlementID`=?SettlementID;";
        #endregion

        #region 参数
        protected const string ParamSettlementID = "?SettlementID";
        protected const string ParamParkID = "?ParkID";
        protected const string ParamSettlementInterval = "?SettlementInterval";
        protected const string ParamYear = "?Year";
        protected const string ParamMonth = "?Month";
        protected const string ParamAllMoney = "?AllMoney";
        protected const string ParamHandlingFee = "?HandlingFee";
        protected const string ParamActualPayMoney = "?ActualPayMoney";
        protected const string ParamCertificateImg = "?CertificateImg";
        protected const string ParamCertificateMemo = "?CertificateMemo";
        protected const string ParamPaymentStatus = "?PaymentStatus";
        protected const string ParamOperator = "?Operator";
        protected const string ParamOperateTime = "?OperateTime";
        protected const string ParamTillDate = "?TillDate";
        protected const string ParamStartTime = "?StartTime";
        protected const string ParamEndTime = "?EndTime";
        protected const string Paramsettelementid = "?settelementid";
        protected const string Paramparkcode = "?parkcode";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParkSettlementInfoDb</returns>
        public static List<ParkSettlementInfoDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parksettlementinfo">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParkSettlementInfoDb parksettlementinfo)
        {
            var param= GetInsertParams(parksettlementinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="settlementID">停车场结算表编号</param> 
        /// <returns>ParkSettlementInfoDb</returns>
        public static ParkSettlementInfoDb  GetByPriKey(int settlementID)
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
        /// <param name="parksettlementinfo">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ParkSettlementInfoDb parksettlementinfo)
        {
            var param= GetUpdateParams(parksettlementinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="settlementID">停车场结算表编号</param> 
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
        public static MySqlParameter[]  GetUpdateParams(ParkSettlementInfoDb parksettlementinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamSettlementID,parksettlementinfo.SettlementID),
                    new MySqlParameter(ParamParkID,parksettlementinfo.ParkID),
                    new MySqlParameter(ParamSettlementInterval,parksettlementinfo.SettlementInterval),
                    new MySqlParameter(ParamYear,parksettlementinfo.Year),
                    new MySqlParameter(ParamMonth,parksettlementinfo.Month),
                    new MySqlParameter(ParamAllMoney,parksettlementinfo.AllMoney),
                    new MySqlParameter(ParamHandlingFee,parksettlementinfo.HandlingFee),
                    new MySqlParameter(ParamActualPayMoney,parksettlementinfo.ActualPayMoney),
                    new MySqlParameter(ParamCertificateImg,parksettlementinfo.CertificateImg),
                    new MySqlParameter(ParamCertificateMemo,parksettlementinfo.CertificateMemo),
                    new MySqlParameter(ParamPaymentStatus,parksettlementinfo.PaymentStatus),
                    new MySqlParameter(ParamOperator,parksettlementinfo.Operator),
                    new MySqlParameter(ParamOperateTime,parksettlementinfo.OperateTime),
                    new MySqlParameter(ParamTillDate,parksettlementinfo.TillDate),
                    new MySqlParameter(ParamStartTime,parksettlementinfo.StartTime),
                    new MySqlParameter(ParamEndTime,parksettlementinfo.EndTime),
                    new MySqlParameter(Paramsettelementid,parksettlementinfo.Settelementid),
                    new MySqlParameter(Paramparkcode,parksettlementinfo.Parkcode)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParkSettlementInfoDb parksettlementinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkID,parksettlementinfo.ParkID),
                    new MySqlParameter(ParamSettlementInterval,parksettlementinfo.SettlementInterval),
                    new MySqlParameter(ParamYear,parksettlementinfo.Year),
                    new MySqlParameter(ParamMonth,parksettlementinfo.Month),
                    new MySqlParameter(ParamAllMoney,parksettlementinfo.AllMoney),
                    new MySqlParameter(ParamHandlingFee,parksettlementinfo.HandlingFee),
                    new MySqlParameter(ParamActualPayMoney,parksettlementinfo.ActualPayMoney),
                    new MySqlParameter(ParamCertificateImg,parksettlementinfo.CertificateImg),
                    new MySqlParameter(ParamCertificateMemo,parksettlementinfo.CertificateMemo),
                    new MySqlParameter(ParamPaymentStatus,parksettlementinfo.PaymentStatus),
                    new MySqlParameter(ParamOperator,parksettlementinfo.Operator),
                    new MySqlParameter(ParamOperateTime,parksettlementinfo.OperateTime),
                    new MySqlParameter(ParamTillDate,parksettlementinfo.TillDate),
                    new MySqlParameter(ParamStartTime,parksettlementinfo.StartTime),
                    new MySqlParameter(ParamEndTime,parksettlementinfo.EndTime),
                    new MySqlParameter(Paramsettelementid,parksettlementinfo.Settelementid),
                    new MySqlParameter(Paramparkcode,parksettlementinfo.Parkcode)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParkSettlementInfoDb</returns>
        public static ParkSettlementInfoDb  ConvertToObject(DataRow dr)
        {
            var data = new ParkSettlementInfoDb
                {
                    SettlementID = DbChange.ToInt(dr["SettlementID"],0),
                    ParkID = DbChange.ToInt(dr["ParkID"],0),
                    SettlementInterval = DbChange.ToInt(dr["SettlementInterval"],0),
                    Year = DbChange.ToInt(dr["Year"],0),
                    Month = DbChange.ToInt(dr["Month"],0),
                    AllMoney = DbChange.ToDecimal(dr["AllMoney"],0),
                    HandlingFee = DbChange.ToDecimal(dr["HandlingFee"],0),
                    ActualPayMoney = DbChange.ToDecimal(dr["ActualPayMoney"],0),
                    CertificateImg = DbChange.ToString(dr["CertificateImg"]),
                    CertificateMemo = DbChange.ToString(dr["CertificateMemo"]),
                    PaymentStatus = DbChange.ToInt(dr["PaymentStatus"],0),
                    Operator = DbChange.ToInt(dr["Operator"],0),
                    OperateTime = DbChange.ToDateTime(dr["OperateTime"],DateTime.MinValue),
                    TillDate = DbChange.ToInt(dr["TillDate"],0),
                    StartTime = DbChange.ToDateTime(dr["StartTime"],DateTime.MinValue),
                    EndTime = DbChange.ToDateTime(dr["EndTime"],DateTime.MinValue),
                    Settelementid = DbChange.ToString(dr["settelementid"]),
                    Parkcode = DbChange.ToString(dr["parkcode"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ParkSettlementInfoDb</returns>
        public static List<ParkSettlementInfoDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParkSettlementInfoDb>(); 
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
