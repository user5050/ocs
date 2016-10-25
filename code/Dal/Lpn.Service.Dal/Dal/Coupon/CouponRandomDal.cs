﻿using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Coupon;

/*
* 由自动生成工具完成
* 描述:[coupon_random]评论池 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Coupon
{
    /// <summary>
    /// [coupon_random]评论池 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class CouponRandomDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from couponrandom;";
        //新增插入语句
        protected const string SqlInsert = "insert into couponrandom(`TypeName`,`RandomStr`) values(?TypeName,?RandomStr);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from couponrandom where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update couponrandom set `TypeName`=?TypeName,`RandomStr`=?RandomStr where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from couponrandom  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamTypeName = "?TypeName";
        protected const string ParamRandomStr = "?RandomStr";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of CouponRandomDb</returns>
        public static List<CouponRandomDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="couponrandom">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(CouponRandomDb couponrandom)
        {
            var param= GetInsertParams(couponrandom);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">评论池编号</param> 
        /// <returns>CouponRandomDb</returns>
        public static CouponRandomDb  GetByPriKey(int id)
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
        /// <param name="couponrandom">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(CouponRandomDb couponrandom)
        {
            var param= GetUpdateParams(couponrandom);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">评论池编号</param> 
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
        public static MySqlParameter[]  GetUpdateParams(CouponRandomDb couponrandom)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,couponrandom.ID),
                    new MySqlParameter(ParamTypeName,couponrandom.TypeName),
                    new MySqlParameter(ParamRandomStr,couponrandom.RandomStr)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(CouponRandomDb couponrandom)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamTypeName,couponrandom.TypeName),
                    new MySqlParameter(ParamRandomStr,couponrandom.RandomStr)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>CouponRandomDb</returns>
        public static CouponRandomDb  ConvertToObject(DataRow dr)
        {
            var data = new CouponRandomDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    TypeName = DbChange.ToString(dr["TypeName"]),
                    RandomStr = DbChange.ToString(dr["RandomStr"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of CouponRandomDb</returns>
        public static List<CouponRandomDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<CouponRandomDb>(); 
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
