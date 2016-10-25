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
    public partial class ProductCategoryDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from product_category;";
        //新增插入语句
        protected const string SqlInsert = "insert into product_category(`Id`,`Name`,`IsShow`) values(?Id,?Name,?IsShow);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from product_category where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update product_category set `Name`=?Name,`IsShow`=?IsShow where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from product_category  where `Id`=?Id;";
        #endregion

        #region 参数
        protected const string ParamId = "?Id";
        protected const string ParamName = "?Name";
        protected const string ParamIsShow = "?IsShow";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ProductCategoryDb</returns>
        public static List<ProductCategoryDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="productcategory">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ProductCategoryDb productcategory)
        {
            var param= GetInsertParams(productcategory);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>ProductCategoryDb</returns>
        public static ProductCategoryDb  GetByPriKey(string id)
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
        /// <param name="productcategory">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ProductCategoryDb productcategory)
        {
            var param= GetUpdateParams(productcategory);
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
        public static MySqlParameter[]  GetUpdateParams(ProductCategoryDb productcategory)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,productcategory.Id),
                    new MySqlParameter(ParamName,productcategory.Name),
                    new MySqlParameter(ParamIsShow,productcategory.IsShow)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ProductCategoryDb productcategory)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,productcategory.Id),
                    new MySqlParameter(ParamName,productcategory.Name),
                    new MySqlParameter(ParamIsShow,productcategory.IsShow)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ProductCategoryDb</returns>
        public static ProductCategoryDb  ConvertToObject(DataRow dr)
        {
            var data = new ProductCategoryDb
                {
                    Id = DbChange.ToString(dr["Id"]),
                    Name = DbChange.ToString(dr["Name"]),
                    IsShow = DbChange.ToInt(dr["IsShow"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ProductCategoryDb</returns>
        public static List<ProductCategoryDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ProductCategoryDb>(); 
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
