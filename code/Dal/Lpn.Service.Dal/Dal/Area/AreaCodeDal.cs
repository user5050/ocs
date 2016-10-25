using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Area;

/*
* 由自动生成工具完成
* 描述:[area_code]区域编码 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Area
{
    /// <summary>
    /// [area_code]区域编码 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class AreaCodeDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from areacode;";
        //新增插入语句
        protected const string SqlInsert = "insert into areacode(`Code`,`Index`) values(?Code,?Index);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from areacode where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update areacode set `Code`=?Code,`Index`=?Index where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from areacode  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamCode = "?Code";
        protected const string ParamIndex = "?Index";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of AreaCodeDb</returns>
        public static List<AreaCodeDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="areacode">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(AreaCodeDb areacode)
        {
            var param= GetInsertParams(areacode);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">区域编码编号</param> 
        /// <returns>AreaCodeDb</returns>
        public static AreaCodeDb  GetByPriKey(int id)
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
        /// <param name="areacode">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(AreaCodeDb areacode)
        {
            var param= GetUpdateParams(areacode);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">区域编码编号</param> 
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
        public static MySqlParameter[]  GetUpdateParams(AreaCodeDb areacode)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,areacode.ID),
                    new MySqlParameter(ParamCode,areacode.Code),
                    new MySqlParameter(ParamIndex,areacode.Index)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(AreaCodeDb areacode)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCode,areacode.Code),
                    new MySqlParameter(ParamIndex,areacode.Index)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>AreaCodeDb</returns>
        public static AreaCodeDb  ConvertToObject(DataRow dr)
        {
            var data = new AreaCodeDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    Code = DbChange.ToString(dr["Code"]),
                    Index = DbChange.ToInt(dr["Index"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of AreaCodeDb</returns>
        public static List<AreaCodeDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<AreaCodeDb>(); 
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
