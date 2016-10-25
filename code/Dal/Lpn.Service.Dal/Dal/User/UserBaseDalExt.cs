using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Helper.Http;
using OneCoin.Service.Model.Db.User;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/22
*/
namespace OneCoin.Service.Dal.Dal.User
{
    /// <summary>
    ///  Dal帮助类
    /// </summary> 
    public partial class UserBaseDal
    {
        #region SQL

        //查询指定的账号是否存在
        protected const string SqlIsExistsUserName = "select 1  from user_base where Mobile=?Mobile";

        // 查询指定账户名的账号
        protected const string SqlGetUserByName = "select *  from user_base where Mobile=?Mobile";

         //根据主键更新iostoken
        protected const string SqlUpdateDt = "update user_base set  `DeviceToken`=?DeviceToken where `ID`=?ID;";


        //根据主键更新iostoken  
        protected const string SqlGetUserFormatter = "select * from user_base where id in('{0}')";


         #endregion

        #region 参数
        protected const string ParamTake = "?Take";

        #endregion

        public static List<UserBaseDb> GetUsers(List<string> userIds)
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr,string.Format(SqlGetUserFormatter, Spanner.Join(userIds, "','")));

            return ConvertToObjects(dr);
        }


        #region 查询指定的账号是否存在
        /// <summary>
        /// 查询指定的账号是否存在
        /// </summary> 
        /// <param name="mobile"></param> 
        /// <returns>true or false</returns>
        public static bool IsExistsUserName(string mobile)
        {
            var param = new[]
                {  
                    new MySqlParameter(ParamMobile,mobile)
                };

            return DbHelper.ExecuteReaderIdentityInt32(ConntionStr, SqlIsExistsUserName, param) > 0;
        }
        #endregion

        #region 查询指定账户名的账号
        /// <summary>
        /// 查询指定账户名的账号
        /// </summary> 
        /// <param name="mobile"></param> 
        /// <returns>true or false</returns>
        public static UserBaseDb GetUserByName(string mobile)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamMobile,mobile)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetUserByName, param);

            //判断是否存在数据
            if (null != dr && dr.Rows.Count > 0)
            {
                return ConvertToObject(dr.Rows[0]);
            }

            return null;
        }
        #endregion

     
        public static void UpdateDt(string userId, string dt)
        {
            var param = new[]
                {  
                    new MySqlParameter(ParamId,userId),
                    new MySqlParameter(ParamDeviceToken,dt)
                };

            DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateDt, param);
        } 
    }
}
