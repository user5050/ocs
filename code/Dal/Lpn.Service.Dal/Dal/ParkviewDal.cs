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
    public partial class ParkviewDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parkview;";
        //新增插入语句
        protected const string SqlInsert = "insert into parkview(`parkname`,`parkaddr`,`parkcompany`,`parklotall`,`lng`,`lat`,`pid`,`status`,`vipcount`,`operatecount`,`parktel`,`id`,`imgurl`,`areacode`,`parkoperator`,`parkissued`,`parklotplan`,`parklotnomechanical`,`parklotmechanical`,`parklotoperate`,`parklotvip`,`ifconnect`,`ip`,`port`,`recordtype`,`parktype`,`parkcode`,`parksort`,`parkin`,`parkout`,`starttime`,`endtime`,`enabled`,`freetime`,`unitprice`,`firstprice`,`firsttime`,`parkstatus`) values(?parkname,?parkaddr,?parkcompany,?parklotall,?lng,?lat,?pid,?status,?vipcount,?operatecount,?parktel,?id,?imgurl,?areacode,?parkoperator,?parkissued,?parklotplan,?parklotnomechanical,?parklotmechanical,?parklotoperate,?parklotvip,?ifconnect,?ip,?port,?recordtype,?parktype,?parkcode,?parksort,?parkin,?parkout,?starttime,?endtime,?enabled,?freetime,?unitprice,?firstprice,?firsttime,?parkstatus);";
        #endregion

        #region 参数
        protected const string Paramparkname = "?parkname";
        protected const string Paramparkaddr = "?parkaddr";
        protected const string Paramparkcompany = "?parkcompany";
        protected const string Paramparklotall = "?parklotall";
        protected const string Paramlng = "?lng";
        protected const string Paramlat = "?lat";
        protected const string Parampid = "?pid";
        protected const string Paramstatus = "?status";
        protected const string Paramvipcount = "?vipcount";
        protected const string Paramoperatecount = "?operatecount";
        protected const string Paramparktel = "?parktel";
        protected const string Paramid = "?id";
        protected const string Paramimgurl = "?imgurl";
        protected const string Paramareacode = "?areacode";
        protected const string Paramparkoperator = "?parkoperator";
        protected const string Paramparkissued = "?parkissued";
        protected const string Paramparklotplan = "?parklotplan";
        protected const string Paramparklotnomechanical = "?parklotnomechanical";
        protected const string Paramparklotmechanical = "?parklotmechanical";
        protected const string Paramparklotoperate = "?parklotoperate";
        protected const string Paramparklotvip = "?parklotvip";
        protected const string Paramifconnect = "?ifconnect";
        protected const string Paramip = "?ip";
        protected const string Paramport = "?port";
        protected const string Paramrecordtype = "?recordtype";
        protected const string Paramparktype = "?parktype";
        protected const string Paramparkcode = "?parkcode";
        protected const string Paramparksort = "?parksort";
        protected const string Paramparkin = "?parkin";
        protected const string Paramparkout = "?parkout";
        protected const string Paramstarttime = "?starttime";
        protected const string Paramendtime = "?endtime";
        protected const string Paramenabled = "?enabled";
        protected const string Paramfreetime = "?freetime";
        protected const string Paramunitprice = "?unitprice";
        protected const string Paramfirstprice = "?firstprice";
        protected const string Paramfirsttime = "?firsttime";
        protected const string Paramparkstatus = "?parkstatus";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParkviewDb</returns>
        public static List<ParkviewDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parkview">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParkviewDb parkview)
        {
            var param= GetInsertParams(parkview);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParkviewDb parkview)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramparkname,parkview.Parkname),
                    new MySqlParameter(Paramparkaddr,parkview.Parkaddr),
                    new MySqlParameter(Paramparkcompany,parkview.Parkcompany),
                    new MySqlParameter(Paramparklotall,parkview.Parklotall),
                    new MySqlParameter(Paramlng,parkview.Lng),
                    new MySqlParameter(Paramlat,parkview.Lat),
                    new MySqlParameter(Parampid,parkview.Pid),
                    new MySqlParameter(Paramstatus,parkview.Status),
                    new MySqlParameter(Paramvipcount,parkview.Vipcount),
                    new MySqlParameter(Paramoperatecount,parkview.Operatecount),
                    new MySqlParameter(Paramparktel,parkview.Parktel),
                    new MySqlParameter(Paramid,parkview.Id),
                    new MySqlParameter(Paramimgurl,parkview.Imgurl),
                    new MySqlParameter(Paramareacode,parkview.Areacode),
                    new MySqlParameter(Paramparkoperator,parkview.Parkoperator),
                    new MySqlParameter(Paramparkissued,parkview.Parkissued),
                    new MySqlParameter(Paramparklotplan,parkview.Parklotplan),
                    new MySqlParameter(Paramparklotnomechanical,parkview.Parklotnomechanical),
                    new MySqlParameter(Paramparklotmechanical,parkview.Parklotmechanical),
                    new MySqlParameter(Paramparklotoperate,parkview.Parklotoperate),
                    new MySqlParameter(Paramparklotvip,parkview.Parklotvip),
                    new MySqlParameter(Paramifconnect,parkview.Ifconnect),
                    new MySqlParameter(Paramip,parkview.Ip),
                    new MySqlParameter(Paramport,parkview.Port),
                    new MySqlParameter(Paramrecordtype,parkview.Recordtype),
                    new MySqlParameter(Paramparktype,parkview.Parktype),
                    new MySqlParameter(Paramparkcode,parkview.Parkcode),
                    new MySqlParameter(Paramparksort,parkview.Parksort),
                    new MySqlParameter(Paramparkin,parkview.Parkin),
                    new MySqlParameter(Paramparkout,parkview.Parkout),
                    new MySqlParameter(Paramstarttime,parkview.Starttime),
                    new MySqlParameter(Paramendtime,parkview.Endtime),
                    new MySqlParameter(Paramenabled,parkview.Enabled),
                    new MySqlParameter(Paramfreetime,parkview.Freetime),
                    new MySqlParameter(Paramunitprice,parkview.Unitprice),
                    new MySqlParameter(Paramfirstprice,parkview.Firstprice),
                    new MySqlParameter(Paramfirsttime,parkview.Firsttime),
                    new MySqlParameter(Paramparkstatus,parkview.Parkstatus)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParkviewDb</returns>
        public static ParkviewDb  ConvertToObject(DataRow dr)
        {
            var data = new ParkviewDb
                {
                    Parkname = DbChange.ToString(dr["parkname"]),
                    Parkaddr = DbChange.ToString(dr["parkaddr"]),
                    Parkcompany = DbChange.ToString(dr["parkcompany"]),
                    Parklotall = DbChange.ToInt(dr["parklotall"],0),
                    Lng = DbChange.ToDouble(dr["lng"],0D),
                    Lat = DbChange.ToDouble(dr["lat"],0D),
                    Pid = DbChange.ToInt(dr["pid"],0),
                    Status = DbChange.ToInt(dr["status"],-1),
                    Vipcount = DbChange.ToInt(dr["vipcount"],0),
                    Operatecount = DbChange.ToInt(dr["operatecount"],0),
                    Parktel = DbChange.ToString(dr["parktel"]),
                    Id = DbChange.ToInt(dr["id"],0),
                    Imgurl = DbChange.ToString(dr["imgurl"]),
                    Areacode = DbChange.ToString(dr["areacode"]),
                    Parkoperator = DbChange.ToString(dr["parkoperator"]),
                    Parkissued = DbChange.ToString(dr["parkissued"]),
                    Parklotplan = DbChange.ToInt(dr["parklotplan"],0),
                    Parklotnomechanical = DbChange.ToInt(dr["parklotnomechanical"],0),
                    Parklotmechanical = DbChange.ToInt(dr["parklotmechanical"],0),
                    Parklotoperate = DbChange.ToInt(dr["parklotoperate"],0),
                    Parklotvip = DbChange.ToInt(dr["parklotvip"],0),
                    Ifconnect = DbChange.ToInt(dr["ifconnect"],0),
                    Ip = DbChange.ToString(dr["ip"]),
                    Port = DbChange.ToInt(dr["port"],0),
                    Recordtype = DbChange.ToInt(dr["recordtype"],0),
                    Parktype = DbChange.ToString(dr["parktype"]),
                    Parkcode = DbChange.ToString(dr["parkcode"]),
                    Parksort = DbChange.ToString(dr["parksort"]),
                    Parkin = DbChange.ToInt(dr["parkin"],0),
                    Parkout = DbChange.ToInt(dr["parkout"],0),
                    Starttime = DbChange.ToDateTime(dr["starttime"],DateTime.MinValue),
                    Endtime = DbChange.ToDateTime(dr["endtime"],DateTime.MinValue),
                    Enabled = DbChange.ToInt(dr["enabled"],-1),
                    Freetime = DbChange.ToInt(dr["freetime"],0),
                    Unitprice = DbChange.ToInt(dr["unitprice"],0),
                    Firstprice = DbChange.ToInt(dr["firstprice"],0),
                    Firsttime = DbChange.ToInt(dr["firsttime"],0),
                    Parkstatus = DbChange.ToInt(dr["parkstatus"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ParkviewDb</returns>
        public static List<ParkviewDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParkviewDb>(); 
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
