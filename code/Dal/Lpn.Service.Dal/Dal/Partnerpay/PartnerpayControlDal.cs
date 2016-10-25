using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Model.Db.Partnerpay;

/*
* 由自动生成工具完成
* 描述:停车场支付功能控制开关 Dal帮助类
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Dal.Dal.Partnerpay
{
    /// <summary>
    /// 停车场支付功能控制开关 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class PartnerpayControlDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from partnerpay_control;";
        //新增插入语句
        protected const string SqlInsert = "insert into partnerpay_control(`ParkCode`,`PartnerId`,`EnablePlatforms`,`RowTime`) values(?ParkCode,?PartnerId,?EnablePlatforms,?RowTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from partnerpay_control where `ParkCode`=?ParkCode;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update partnerpay_control set `PartnerId`=?PartnerId,`EnablePlatforms`=?EnablePlatforms,`RowTime`=?RowTime where `ParkCode`=?ParkCode;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from partnerpay_control  where `ParkCode`=?ParkCode;";
        #endregion

        #region 参数
        protected const string ParamParkCode = "?ParkCode";
        protected const string ParamPartnerId = "?PartnerId";
        protected const string ParamEnablePlatforms = "?EnablePlatforms";
        protected const string ParamRowTime = "?RowTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of PartnerpayControlDb</returns>
        public static List<PartnerpayControlDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="partnerpaycontrol">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(PartnerpayControlDb partnerpaycontrol)
        {
            var param= GetInsertParams(partnerpaycontrol);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="parkCode">停车场编号</param> 
        /// <returns>PartnerpayControlDb</returns>
        public static PartnerpayControlDb  GetByPriKey(string parkCode)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkCode,parkCode)
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
        /// <param name="partnerpaycontrol">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(PartnerpayControlDb partnerpaycontrol)
        {
            var param= GetUpdateParams(partnerpaycontrol);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="parkCode">停车场编号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string parkCode)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkCode,parkCode)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(PartnerpayControlDb partnerpaycontrol)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkCode,partnerpaycontrol.ParkCode),
                    new MySqlParameter(ParamPartnerId,partnerpaycontrol.PartnerId),
                    new MySqlParameter(ParamEnablePlatforms,partnerpaycontrol.EnablePlatforms),
                    new MySqlParameter(ParamRowTime,partnerpaycontrol.RowTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(PartnerpayControlDb partnerpaycontrol)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamParkCode,partnerpaycontrol.ParkCode),
                    new MySqlParameter(ParamPartnerId,partnerpaycontrol.PartnerId),
                    new MySqlParameter(ParamEnablePlatforms,partnerpaycontrol.EnablePlatforms),
                    new MySqlParameter(ParamRowTime,partnerpaycontrol.RowTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>PartnerpayControlDb</returns>
        public static PartnerpayControlDb  ConvertToObject(DataRow dr)
        {
            var data = new PartnerpayControlDb
                {
                    ParkCode = DbChange.ToString(dr["ParkCode"]),
                    PartnerId = DbChange.ToString(dr["PartnerId"]),
                    EnablePlatforms = DbChange.ToString(dr["EnablePlatforms"]),
                    RowTime = DbChange.ToDateTime(dr["RowTime"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of PartnerpayControlDb</returns>
        public static List<PartnerpayControlDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<PartnerpayControlDb>(); 
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
