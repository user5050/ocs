using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Model.Db.Product;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Dal.Dal.Product
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ProductDetailDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from product_detail;";
        //新增插入语句
        protected const string SqlInsert = "insert into product_detail(`PId`,`Detail`,`RowTime`) values(?PId,?Detail,?RowTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from product_detail where `PId`=?PId;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update product_detail set `Detail`=?Detail,`RowTime`=?RowTime where `PId`=?PId;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from product_detail  where `PId`=?PId;";
        #endregion

        #region 参数
        protected const string ParamPId = "?PId";
        protected const string ParamDetail = "?Detail";
        protected const string ParamRowTime = "?RowTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ProductDetailDb</returns>
        public static List<ProductDetailDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="productdetail">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ProductDetailDb productdetail)
        {
            var param= GetInsertParams(productdetail);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="pId">商品id</param> 
        /// <returns>ProductDetailDb</returns>
        public static ProductDetailDb  GetByPriKey(string pId)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamPId,pId)
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
        /// <param name="productdetail">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ProductDetailDb productdetail)
        {
            var param= GetUpdateParams(productdetail);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="pId">商品id</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string pId)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamPId,pId)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(ProductDetailDb productdetail)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamPId,productdetail.PId),
                    new MySqlParameter(ParamDetail,productdetail.Detail),
                    new MySqlParameter(ParamRowTime,productdetail.RowTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ProductDetailDb productdetail)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamPId,productdetail.PId),
                    new MySqlParameter(ParamDetail,productdetail.Detail),
                    new MySqlParameter(ParamRowTime,productdetail.RowTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ProductDetailDb</returns>
        public static ProductDetailDb  ConvertToObject(DataRow dr)
        {
            var data = new ProductDetailDb
                {
                    PId = DbChange.ToString(dr["PId"]),
                    Detail = DbChange.ToString(dr["Detail"]),
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
        /// <returns>List of ProductDetailDb</returns>
        public static List<ProductDetailDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ProductDetailDb>(); 
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
