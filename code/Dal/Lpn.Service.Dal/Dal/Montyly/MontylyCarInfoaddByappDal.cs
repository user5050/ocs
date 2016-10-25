using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Montyly;

/*
* 由自动生成工具完成
* 描述:[montyly_car_infoadd_byapp]APP添加的月租车牌 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Montyly
{
    /// <summary>
    /// [montyly_car_infoadd_byapp]APP添加的月租车牌 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class MontylyCarInfoaddByappDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from montylycarinfoaddbyapp;";
        //新增插入语句
        protected const string SqlInsert = "insert into montylycarinfoaddbyapp(`ParkCode`,`CarNo`,`InternalUserID`,`IndexInfo`) values(?ParkCode,?CarNo,?InternalUserID,?IndexInfo);";
        #endregion

        #region 参数
        protected const string ParamParkCode = "?ParkCode";
        protected const string ParamCarNo = "?CarNo";
        protected const string ParamInternalUserID = "?InternalUserID";
        protected const string ParamIndexInfo = "?IndexInfo";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of MontylyCarInfoaddByappDb</returns>
        public static List<MontylyCarInfoaddByappDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="montylycarinfoaddbyapp">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(MontylyCarInfoaddByappDb montylycarinfoaddbyapp)
        {
            var param= GetInsertParams(montylycarinfoaddbyapp);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(MontylyCarInfoaddByappDb montylycarinfoaddbyapp)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkCode,montylycarinfoaddbyapp.ParkCode),
                    new MySqlParameter(ParamCarNo,montylycarinfoaddbyapp.CarNo),
                    new MySqlParameter(ParamInternalUserID,montylycarinfoaddbyapp.InternalUserID),
                    new MySqlParameter(ParamIndexInfo,montylycarinfoaddbyapp.IndexInfo)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>MontylyCarInfoaddByappDb</returns>
        public static MontylyCarInfoaddByappDb  ConvertToObject(DataRow dr)
        {
            var data = new MontylyCarInfoaddByappDb
                {
                    ParkCode = DbChange.ToString(dr["ParkCode"]),
                    CarNo = DbChange.ToString(dr["CarNo"]),
                    InternalUserID = DbChange.ToInt(dr["InternalUserID"],0),
                    IndexInfo = DbChange.ToString(dr["IndexInfo"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of MontylyCarInfoaddByappDb</returns>
        public static List<MontylyCarInfoaddByappDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<MontylyCarInfoaddByappDb>(); 
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
