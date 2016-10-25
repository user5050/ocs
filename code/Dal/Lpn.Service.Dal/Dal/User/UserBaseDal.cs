using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Model.Db.User;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Dal.Dal.User
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    [Serializable]
    public partial class UserBaseDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from user_base;";
        //新增插入语句
        protected const string SqlInsert = "insert into user_base(`Id`,`Head`,`Name`,`Mobile`,`ClientType`,`DeviceToken`,`RegTime`,`State`) values(?Id,?Head,?Name,?Mobile,?ClientType,?DeviceToken,?RegTime,?State);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from user_base where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update user_base set `Head`=?Head,`Name`=?Name,`Mobile`=?Mobile,`ClientType`=?ClientType,`DeviceToken`=?DeviceToken,`RegTime`=?RegTime,`State`=?State where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from user_base  where `Id`=?Id;";
        #endregion

        #region 参数
        protected const string ParamId = "?Id";
        protected const string ParamHead = "?Head";
        protected const string ParamName = "?Name";
        protected const string ParamMobile = "?Mobile";
        protected const string ParamClientType = "?ClientType";
        protected const string ParamDeviceToken = "?DeviceToken";
        protected const string ParamRegTime = "?RegTime";
        protected const string ParamState = "?State";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of UserBaseDb</returns>
        public static List<UserBaseDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="userbase">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(UserBaseDb userbase)
        {
            var param= GetInsertParams(userbase);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>UserBaseDb</returns>
        public static UserBaseDb  GetByPriKey(string id)
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
        /// <param name="userbase">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(UserBaseDb userbase)
        {
            var param= GetUpdateParams(userbase);
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
        public static MySqlParameter[]  GetUpdateParams(UserBaseDb userbase)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,userbase.Id),
                    new MySqlParameter(ParamHead,userbase.Head),
                    new MySqlParameter(ParamName,userbase.Name),
                    new MySqlParameter(ParamMobile,userbase.Mobile),
                    new MySqlParameter(ParamClientType,userbase.ClientType),
                    new MySqlParameter(ParamDeviceToken,userbase.DeviceToken),
                    new MySqlParameter(ParamRegTime,userbase.RegTime),
                    new MySqlParameter(ParamState,userbase.State)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(UserBaseDb userbase)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,userbase.Id),
                    new MySqlParameter(ParamHead,userbase.Head),
                    new MySqlParameter(ParamName,userbase.Name),
                    new MySqlParameter(ParamMobile,userbase.Mobile),
                    new MySqlParameter(ParamClientType,userbase.ClientType),
                    new MySqlParameter(ParamDeviceToken,userbase.DeviceToken),
                    new MySqlParameter(ParamRegTime,userbase.RegTime),
                    new MySqlParameter(ParamState,userbase.State)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>UserBaseDb</returns>
        public static UserBaseDb  ConvertToObject(DataRow dr)
        {
            var data = new UserBaseDb
                {
                    Id = DbChange.ToString(dr["Id"]),
                    Head = DbChange.ToString(dr["Head"]),
                    Name = DbChange.ToString(dr["Name"]),
                    Mobile = DbChange.ToString(dr["Mobile"]),
                    ClientType = DbChange.ToInt(dr["ClientType"],0),
                    DeviceToken = DbChange.ToString(dr["DeviceToken"]),
                    RegTime = DbChange.ToDateTime(dr["RegTime"],DateTime.MinValue),
                    State = DbChange.ToInt(dr["State"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of UserBaseDb</returns>
        public static List<UserBaseDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<UserBaseDb>(); 
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
