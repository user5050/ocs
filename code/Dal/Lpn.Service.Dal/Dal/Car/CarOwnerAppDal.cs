using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Car;

/*
* 由自动生成工具完成
* 描述:[car_owner_app]车辆找回信息表 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Car
{
    /// <summary>
    /// [car_owner_app]车辆找回信息表 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class CarOwnerAppDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from carownerapp;";
        //新增插入语句
        protected const string SqlInsert = "insert into carownerapp(`Carno`,`UserID`,`State`,`Img`) values(?Carno,?UserID,?State,?Img);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from carownerapp where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update carownerapp set `Carno`=?Carno,`UserID`=?UserID,`State`=?State,`Img`=?Img where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from carownerapp  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamCarno = "?Carno";
        protected const string ParamUserID = "?UserID";
        protected const string ParamState = "?State";
        protected const string ParamImg = "?Img";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of CarOwnerAppDb</returns>
        public static List<CarOwnerAppDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="carownerapp">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(CarOwnerAppDb carownerapp)
        {
            var param= GetInsertParams(carownerapp);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">车辆找回信息编号</param> 
        /// <returns>CarOwnerAppDb</returns>
        public static CarOwnerAppDb  GetByPriKey(int id)
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
        /// <param name="carownerapp">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(CarOwnerAppDb carownerapp)
        {
            var param= GetUpdateParams(carownerapp);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">车辆找回信息编号</param> 
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
        public static MySqlParameter[]  GetUpdateParams(CarOwnerAppDb carownerapp)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,carownerapp.ID),
                    new MySqlParameter(ParamCarno,carownerapp.Carno),
                    new MySqlParameter(ParamUserID,carownerapp.UserID),
                    new MySqlParameter(ParamState,carownerapp.State),
                    new MySqlParameter(ParamImg,carownerapp.Img)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(CarOwnerAppDb carownerapp)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCarno,carownerapp.Carno),
                    new MySqlParameter(ParamUserID,carownerapp.UserID),
                    new MySqlParameter(ParamState,carownerapp.State),
                    new MySqlParameter(ParamImg,carownerapp.Img)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>CarOwnerAppDb</returns>
        public static CarOwnerAppDb  ConvertToObject(DataRow dr)
        {
            var data = new CarOwnerAppDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    Carno = DbChange.ToString(dr["Carno"]),
                    UserID = DbChange.ToInt(dr["UserID"],0),
                    State = DbChange.ToInt(dr["State"],0),
                    Img = DbChange.ToString(dr["Img"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of CarOwnerAppDb</returns>
        public static List<CarOwnerAppDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<CarOwnerAppDb>(); 
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
