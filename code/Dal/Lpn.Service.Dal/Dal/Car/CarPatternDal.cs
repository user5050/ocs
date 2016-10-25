using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Car;

/*
* 由自动生成工具完成
* 描述:[car_pattern]车辆类型字典表 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Car
{
    /// <summary>
    /// [car_pattern]车辆类型字典表 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class CarPatternDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from carpattern;";
        //新增插入语句
        protected const string SqlInsert = "insert into carpattern(`Type`,`Name`) values(?Type,?Name);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from carpattern where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update carpattern set `Type`=?Type,`Name`=?Name where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from carpattern  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamType = "?Type";
        protected const string ParamName = "?Name";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of CarPatternDb</returns>
        public static List<CarPatternDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="carpattern">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(CarPatternDb carpattern)
        {
            var param= GetInsertParams(carpattern);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">车辆类型字典编号</param> 
        /// <returns>CarPatternDb</returns>
        public static CarPatternDb  GetByPriKey(int id)
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
        /// <param name="carpattern">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(CarPatternDb carpattern)
        {
            var param= GetUpdateParams(carpattern);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">车辆类型字典编号</param> 
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
        public static MySqlParameter[]  GetUpdateParams(CarPatternDb carpattern)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,carpattern.ID),
                    new MySqlParameter(ParamType,carpattern.Type),
                    new MySqlParameter(ParamName,carpattern.Name)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(CarPatternDb carpattern)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamType,carpattern.Type),
                    new MySqlParameter(ParamName,carpattern.Name)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>CarPatternDb</returns>
        public static CarPatternDb  ConvertToObject(DataRow dr)
        {
            var data = new CarPatternDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    Type = DbChange.ToString(dr["Type"]),
                    Name = DbChange.ToString(dr["Name"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of CarPatternDb</returns>
        public static List<CarPatternDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<CarPatternDb>(); 
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
