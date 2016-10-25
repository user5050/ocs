using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Car;

/*
* 由自动生成工具完成
* 描述:[car_ment]车牌分享列表 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Car
{
    /// <summary>
    /// [car_ment]车牌分享列表 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class CarMentDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from carment;";
        //新增插入语句
        protected const string SqlInsert = "insert into carment(`Carno`,`UserID`,`IsRegdit`,`CarType`,`CarBrand`,`CarModel`,`OwnerID`) values(?Carno,?UserID,?IsRegdit,?CarType,?CarBrand,?CarModel,?OwnerID);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from carment where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update carment set `Carno`=?Carno,`UserID`=?UserID,`IsRegdit`=?IsRegdit,`CarType`=?CarType,`CarBrand`=?CarBrand,`CarModel`=?CarModel,`OwnerID`=?OwnerID where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from carment  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamCarno = "?Carno";
        protected const string ParamUserID = "?UserID";
        protected const string ParamIsRegdit = "?IsRegdit";
        protected const string ParamCarType = "?CarType";
        protected const string ParamCarBrand = "?CarBrand";
        protected const string ParamCarModel = "?CarModel";
        protected const string ParamOwnerID = "?OwnerID";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of CarMentDb</returns>
        public static List<CarMentDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="carment">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(CarMentDb carment)
        {
            var param= GetInsertParams(carment);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">车牌分享编号</param> 
        /// <returns>CarMentDb</returns>
        public static CarMentDb  GetByPriKey(int id)
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
        /// <param name="carment">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(CarMentDb carment)
        {
            var param= GetUpdateParams(carment);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">车牌分享编号</param> 
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
        public static MySqlParameter[]  GetUpdateParams(CarMentDb carment)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,carment.ID),
                    new MySqlParameter(ParamCarno,carment.Carno),
                    new MySqlParameter(ParamUserID,carment.UserID),
                    new MySqlParameter(ParamIsRegdit,carment.IsRegdit),
                    new MySqlParameter(ParamCarType,carment.CarType),
                    new MySqlParameter(ParamCarBrand,carment.CarBrand),
                    new MySqlParameter(ParamCarModel,carment.CarModel),
                    new MySqlParameter(ParamOwnerID,carment.OwnerID)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(CarMentDb carment)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCarno,carment.Carno),
                    new MySqlParameter(ParamUserID,carment.UserID),
                    new MySqlParameter(ParamIsRegdit,carment.IsRegdit),
                    new MySqlParameter(ParamCarType,carment.CarType),
                    new MySqlParameter(ParamCarBrand,carment.CarBrand),
                    new MySqlParameter(ParamCarModel,carment.CarModel),
                    new MySqlParameter(ParamOwnerID,carment.OwnerID)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>CarMentDb</returns>
        public static CarMentDb  ConvertToObject(DataRow dr)
        {
            var data = new CarMentDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    Carno = DbChange.ToString(dr["Carno"]),
                    UserID = DbChange.ToInt(dr["UserID"],0),
                    IsRegdit = DbChange.ToInt(dr["IsRegdit"],-1),
                    CarType = DbChange.ToInt(dr["CarType"],0),
                    CarBrand = DbChange.ToString(dr["CarBrand"]),
                    CarModel = DbChange.ToString(dr["CarModel"]),
                    OwnerID = DbChange.ToInt(dr["OwnerID"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of CarMentDb</returns>
        public static List<CarMentDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<CarMentDb>(); 
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
