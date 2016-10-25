using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Special;

/*
* 由自动生成工具完成
* 描述:[special_car_no]预置车牌 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Special
{
    /// <summary>
    /// [special_car_no]预置车牌 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class SpecialCarNoDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from specialcarno;";
        //新增插入语句
        protected const string SqlInsert = "insert into specialcarno(`CarNo`,`Time`) values(?CarNo,?Time);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from specialcarno where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update specialcarno set `CarNo`=?CarNo,`Time`=?Time where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from specialcarno  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamCarNo = "?CarNo";
        protected const string ParamTime = "?Time";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of SpecialCarNoDb</returns>
        public static List<SpecialCarNoDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="specialcarno">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(SpecialCarNoDb specialcarno)
        {
            var param= GetInsertParams(specialcarno);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">预置车牌编号</param> 
        /// <returns>SpecialCarNoDb</returns>
        public static SpecialCarNoDb  GetByPriKey(int id)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,id)
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
        /// <param name="specialcarno">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(SpecialCarNoDb specialcarno)
        {
            var param= GetUpdateParams(specialcarno);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">预置车牌编号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(int id)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,id)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(SpecialCarNoDb specialcarno)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,specialcarno.ID),
                    new MySqlParameter(ParamCarNo,specialcarno.CarNo),
                    new MySqlParameter(ParamTime,specialcarno.Time)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(SpecialCarNoDb specialcarno)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCarNo,specialcarno.CarNo),
                    new MySqlParameter(ParamTime,specialcarno.Time)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>SpecialCarNoDb</returns>
        public static SpecialCarNoDb  ConvertToObject(DataRow dr)
        {
            var data = new SpecialCarNoDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    CarNo = DbChange.ToString(dr["CarNo"]),
                    Time = DbChange.ToDateTime(dr["Time"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of SpecialCarNoDb</returns>
        public static List<SpecialCarNoDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<SpecialCarNoDb>(); 
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
