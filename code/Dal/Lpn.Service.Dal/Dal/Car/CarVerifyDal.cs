using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Car;

/*
* 由自动生成工具完成
* 描述:车主认证信息 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Car
{
    /// <summary>
    /// 车主认证信息 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class CarVerifyDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from car_verify;";
        //新增插入语句
        protected const string SqlInsert = "insert into car_verify(`CarNo`,`UserId`,`UserName`,`Brand`,`RegTime`,`FrameNo`,`State`,`Img`,`RowTime`,`ClientType`,`VerifyTime`,`Remark`,`RangeOfValue`,`Operator`,`OperateTime`) values(?CarNo,?UserId,?UserName,?Brand,?RegTime,?FrameNo,?State,?Img,?RowTime,?ClientType,?VerifyTime,?Remark,?RangeOfValue,?Operator,?OperateTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from car_verify where `CarNo`=?CarNo;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update car_verify set `UserId`=?UserId,`UserName`=?UserName,`Brand`=?Brand,`RegTime`=?RegTime,`FrameNo`=?FrameNo,`State`=?State,`Img`=?Img,`RowTime`=?RowTime,`ClientType`=?ClientType,`VerifyTime`=?VerifyTime,`Remark`=?Remark,`RangeOfValue`=?RangeOfValue,`Operator`=?Operator,`OperateTime`=?OperateTime where `CarNo`=?CarNo;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from car_verify  where `CarNo`=?CarNo;";
        #endregion

        #region 参数
        protected const string ParamCarNo = "?CarNo";
        protected const string ParamUserId = "?UserId";
        protected const string ParamUserName = "?UserName";
        protected const string ParamBrand = "?Brand";
        protected const string ParamRegTime = "?RegTime";
        protected const string ParamFrameNo = "?FrameNo";
        protected const string ParamState = "?State";
        protected const string ParamImg = "?Img";
        protected const string ParamRowTime = "?RowTime";
        protected const string ParamClientType = "?ClientType";
        protected const string ParamVerifyTime = "?VerifyTime";
        protected const string ParamRemark = "?Remark";
        protected const string ParamRangeOfValue = "?RangeOfValue";
        protected const string ParamOperator = "?Operator";
        protected const string ParamOperateTime = "?OperateTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of CarVerifyDb</returns>
        public static List<CarVerifyDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="carverify">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(CarVerifyDb carverify)
        {
            var param= GetInsertParams(carverify);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="carNo">车牌号</param> 
        /// <returns>CarVerifyDb</returns>
        public static CarVerifyDb  GetByPriKey(string carNo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCarNo,carNo)
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
        /// <param name="carverify">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(CarVerifyDb carverify)
        {
            var param= GetUpdateParams(carverify);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="carNo">车牌号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string carNo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCarNo,carNo)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(CarVerifyDb carverify)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCarNo,carverify.CarNo),
                    new MySqlParameter(ParamUserId,carverify.UserId),
                    new MySqlParameter(ParamUserName,carverify.UserName),
                    new MySqlParameter(ParamBrand,carverify.Brand),
                    new MySqlParameter(ParamRegTime,carverify.RegTime),
                    new MySqlParameter(ParamFrameNo,carverify.FrameNo),
                    new MySqlParameter(ParamState,carverify.State),
                    new MySqlParameter(ParamImg,carverify.Img),
                    new MySqlParameter(ParamRowTime,carverify.RowTime),
                    new MySqlParameter(ParamClientType,carverify.ClientType),
                    new MySqlParameter(ParamVerifyTime,carverify.VerifyTime),
                    new MySqlParameter(ParamRemark,carverify.Remark),
                    new MySqlParameter(ParamRangeOfValue,carverify.RangeOfValue),
                    new MySqlParameter(ParamOperator,carverify.Operator),
                    new MySqlParameter(ParamOperateTime,carverify.OperateTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(CarVerifyDb carverify)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCarNo,carverify.CarNo),
                    new MySqlParameter(ParamUserId,carverify.UserId),
                    new MySqlParameter(ParamUserName,carverify.UserName),
                    new MySqlParameter(ParamBrand,carverify.Brand),
                    new MySqlParameter(ParamRegTime,carverify.RegTime),
                    new MySqlParameter(ParamFrameNo,carverify.FrameNo),
                    new MySqlParameter(ParamState,carverify.State),
                    new MySqlParameter(ParamImg,carverify.Img),
                    new MySqlParameter(ParamRowTime,carverify.RowTime),
                    new MySqlParameter(ParamClientType,carverify.ClientType),
                    new MySqlParameter(ParamVerifyTime,carverify.VerifyTime),
                    new MySqlParameter(ParamRemark,carverify.Remark),
                    new MySqlParameter(ParamRangeOfValue,carverify.RangeOfValue),
                    new MySqlParameter(ParamOperator,carverify.Operator),
                    new MySqlParameter(ParamOperateTime,carverify.OperateTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>CarVerifyDb</returns>
        public static CarVerifyDb  ConvertToObject(DataRow dr)
        {
            var data = new CarVerifyDb
                {
                    CarNo = DbChange.ToString(dr["CarNo"]),
                    UserId = DbChange.ToInt(dr["UserId"],0),
                    UserName = DbChange.ToString(dr["UserName"]),
                    Brand = DbChange.ToString(dr["Brand"]),
                    RegTime = DbChange.ToDateTime(dr["RegTime"],DateTime.MinValue),
                    FrameNo = DbChange.ToString(dr["FrameNo"]),
                    State = DbChange.ToInt(dr["State"],0),
                    Img = DbChange.ToString(dr["Img"]),
                    RowTime = DbChange.ToDateTime(dr["RowTime"],DateTime.MinValue),
                    ClientType = DbChange.ToInt(dr["ClientType"],0),
                    VerifyTime = DbChange.ToDateTime(dr["VerifyTime"],DateTime.MinValue),
                    Remark = DbChange.ToString(dr["Remark"]),
                    RangeOfValue = DbChange.ToInt(dr["RangeOfValue"],0),
                    Operator = DbChange.ToString(dr["Operator"]),
                    OperateTime = DbChange.ToDateTime(dr["OperateTime"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of CarVerifyDb</returns>
        public static List<CarVerifyDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<CarVerifyDb>(); 
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
