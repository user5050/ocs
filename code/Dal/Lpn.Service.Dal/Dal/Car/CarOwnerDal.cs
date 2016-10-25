using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Car;

/*
* 由自动生成工具完成
* 描述:[car_owner]车辆注册表 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Car
{
    /// <summary>
    /// [car_owner]车辆注册表 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class CarOwnerDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from carowner;";
        //新增插入语句
        protected const string SqlInsert = "insert into carowner(`Carno`,`UserID`,`CarBrand`,`Color`,`State`,`Img`,`RowTime`,`ClientType`) values(?Carno,?UserID,?CarBrand,?Color,?State,?Img,?RowTime,?ClientType);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from carowner where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update carowner set `Carno`=?Carno,`UserID`=?UserID,`CarBrand`=?CarBrand,`Color`=?Color,`State`=?State,`Img`=?Img,`RowTime`=?RowTime,`ClientType`=?ClientType where `ID`=?ID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from carowner  where `ID`=?ID;";
        #endregion

        #region 参数
        protected const string ParamID = "?ID";
        protected const string ParamCarno = "?Carno";
        protected const string ParamUserID = "?UserID";
        protected const string ParamCarBrand = "?CarBrand";
        protected const string ParamColor = "?Color";
        protected const string ParamState = "?State";
        protected const string ParamImg = "?Img";
        protected const string ParamRowTime = "?RowTime";
        protected const string ParamClientType = "?ClientType";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of CarOwnerDb</returns>
        public static List<CarOwnerDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="carowner">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(CarOwnerDb carowner)
        {
            var param= GetInsertParams(carowner);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">车辆注册编号</param> 
        /// <returns>CarOwnerDb</returns>
        public static CarOwnerDb  GetByPriKey(int id)
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
        /// <param name="carowner">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(CarOwnerDb carowner)
        {
            var param= GetUpdateParams(carowner);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">车辆注册编号</param> 
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
        public static MySqlParameter[]  GetUpdateParams(CarOwnerDb carowner)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamID,carowner.ID),
                    new MySqlParameter(ParamCarno,carowner.Carno),
                    new MySqlParameter(ParamUserID,carowner.UserID),
                    new MySqlParameter(ParamCarBrand,carowner.CarBrand),
                    new MySqlParameter(ParamColor,carowner.Color),
                    new MySqlParameter(ParamState,carowner.State),
                    new MySqlParameter(ParamImg,carowner.Img),
                    new MySqlParameter(ParamRowTime,carowner.RowTime),
                    new MySqlParameter(ParamClientType,carowner.ClientType)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(CarOwnerDb carowner)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCarno,carowner.Carno),
                    new MySqlParameter(ParamUserID,carowner.UserID),
                    new MySqlParameter(ParamCarBrand,carowner.CarBrand),
                    new MySqlParameter(ParamColor,carowner.Color),
                    new MySqlParameter(ParamState,carowner.State),
                    new MySqlParameter(ParamImg,carowner.Img),
                    new MySqlParameter(ParamRowTime,carowner.RowTime),
                    new MySqlParameter(ParamClientType,carowner.ClientType)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>CarOwnerDb</returns>
        public static CarOwnerDb  ConvertToObject(DataRow dr)
        {
            var data = new CarOwnerDb
                {
                    ID = DbChange.ToInt(dr["ID"],0),
                    Carno = DbChange.ToString(dr["Carno"]),
                    UserID = DbChange.ToInt(dr["UserID"],0),
                    CarBrand = DbChange.ToString(dr["CarBrand"]),
                    Color = DbChange.ToString(dr["Color"]),
                    State = DbChange.ToInt(dr["State"],0),
                    Img = DbChange.ToString(dr["Img"]),
                    RowTime = DbChange.ToDateTime(dr["RowTime"],DateTime.MinValue),
                    ClientType = DbChange.ToInt(dr["ClientType"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of CarOwnerDb</returns>
        public static List<CarOwnerDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<CarOwnerDb>(); 
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
