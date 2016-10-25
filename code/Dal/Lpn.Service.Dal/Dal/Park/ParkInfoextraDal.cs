using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Park;

/*
* 由自动生成工具完成
* 描述:[park_infoextra]非e泊停车场信息 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Park
{
    /// <summary>
    /// [park_infoextra]非e泊停车场信息 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ParkInfoextraDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parkinfoextra;";
        //新增插入语句
        protected const string SqlInsert = "insert into parkinfoextra(`parkname`,`imgurl`,`parkcode`,`parkaddr`,`lng`,`lat`,`lotcount`,`idlelotcount`,`parktype`,`freeexittime`,`parkfeesummary`,`markdesc`) values(?parkname,?imgurl,?parkcode,?parkaddr,?lng,?lat,?lotcount,?idlelotcount,?parktype,?freeexittime,?parkfeesummary,?markdesc);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from parkinfoextra where `id`=?id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update parkinfoextra set `parkname`=?parkname,`imgurl`=?imgurl,`parkcode`=?parkcode,`parkaddr`=?parkaddr,`lng`=?lng,`lat`=?lat,`lotcount`=?lotcount,`idlelotcount`=?idlelotcount,`parktype`=?parktype,`freeexittime`=?freeexittime,`parkfeesummary`=?parkfeesummary,`markdesc`=?markdesc where `id`=?id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from parkinfoextra  where `id`=?id;";
        #endregion

        #region 参数
        protected const string Paramid = "?id";
        protected const string Paramparkname = "?parkname";
        protected const string Paramimgurl = "?imgurl";
        protected const string Paramparkcode = "?parkcode";
        protected const string Paramparkaddr = "?parkaddr";
        protected const string Paramlng = "?lng";
        protected const string Paramlat = "?lat";
        protected const string Paramlotcount = "?lotcount";
        protected const string Paramidlelotcount = "?idlelotcount";
        protected const string Paramparktype = "?parktype";
        protected const string Paramfreeexittime = "?freeexittime";
        protected const string Paramparkfeesummary = "?parkfeesummary";
        protected const string Parammarkdesc = "?markdesc";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParkInfoextraDb</returns>
        public static List<ParkInfoextraDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parkinfoextra">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParkInfoextraDb parkinfoextra)
        {
            var param= GetInsertParams(parkinfoextra);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">标识</param> 
        /// <returns>ParkInfoextraDb</returns>
        public static ParkInfoextraDb  GetByPriKey(int id)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramid,id)
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
        /// <param name="parkinfoextra">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ParkInfoextraDb parkinfoextra)
        {
            var param= GetUpdateParams(parkinfoextra);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">标识</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(int id)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramid,id)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(ParkInfoextraDb parkinfoextra)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramid,parkinfoextra.Id),
                    new MySqlParameter(Paramparkname,parkinfoextra.Parkname),
                    new MySqlParameter(Paramimgurl,parkinfoextra.Imgurl),
                    new MySqlParameter(Paramparkcode,parkinfoextra.Parkcode),
                    new MySqlParameter(Paramparkaddr,parkinfoextra.Parkaddr),
                    new MySqlParameter(Paramlng,parkinfoextra.Lng),
                    new MySqlParameter(Paramlat,parkinfoextra.Lat),
                    new MySqlParameter(Paramlotcount,parkinfoextra.Lotcount),
                    new MySqlParameter(Paramidlelotcount,parkinfoextra.Idlelotcount),
                    new MySqlParameter(Paramparktype,parkinfoextra.Parktype),
                    new MySqlParameter(Paramfreeexittime,parkinfoextra.Freeexittime),
                    new MySqlParameter(Paramparkfeesummary,parkinfoextra.Parkfeesummary),
                    new MySqlParameter(Parammarkdesc,parkinfoextra.Markdesc)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParkInfoextraDb parkinfoextra)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramparkname,parkinfoextra.Parkname),
                    new MySqlParameter(Paramimgurl,parkinfoextra.Imgurl),
                    new MySqlParameter(Paramparkcode,parkinfoextra.Parkcode),
                    new MySqlParameter(Paramparkaddr,parkinfoextra.Parkaddr),
                    new MySqlParameter(Paramlng,parkinfoextra.Lng),
                    new MySqlParameter(Paramlat,parkinfoextra.Lat),
                    new MySqlParameter(Paramlotcount,parkinfoextra.Lotcount),
                    new MySqlParameter(Paramidlelotcount,parkinfoextra.Idlelotcount),
                    new MySqlParameter(Paramparktype,parkinfoextra.Parktype),
                    new MySqlParameter(Paramfreeexittime,parkinfoextra.Freeexittime),
                    new MySqlParameter(Paramparkfeesummary,parkinfoextra.Parkfeesummary),
                    new MySqlParameter(Parammarkdesc,parkinfoextra.Markdesc)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParkInfoextraDb</returns>
        public static ParkInfoextraDb  ConvertToObject(DataRow dr)
        {
            var data = new ParkInfoextraDb
                {
                    Id = DbChange.ToInt(dr["id"],0),
                    Parkname = DbChange.ToString(dr["parkname"]),
                    Imgurl = DbChange.ToString(dr["imgurl"]),
                    Parkcode = DbChange.ToString(dr["parkcode"]),
                    Parkaddr = DbChange.ToString(dr["parkaddr"]),
                    Lng = DbChange.ToDouble(dr["lng"],0D),
                    Lat = DbChange.ToDouble(dr["lat"],0D),
                    Lotcount = DbChange.ToInt(dr["lotcount"],0),
                    Idlelotcount = DbChange.ToInt(dr["idlelotcount"],0),
                    Parktype = DbChange.ToString(dr["parktype"]),
                    Freeexittime = DbChange.ToInt(dr["freeexittime"],0),
                    Parkfeesummary = DbChange.ToString(dr["parkfeesummary"]),
                    Markdesc = DbChange.ToString(dr["markdesc"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ParkInfoextraDb</returns>
        public static List<ParkInfoextraDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParkInfoextraDb>(); 
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
