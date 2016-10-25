using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Model.Db.Home;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Dal.Dal.Home
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    [Serializable]
    public partial class HomeBannerDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from home_banner;";
        //新增插入语句
        protected const string SqlInsert = "insert into home_banner(`Id`,`Img`,`StartTime`,`ExpriedTime`,`Url`,`Order`,`Type`) values(?Id,?Img,?StartTime,?ExpriedTime,?Url,?Order,?Type);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from home_banner where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update home_banner set `Img`=?Img,`StartTime`=?StartTime,`ExpriedTime`=?ExpriedTime,`Url`=?Url,`Order`=?Order,`Type`=?Type where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from home_banner  where `Id`=?Id;";
        #endregion

        #region 参数
        protected const string ParamId = "?Id";
        protected const string ParamImg = "?Img";
        protected const string ParamStartTime = "?StartTime";
        protected const string ParamExpriedTime = "?ExpriedTime";
        protected const string ParamUrl = "?Url";
        protected const string ParamOrder = "?Order";
        protected const string ParamType = "?Type";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of HomeBannerDb</returns>
        public static List<HomeBannerDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="homebanner">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(HomeBannerDb homebanner)
        {
            var param= GetInsertParams(homebanner);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>HomeBannerDb</returns>
        public static HomeBannerDb  GetByPriKey(int id)
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
        /// <param name="homebanner">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(HomeBannerDb homebanner)
        {
            var param= GetUpdateParams(homebanner);
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
                    new MySqlParameter(ParamId,id)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(HomeBannerDb homebanner)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,homebanner.Id),
                    new MySqlParameter(ParamImg,homebanner.Img),
                    new MySqlParameter(ParamStartTime,homebanner.StartTime),
                    new MySqlParameter(ParamExpriedTime,homebanner.ExpriedTime),
                    new MySqlParameter(ParamUrl,homebanner.Url),
                    new MySqlParameter(ParamOrder,homebanner.Order),
                    new MySqlParameter(ParamType,homebanner.Type)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(HomeBannerDb homebanner)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,homebanner.Id),
                    new MySqlParameter(ParamImg,homebanner.Img),
                    new MySqlParameter(ParamStartTime,homebanner.StartTime),
                    new MySqlParameter(ParamExpriedTime,homebanner.ExpriedTime),
                    new MySqlParameter(ParamUrl,homebanner.Url),
                    new MySqlParameter(ParamOrder,homebanner.Order),
                    new MySqlParameter(ParamType,homebanner.Type)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>HomeBannerDb</returns>
        public static HomeBannerDb  ConvertToObject(DataRow dr)
        {
            var data = new HomeBannerDb
                {
                    Id = DbChange.ToInt(dr["Id"],0),
                    Img = DbChange.ToString(dr["Img"]),
                    StartTime = DbChange.ToDateTime(dr["StartTime"],DateTime.MinValue),
                    ExpriedTime = DbChange.ToDateTime(dr["ExpriedTime"],DateTime.MinValue),
                    Url = DbChange.ToString(dr["Url"]),
                    Order = DbChange.ToInt(dr["Order"],0),
                    Type = DbChange.ToInt(dr["Type"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of HomeBannerDb</returns>
        public static List<HomeBannerDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<HomeBannerDb>(); 
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
