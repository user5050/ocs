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
    public partial class UserContractDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from user_contract;";
        //新增插入语句
        protected const string SqlInsert = "insert into user_contract(`Id`,`Uid`,`Name`,`contract`,`Address`,`IsDefault`,`RowTime`) values(?Id,?Uid,?Name,?contract,?Address,?IsDefault,?RowTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from user_contract where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update user_contract set `Uid`=?Uid,`Name`=?Name,`contract`=?contract,`Address`=?Address,`IsDefault`=?IsDefault,`RowTime`=?RowTime where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from user_contract  where `Id`=?Id;";
        #endregion

        #region 参数
        protected const string ParamId = "?Id";
        protected const string ParamUid = "?Uid";
        protected const string ParamName = "?Name";
        protected const string Paramcontract = "?contract";
        protected const string ParamAddress = "?Address";
        protected const string ParamIsDefault = "?IsDefault";
        protected const string ParamRowTime = "?RowTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of UserContractDb</returns>
        public static List<UserContractDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="usercontract">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(UserContractDb usercontract)
        {
            var param= GetInsertParams(usercontract);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">id</param> 
        /// <returns>UserContractDb</returns>
        public static UserContractDb  GetByPriKey(int id)
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
        /// <param name="usercontract">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(UserContractDb usercontract)
        {
            var param= GetUpdateParams(usercontract);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">id</param> 
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
        public static MySqlParameter[]  GetUpdateParams(UserContractDb usercontract)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,usercontract.Id),
                    new MySqlParameter(ParamUid,usercontract.Uid),
                    new MySqlParameter(ParamName,usercontract.Name),
                    new MySqlParameter(Paramcontract,usercontract.Contract),
                    new MySqlParameter(ParamAddress,usercontract.Address),
                    new MySqlParameter(ParamIsDefault,usercontract.IsDefault),
                    new MySqlParameter(ParamRowTime,usercontract.RowTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(UserContractDb usercontract)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,usercontract.Id),
                    new MySqlParameter(ParamUid,usercontract.Uid),
                    new MySqlParameter(ParamName,usercontract.Name),
                    new MySqlParameter(Paramcontract,usercontract.Contract),
                    new MySqlParameter(ParamAddress,usercontract.Address),
                    new MySqlParameter(ParamIsDefault,usercontract.IsDefault),
                    new MySqlParameter(ParamRowTime,usercontract.RowTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>UserContractDb</returns>
        public static UserContractDb  ConvertToObject(DataRow dr)
        {
            var data = new UserContractDb
                {
                    Id = DbChange.ToInt(dr["Id"],0),
                    Uid = DbChange.ToString(dr["Uid"]),
                    Name = DbChange.ToString(dr["Name"]),
                    Contract = DbChange.ToString(dr["contract"]),
                    Address = DbChange.ToString(dr["Address"]),
                    IsDefault = DbChange.ToInt(dr["IsDefault"],0),
                    RowTime = DbChange.ToDateTime(dr["RowTime"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of UserContractDb</returns>
        public static List<UserContractDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<UserContractDb>(); 
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
