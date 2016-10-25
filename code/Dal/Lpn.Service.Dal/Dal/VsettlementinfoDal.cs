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
    public partial class VsettlementinfoDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from vsettlementinfo;";
        //新增插入语句
        protected const string SqlInsert = "insert into vsettlementinfo(`settlementID`,`parkid`,`parkcode`,`parkname`,`year`,`month`,`allMoney`,`handlingFee`,`actualPayMoney`,`certificateImg`,`certificateMemo`,`paymentStatus`,`operatorname`,`operateTime`,`TillDate`,`startTime`,`endTime`) values(?settlementID,?parkid,?parkcode,?parkname,?year,?month,?allMoney,?handlingFee,?actualPayMoney,?certificateImg,?certificateMemo,?paymentStatus,?operatorname,?operateTime,?TillDate,?startTime,?endTime);";
        #endregion

        #region 参数
        protected const string ParamsettlementID = "?settlementID";
        protected const string Paramparkid = "?parkid";
        protected const string Paramparkcode = "?parkcode";
        protected const string Paramparkname = "?parkname";
        protected const string Paramyear = "?year";
        protected const string Parammonth = "?month";
        protected const string ParamallMoney = "?allMoney";
        protected const string ParamhandlingFee = "?handlingFee";
        protected const string ParamactualPayMoney = "?actualPayMoney";
        protected const string ParamcertificateImg = "?certificateImg";
        protected const string ParamcertificateMemo = "?certificateMemo";
        protected const string ParampaymentStatus = "?paymentStatus";
        protected const string Paramoperatorname = "?operatorname";
        protected const string ParamoperateTime = "?operateTime";
        protected const string ParamTillDate = "?TillDate";
        protected const string ParamstartTime = "?startTime";
        protected const string ParamendTime = "?endTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of VsettlementinfoDb</returns>
        public static List<VsettlementinfoDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="vsettlementinfo">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(VsettlementinfoDb vsettlementinfo)
        {
            var param= GetInsertParams(vsettlementinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(VsettlementinfoDb vsettlementinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamsettlementID,vsettlementinfo.SettlementID),
                    new MySqlParameter(Paramparkid,vsettlementinfo.Parkid),
                    new MySqlParameter(Paramparkcode,vsettlementinfo.Parkcode),
                    new MySqlParameter(Paramparkname,vsettlementinfo.Parkname),
                    new MySqlParameter(Paramyear,vsettlementinfo.Year),
                    new MySqlParameter(Parammonth,vsettlementinfo.Month),
                    new MySqlParameter(ParamallMoney,vsettlementinfo.AllMoney),
                    new MySqlParameter(ParamhandlingFee,vsettlementinfo.HandlingFee),
                    new MySqlParameter(ParamactualPayMoney,vsettlementinfo.ActualPayMoney),
                    new MySqlParameter(ParamcertificateImg,vsettlementinfo.CertificateImg),
                    new MySqlParameter(ParamcertificateMemo,vsettlementinfo.CertificateMemo),
                    new MySqlParameter(ParampaymentStatus,vsettlementinfo.PaymentStatus),
                    new MySqlParameter(Paramoperatorname,vsettlementinfo.Operatorname),
                    new MySqlParameter(ParamoperateTime,vsettlementinfo.OperateTime),
                    new MySqlParameter(ParamTillDate,vsettlementinfo.TillDate),
                    new MySqlParameter(ParamstartTime,vsettlementinfo.StartTime),
                    new MySqlParameter(ParamendTime,vsettlementinfo.EndTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>VsettlementinfoDb</returns>
        public static VsettlementinfoDb  ConvertToObject(DataRow dr)
        {
            var data = new VsettlementinfoDb
                {
                    SettlementID = DbChange.ToInt(dr["settlementID"],0),
                    Parkid = DbChange.ToInt(dr["parkid"],0),
                    Parkcode = DbChange.ToString(dr["parkcode"]),
                    Parkname = DbChange.ToString(dr["parkname"]),
                    Year = DbChange.ToInt(dr["year"],0),
                    Month = DbChange.ToInt(dr["month"],0),
                    AllMoney = DbChange.ToDecimal(dr["allMoney"],0),
                    HandlingFee = DbChange.ToDecimal(dr["handlingFee"],0),
                    ActualPayMoney = DbChange.ToDecimal(dr["actualPayMoney"],0),
                    CertificateImg = DbChange.ToString(dr["certificateImg"]),
                    CertificateMemo = DbChange.ToString(dr["certificateMemo"]),
                    PaymentStatus = DbChange.ToInt(dr["paymentStatus"],0),
                    Operatorname = DbChange.ToString(dr["operatorname"]),
                    OperateTime = DbChange.ToDateTime(dr["operateTime"],DateTime.MinValue),
                    TillDate = DbChange.ToInt(dr["TillDate"],0),
                    StartTime = DbChange.ToDateTime(dr["startTime"],DateTime.MinValue),
                    EndTime = DbChange.ToDateTime(dr["endTime"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of VsettlementinfoDb</returns>
        public static List<VsettlementinfoDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<VsettlementinfoDb>(); 
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
