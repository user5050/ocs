using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Model.Db.Partnerpay;

/*
* 由自动生成工具完成
* 描述:停车场合作公司配置信息 Dal帮助类
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Dal.Dal.Partnerpay
{
    /// <summary>
    /// 停车场合作公司配置信息 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class PartnerpayInfoDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from partnerpay_info;";
        //新增插入语句
        protected const string SqlInsert = "insert into partnerpay_info(`Id`,`Name`,`Remark`,`RowTime`) values(?Id,?Name,?Remark,?RowTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from partnerpay_info where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update partnerpay_info set `Name`=?Name,`Remark`=?Remark,`RowTime`=?RowTime where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from partnerpay_info  where `Id`=?Id;";
        #endregion

        #region 参数
        protected const string ParamId = "?Id";
        protected const string ParamName = "?Name";
        protected const string ParamRemark = "?Remark";
        protected const string ParamRowTime = "?RowTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of PartnerpayInfoDb</returns>
        public static List<PartnerpayInfoDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="partnerpayinfo">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(PartnerpayInfoDb partnerpayinfo)
        {
            var param= GetInsertParams(partnerpayinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">编号</param> 
        /// <returns>PartnerpayInfoDb</returns>
        public static PartnerpayInfoDb  GetByPriKey(string id)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,id)
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
        /// <param name="partnerpayinfo">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(PartnerpayInfoDb partnerpayinfo)
        {
            var param= GetUpdateParams(partnerpayinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">编号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string id)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,id)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(PartnerpayInfoDb partnerpayinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,partnerpayinfo.Id),
                    new MySqlParameter(ParamName,partnerpayinfo.Name),
                    new MySqlParameter(ParamRemark,partnerpayinfo.Remark),
                    new MySqlParameter(ParamRowTime,partnerpayinfo.RowTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(PartnerpayInfoDb partnerpayinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,partnerpayinfo.Id),
                    new MySqlParameter(ParamName,partnerpayinfo.Name),
                    new MySqlParameter(ParamRemark,partnerpayinfo.Remark),
                    new MySqlParameter(ParamRowTime,partnerpayinfo.RowTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>PartnerpayInfoDb</returns>
        public static PartnerpayInfoDb  ConvertToObject(DataRow dr)
        {
            var data = new PartnerpayInfoDb
                {
                    Id = DbChange.ToString(dr["Id"]),
                    Name = DbChange.ToString(dr["Name"]),
                    Remark = DbChange.ToString(dr["Remark"]),
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
        /// <returns>List of PartnerpayInfoDb</returns>
        public static List<PartnerpayInfoDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<PartnerpayInfoDb>(); 
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
