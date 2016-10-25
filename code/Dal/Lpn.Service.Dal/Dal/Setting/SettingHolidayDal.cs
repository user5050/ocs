using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Setting;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Setting
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    [Serializable]
    public partial class SettingHolidayDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from setting_holiday;";
        //新增插入语句
        protected const string SqlInsert = "insert into setting_holiday(`year`,`month`,`holiday`) values(?year,?month,?holiday);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from setting_holiday where `id`=?id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update setting_holiday set `year`=?year,`month`=?month,`holiday`=?holiday where `id`=?id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from setting_holiday  where `id`=?id;";
        #endregion

        #region 参数
        protected const string Paramid = "?id";
        protected const string Paramyear = "?year";
        protected const string Parammonth = "?month";
        protected const string Paramholiday = "?holiday";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of SettingHolidayDb</returns>
        public static List<SettingHolidayDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="settingholiday">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(SettingHolidayDb settingholiday)
        {
            var param= GetInsertParams(settingholiday);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>SettingHolidayDb</returns>
        public static SettingHolidayDb  GetByPriKey(int id)
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
        /// <param name="settingholiday">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(SettingHolidayDb settingholiday)
        {
            var param= GetUpdateParams(settingholiday);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id"></param> 
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
        public static MySqlParameter[]  GetUpdateParams(SettingHolidayDb settingholiday)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramid,settingholiday.Id),
                    new MySqlParameter(Paramyear,settingholiday.Year),
                    new MySqlParameter(Parammonth,settingholiday.Month),
                    new MySqlParameter(Paramholiday,settingholiday.Holiday)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(SettingHolidayDb settingholiday)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramyear,settingholiday.Year),
                    new MySqlParameter(Parammonth,settingholiday.Month),
                    new MySqlParameter(Paramholiday,settingholiday.Holiday)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>SettingHolidayDb</returns>
        public static SettingHolidayDb  ConvertToObject(DataRow dr)
        {
            var data = new SettingHolidayDb
                {
                    Id = DbChange.ToInt(dr["id"],0),
                    Year = DbChange.ToInt(dr["year"],0),
                    Month = DbChange.ToInt(dr["month"],0),
                    Holiday = DbChange.ToString(dr["holiday"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of SettingHolidayDb</returns>
        public static List<SettingHolidayDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<SettingHolidayDb>(); 
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
