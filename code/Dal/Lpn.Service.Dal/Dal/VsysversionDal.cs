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
    public partial class VsysversionDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from vsysversions;";
        //新增插入语句
        protected const string SqlInsert = "insert into vsysversions(`parkcode`,`parkname`,`currentVersion`,`newVersion`,`lastUpdateTime`,`locationName`,`operatorid`,`operatorName`,`mark`,`sid`,`id`,`expireDate`,`RenewalLastTime`,`RenewalTimes`,`RenewalUser`,`payed`) values(?parkcode,?parkname,?currentVersion,?newVersion,?lastUpdateTime,?locationName,?operatorid,?operatorName,?mark,?sid,?id,?expireDate,?RenewalLastTime,?RenewalTimes,?RenewalUser,?payed);";
        #endregion

        #region 参数
        protected const string Paramparkcode = "?parkcode";
        protected const string Paramparkname = "?parkname";
        protected const string ParamcurrentVersion = "?currentVersion";
        protected const string ParamnewVersion = "?newVersion";
        protected const string ParamlastUpdateTime = "?lastUpdateTime";
        protected const string ParamlocationName = "?locationName";
        protected const string Paramoperatorid = "?operatorid";
        protected const string ParamoperatorName = "?operatorName";
        protected const string Parammark = "?mark";
        protected const string Paramsid = "?sid";
        protected const string Paramid = "?id";
        protected const string ParamexpireDate = "?expireDate";
        protected const string ParamRenewalLastTime = "?RenewalLastTime";
        protected const string ParamRenewalTimes = "?RenewalTimes";
        protected const string ParamRenewalUser = "?RenewalUser";
        protected const string Parampayed = "?payed";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of VsysversionDb</returns>
        public static List<VsysversionDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="vsysversion">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(VsysversionDb vsysversion)
        {
            var param= GetInsertParams(vsysversion);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(VsysversionDb vsysversion)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramparkcode,vsysversion.Parkcode),
                    new MySqlParameter(Paramparkname,vsysversion.Parkname),
                    new MySqlParameter(ParamcurrentVersion,vsysversion.CurrentVersion),
                    new MySqlParameter(ParamnewVersion,vsysversion.NewVersion),
                    new MySqlParameter(ParamlastUpdateTime,vsysversion.LastUpdateTime),
                    new MySqlParameter(ParamlocationName,vsysversion.LocationName),
                    new MySqlParameter(Paramoperatorid,vsysversion.Operatorid),
                    new MySqlParameter(ParamoperatorName,vsysversion.OperatorName),
                    new MySqlParameter(Parammark,vsysversion.Mark),
                    new MySqlParameter(Paramsid,vsysversion.Sid),
                    new MySqlParameter(Paramid,vsysversion.Id),
                    new MySqlParameter(ParamexpireDate,vsysversion.ExpireDate),
                    new MySqlParameter(ParamRenewalLastTime,vsysversion.RenewalLastTime),
                    new MySqlParameter(ParamRenewalTimes,vsysversion.RenewalTimes),
                    new MySqlParameter(ParamRenewalUser,vsysversion.RenewalUser),
                    new MySqlParameter(Parampayed,vsysversion.Payed)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>VsysversionDb</returns>
        public static VsysversionDb  ConvertToObject(DataRow dr)
        {
            var data = new VsysversionDb
                {
                    Parkcode = DbChange.ToString(dr["parkcode"]),
                    Parkname = DbChange.ToString(dr["parkname"]),
                    CurrentVersion = DbChange.ToString(dr["currentVersion"]),
                    NewVersion = DbChange.ToString(dr["newVersion"]),
                    LastUpdateTime = DbChange.ToString(dr["lastUpdateTime"]),
                    LocationName = DbChange.ToString(dr["locationName"]),
                    Operatorid = DbChange.ToInt(dr["operatorid"],0),
                    OperatorName = DbChange.ToString(dr["operatorName"]),
                    Mark = DbChange.ToString(dr["mark"]),
                    Sid = DbChange.ToInt(dr["sid"],0),
                    Id = DbChange.ToInt(dr["id"],0),
                    ExpireDate = DbChange.ToString(dr["expireDate"]),
                    RenewalLastTime = DbChange.ToString(dr["RenewalLastTime"]),
                    RenewalTimes = DbChange.ToInt(dr["RenewalTimes"],0),
                    RenewalUser = DbChange.ToString(dr["RenewalUser"]),
                    Payed = DbChange.ToString(dr["payed"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of VsysversionDb</returns>
        public static List<VsysversionDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<VsysversionDb>(); 
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
