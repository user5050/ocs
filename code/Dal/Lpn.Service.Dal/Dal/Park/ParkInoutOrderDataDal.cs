using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Park;

/*
* 由自动生成工具完成
* 描述:[Park_inout_order_data]停车场预约流量统计 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Park
{
    /// <summary>
    /// [Park_inout_order_data]停车场预约流量统计 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ParkInoutOrderDataDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parkinoutorderdata;";
        //新增插入语句
        protected const string SqlInsert = "insert into parkinoutorderdata(`ParkCode`,`EventYear`,`EventMonth`,`EventDay`,`H0`,`H1`,`H2`,`H3`,`H4`,`H5`,`H6`,`H7`,`H8`,`H9`,`H10`,`H11`,`H12`,`H13`,`H14`,`H15`,`H16`,`H17`,`H18`,`H19`,`H20`,`H21`,`H22`,`H23`,`Type`,`TillDate`) values(?ParkCode,?EventYear,?EventMonth,?EventDay,?H0,?H1,?H2,?H3,?H4,?H5,?H6,?H7,?H8,?H9,?H10,?H11,?H12,?H13,?H14,?H15,?H16,?H17,?H18,?H19,?H20,?H21,?H22,?H23,?Type,?TillDate);";
        #endregion

        #region 参数
        protected const string ParamParkCode = "?ParkCode";
        protected const string ParamEventYear = "?EventYear";
        protected const string ParamEventMonth = "?EventMonth";
        protected const string ParamEventDay = "?EventDay";
        protected const string ParamH0 = "?H0";
        protected const string ParamH1 = "?H1";
        protected const string ParamH2 = "?H2";
        protected const string ParamH3 = "?H3";
        protected const string ParamH4 = "?H4";
        protected const string ParamH5 = "?H5";
        protected const string ParamH6 = "?H6";
        protected const string ParamH7 = "?H7";
        protected const string ParamH8 = "?H8";
        protected const string ParamH9 = "?H9";
        protected const string ParamH10 = "?H10";
        protected const string ParamH11 = "?H11";
        protected const string ParamH12 = "?H12";
        protected const string ParamH13 = "?H13";
        protected const string ParamH14 = "?H14";
        protected const string ParamH15 = "?H15";
        protected const string ParamH16 = "?H16";
        protected const string ParamH17 = "?H17";
        protected const string ParamH18 = "?H18";
        protected const string ParamH19 = "?H19";
        protected const string ParamH20 = "?H20";
        protected const string ParamH21 = "?H21";
        protected const string ParamH22 = "?H22";
        protected const string ParamH23 = "?H23";
        protected const string ParamType = "?Type";
        protected const string ParamTillDate = "?TillDate";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParkInoutOrderDataDb</returns>
        public static List<ParkInoutOrderDataDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parkinoutorderdata">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParkInoutOrderDataDb parkinoutorderdata)
        {
            var param= GetInsertParams(parkinoutorderdata);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParkInoutOrderDataDb parkinoutorderdata)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkCode,parkinoutorderdata.ParkCode),
                    new MySqlParameter(ParamEventYear,parkinoutorderdata.EventYear),
                    new MySqlParameter(ParamEventMonth,parkinoutorderdata.EventMonth),
                    new MySqlParameter(ParamEventDay,parkinoutorderdata.EventDay),
                    new MySqlParameter(ParamH0,parkinoutorderdata.H0),
                    new MySqlParameter(ParamH1,parkinoutorderdata.H1),
                    new MySqlParameter(ParamH2,parkinoutorderdata.H2),
                    new MySqlParameter(ParamH3,parkinoutorderdata.H3),
                    new MySqlParameter(ParamH4,parkinoutorderdata.H4),
                    new MySqlParameter(ParamH5,parkinoutorderdata.H5),
                    new MySqlParameter(ParamH6,parkinoutorderdata.H6),
                    new MySqlParameter(ParamH7,parkinoutorderdata.H7),
                    new MySqlParameter(ParamH8,parkinoutorderdata.H8),
                    new MySqlParameter(ParamH9,parkinoutorderdata.H9),
                    new MySqlParameter(ParamH10,parkinoutorderdata.H10),
                    new MySqlParameter(ParamH11,parkinoutorderdata.H11),
                    new MySqlParameter(ParamH12,parkinoutorderdata.H12),
                    new MySqlParameter(ParamH13,parkinoutorderdata.H13),
                    new MySqlParameter(ParamH14,parkinoutorderdata.H14),
                    new MySqlParameter(ParamH15,parkinoutorderdata.H15),
                    new MySqlParameter(ParamH16,parkinoutorderdata.H16),
                    new MySqlParameter(ParamH17,parkinoutorderdata.H17),
                    new MySqlParameter(ParamH18,parkinoutorderdata.H18),
                    new MySqlParameter(ParamH19,parkinoutorderdata.H19),
                    new MySqlParameter(ParamH20,parkinoutorderdata.H20),
                    new MySqlParameter(ParamH21,parkinoutorderdata.H21),
                    new MySqlParameter(ParamH22,parkinoutorderdata.H22),
                    new MySqlParameter(ParamH23,parkinoutorderdata.H23),
                    new MySqlParameter(ParamType,parkinoutorderdata.Type),
                    new MySqlParameter(ParamTillDate,parkinoutorderdata.TillDate)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParkInoutOrderDataDb</returns>
        public static ParkInoutOrderDataDb  ConvertToObject(DataRow dr)
        {
            var data = new ParkInoutOrderDataDb
                {
                    ParkCode = DbChange.ToString(dr["ParkCode"]),
                    EventYear = DbChange.ToInt(dr["EventYear"],0),
                    EventMonth = DbChange.ToInt(dr["EventMonth"],0),
                    EventDay = DbChange.ToInt(dr["EventDay"],0),
                    H0 = DbChange.ToInt(dr["H0"],0),
                    H1 = DbChange.ToInt(dr["H1"],0),
                    H2 = DbChange.ToInt(dr["H2"],0),
                    H3 = DbChange.ToInt(dr["H3"],0),
                    H4 = DbChange.ToInt(dr["H4"],0),
                    H5 = DbChange.ToInt(dr["H5"],0),
                    H6 = DbChange.ToInt(dr["H6"],0),
                    H7 = DbChange.ToInt(dr["H7"],0),
                    H8 = DbChange.ToInt(dr["H8"],0),
                    H9 = DbChange.ToInt(dr["H9"],0),
                    H10 = DbChange.ToInt(dr["H10"],0),
                    H11 = DbChange.ToInt(dr["H11"],0),
                    H12 = DbChange.ToInt(dr["H12"],0),
                    H13 = DbChange.ToInt(dr["H13"],0),
                    H14 = DbChange.ToInt(dr["H14"],0),
                    H15 = DbChange.ToInt(dr["H15"],0),
                    H16 = DbChange.ToInt(dr["H16"],0),
                    H17 = DbChange.ToInt(dr["H17"],0),
                    H18 = DbChange.ToInt(dr["H18"],0),
                    H19 = DbChange.ToInt(dr["H19"],0),
                    H20 = DbChange.ToInt(dr["H20"],0),
                    H21 = DbChange.ToInt(dr["H21"],0),
                    H22 = DbChange.ToInt(dr["H22"],0),
                    H23 = DbChange.ToInt(dr["H23"],0),
                    Type = DbChange.ToInt(dr["Type"],0),
                    TillDate = DbChange.ToInt(dr["TillDate"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ParkInoutOrderDataDb</returns>
        public static List<ParkInoutOrderDataDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParkInoutOrderDataDb>(); 
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
