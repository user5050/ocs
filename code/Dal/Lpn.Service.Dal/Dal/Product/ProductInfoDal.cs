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
    public partial class ProductInfoDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from product_info;";
        //新增插入语句
        protected const string SqlInsert = "insert into product_info(`Id`,`PreGameNo`,`Name`,`Img`,`OrderMoney`,`Imgs`,`State`,`RowTime`,`CategoryId`,`Order`) values(?Id,?PreGameNo,?Name,?Img,?OrderMoney,?Imgs,?State,?RowTime,?CategoryId,?Order);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from product_info where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update product_info set `PreGameNo`=?PreGameNo,`Name`=?Name,`Img`=?Img,`OrderMoney`=?OrderMoney,`Imgs`=?Imgs,`State`=?State,`RowTime`=?RowTime,`CategoryId`=?CategoryId,`Order`=?Order where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from product_info  where `Id`=?Id;";
        #endregion

        #region 参数
        protected const string ParamId = "?Id";
        protected const string ParamPreGameNo = "?PreGameNo";
        protected const string ParamName = "?Name";
        protected const string ParamImg = "?Img";
        protected const string ParamOrderMoney = "?OrderMoney";
        protected const string ParamImgs = "?Imgs";
        protected const string ParamState = "?State";
        protected const string ParamRowTime = "?RowTime";
        protected const string ParamCategoryId = "?CategoryId";
        protected const string ParamOrder = "?Order";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ProductInfoDb</returns>
        public static List<ProductInfoDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="productinfo">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ProductInfoDb productinfo)
        {
            var param= GetInsertParams(productinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>ProductInfoDb</returns>
        public static ProductInfoDb  GetByPriKey(string id)
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
        /// <param name="productinfo">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ProductInfoDb productinfo)
        {
            var param= GetUpdateParams(productinfo);
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
        public static MySqlParameter[]  GetUpdateParams(ProductInfoDb productinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,productinfo.Id),
                    new MySqlParameter(ParamPreGameNo,productinfo.PreGameNo),
                    new MySqlParameter(ParamName,productinfo.Name),
                    new MySqlParameter(ParamImg,productinfo.Img),
                    new MySqlParameter(ParamOrderMoney,productinfo.OrderMoney),
                    new MySqlParameter(ParamImgs,productinfo.Imgs),
                    new MySqlParameter(ParamState,productinfo.State),
                    new MySqlParameter(ParamRowTime,productinfo.RowTime),
                    new MySqlParameter(ParamCategoryId,productinfo.CategoryId),
                    new MySqlParameter(ParamOrder,productinfo.Order)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ProductInfoDb productinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,productinfo.Id),
                    new MySqlParameter(ParamPreGameNo,productinfo.PreGameNo),
                    new MySqlParameter(ParamName,productinfo.Name),
                    new MySqlParameter(ParamImg,productinfo.Img),
                    new MySqlParameter(ParamOrderMoney,productinfo.OrderMoney),
                    new MySqlParameter(ParamImgs,productinfo.Imgs),
                    new MySqlParameter(ParamState,productinfo.State),
                    new MySqlParameter(ParamRowTime,productinfo.RowTime),
                    new MySqlParameter(ParamCategoryId,productinfo.CategoryId),
                    new MySqlParameter(ParamOrder,productinfo.Order)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ProductInfoDb</returns>
        public static ProductInfoDb  ConvertToObject(DataRow dr)
        {
            var data = new ProductInfoDb
                {
                    Id = DbChange.ToString(dr["Id"]),
                    PreGameNo = DbChange.ToString(dr["PreGameNo"]),
                    Name = DbChange.ToString(dr["Name"]),
                    Img = DbChange.ToString(dr["Img"]),
                    OrderMoney = DbChange.ToInt(dr["OrderMoney"],0),
                    Imgs = DbChange.ToString(dr["Imgs"]),
                    State = DbChange.ToInt(dr["State"],0),
                    RowTime = DbChange.ToDateTime(dr["RowTime"],DateTime.MinValue),
                    CategoryId = DbChange.ToString(dr["CategoryId"]),
                    Order = DbChange.ToInt(dr["Order"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ProductInfoDb</returns>
        public static List<ProductInfoDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ProductInfoDb>(); 
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
