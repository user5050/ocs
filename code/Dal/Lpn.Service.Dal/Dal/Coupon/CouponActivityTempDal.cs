using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Coupon;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Coupon
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    [Serializable]
    public partial class CouponActivityTempDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from coupon_activity_temp;";
        //新增插入语句
        protected const string SqlInsert = "insert into coupon_activity_temp(`Id`,`Title`,`BackGroundImgUrl`,`RefActivityId`,`Remark`,`RowTime`,`Operator`) values(?Id,?Title,?BackGroundImgUrl,?RefActivityId,?Remark,?RowTime,?Operator);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from coupon_activity_temp where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update coupon_activity_temp set `Title`=?Title,`BackGroundImgUrl`=?BackGroundImgUrl,`RefActivityId`=?RefActivityId,`Remark`=?Remark,`RowTime`=?RowTime,`Operator`=?Operator where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from coupon_activity_temp  where `Id`=?Id;";
        #endregion

        #region 参数
        protected const string ParamId = "?Id";
        protected const string ParamTitle = "?Title";
        protected const string ParamBackGroundImgUrl = "?BackGroundImgUrl";
        protected const string ParamRefActivityId = "?RefActivityId";
        protected const string ParamRemark = "?Remark";
        protected const string ParamRowTime = "?RowTime";
        protected const string ParamOperator = "?Operator";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of CouponActivityTempDb</returns>
        public static List<CouponActivityTempDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="couponactivitytemp">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(CouponActivityTempDb couponactivitytemp)
        {
            var param= GetInsertParams(couponactivitytemp);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">模板id</param> 
        /// <returns>CouponActivityTempDb</returns>
        public static CouponActivityTempDb  GetByPriKey(string id)
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
        /// <param name="couponactivitytemp">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(CouponActivityTempDb couponactivitytemp)
        {
            var param= GetUpdateParams(couponactivitytemp);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">模板id</param> 
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
        public static MySqlParameter[]  GetUpdateParams(CouponActivityTempDb couponactivitytemp)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,couponactivitytemp.Id),
                    new MySqlParameter(ParamTitle,couponactivitytemp.Title),
                    new MySqlParameter(ParamBackGroundImgUrl,couponactivitytemp.BackGroundImgUrl),
                    new MySqlParameter(ParamRefActivityId,couponactivitytemp.RefActivityId),
                    new MySqlParameter(ParamRemark,couponactivitytemp.Remark),
                    new MySqlParameter(ParamRowTime,couponactivitytemp.RowTime),
                    new MySqlParameter(ParamOperator,couponactivitytemp.Operator)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(CouponActivityTempDb couponactivitytemp)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,couponactivitytemp.Id),
                    new MySqlParameter(ParamTitle,couponactivitytemp.Title),
                    new MySqlParameter(ParamBackGroundImgUrl,couponactivitytemp.BackGroundImgUrl),
                    new MySqlParameter(ParamRefActivityId,couponactivitytemp.RefActivityId),
                    new MySqlParameter(ParamRemark,couponactivitytemp.Remark),
                    new MySqlParameter(ParamRowTime,couponactivitytemp.RowTime),
                    new MySqlParameter(ParamOperator,couponactivitytemp.Operator)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>CouponActivityTempDb</returns>
        public static CouponActivityTempDb  ConvertToObject(DataRow dr)
        {
            var data = new CouponActivityTempDb
                {
                    Id = DbChange.ToString(dr["Id"]),
                    Title = DbChange.ToString(dr["Title"]),
                    BackGroundImgUrl = DbChange.ToString(dr["BackGroundImgUrl"]),
                    RefActivityId = DbChange.ToString(dr["RefActivityId"]),
                    Remark = DbChange.ToString(dr["Remark"]),
                    RowTime = DbChange.ToDateTime(dr["RowTime"],DateTime.MinValue),
                    Operator = DbChange.ToString(dr["Operator"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of CouponActivityTempDb</returns>
        public static List<CouponActivityTempDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<CouponActivityTempDb>(); 
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
