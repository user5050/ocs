using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Park;

/*
* 由自动生成工具完成
* 描述:[park_feeinfo]e泊停车场费率信息 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Park
{
    /// <summary>
    /// [park_feeinfo]e泊停车场费率信息 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ParkFeeinfoDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parkfeeinfo;";
        //新增插入语句
        protected const string SqlInsert = "insert into parkfeeinfo(`parkcode`,`parktype`,`parkfeetime`,`parkfee`) values(?parkcode,?parktype,?parkfeetime,?parkfee);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from parkfeeinfo where `id`=?id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update parkfeeinfo set `parkcode`=?parkcode,`parktype`=?parktype,`parkfeetime`=?parkfeetime,`parkfee`=?parkfee where `id`=?id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from parkfeeinfo  where `id`=?id;";
        #endregion

        #region 参数
        protected const string Paramid = "?id";
        protected const string Paramparkcode = "?parkcode";
        protected const string Paramparktype = "?parktype";
        protected const string Paramparkfeetime = "?parkfeetime";
        protected const string Paramparkfee = "?parkfee";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParkFeeinfoDb</returns>
        public static List<ParkFeeinfoDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parkfeeinfo">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParkFeeinfoDb parkfeeinfo)
        {
            var param= GetInsertParams(parkfeeinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">标志</param> 
        /// <returns>ParkFeeinfoDb</returns>
        public static ParkFeeinfoDb  GetByPriKey(int id)
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
        /// <param name="parkfeeinfo">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ParkFeeinfoDb parkfeeinfo)
        {
            var param= GetUpdateParams(parkfeeinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">标志</param> 
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
        public static MySqlParameter[]  GetUpdateParams(ParkFeeinfoDb parkfeeinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramid,parkfeeinfo.Id),
                    new MySqlParameter(Paramparkcode,parkfeeinfo.Parkcode),
                    new MySqlParameter(Paramparktype,parkfeeinfo.Parktype),
                    new MySqlParameter(Paramparkfeetime,parkfeeinfo.Parkfeetime),
                    new MySqlParameter(Paramparkfee,parkfeeinfo.Parkfee)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParkFeeinfoDb parkfeeinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramparkcode,parkfeeinfo.Parkcode),
                    new MySqlParameter(Paramparktype,parkfeeinfo.Parktype),
                    new MySqlParameter(Paramparkfeetime,parkfeeinfo.Parkfeetime),
                    new MySqlParameter(Paramparkfee,parkfeeinfo.Parkfee)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParkFeeinfoDb</returns>
        public static ParkFeeinfoDb  ConvertToObject(DataRow dr)
        {
            var data = new ParkFeeinfoDb
                {
                    Id = DbChange.ToInt(dr["id"],0),
                    Parkcode = DbChange.ToString(dr["parkcode"]),
                    Parktype = DbChange.ToString(dr["parktype"]),
                    Parkfeetime = DbChange.ToString(dr["parkfeetime"]),
                    Parkfee = DbChange.ToString(dr["parkfee"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ParkFeeinfoDb</returns>
        public static List<ParkFeeinfoDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParkFeeinfoDb>(); 
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
