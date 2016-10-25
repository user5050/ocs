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
* 创建时间:2016/10/22
*/
namespace OneCoin.Service.Dal.Dal.User
{
    /// <summary>
    ///  Dal帮助类
    /// </summary> 
    public partial class UserContractDal
    {
        #region SQL

        //根据主键更新整行数据
        protected const string SqlGetByUserId = "select * from  user_contract where `Uid`=?Uid;";

        protected const string SqlGetCntByUserId = "select count(*) from  user_contract where `Uid`=?Uid;";

        protected const string SqlUpdateDefault = "update user_contract set IsDefault= case when Id=?Id then 1 else 0 end  where `Uid`=?Uid;";

        //新增插入语句
        protected const string SqlInsertWithRetId = "insert into user_contract(`Id`,`Uid`,`Name`,`contract`,`Address`,`IsDefault`,`RowTime`) values(?Id,?Uid,?Name,?contract,?Address,?IsDefault,?RowTime);select LAST_INSERT_ID();";
       
        #endregion


        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="userId">userId</param> 
        /// <returns>UserContractDb</returns>
        public static List<UserContractDb> GetByUserId(string userId)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUid,userId)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetByUserId, param);
             
            return ConvertToObjects(dr);
        }
        #endregion


        public static int GetCntByUserId(string userId)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUid,userId)
                };

           return DbHelper.ExecuteReaderIdentityInt32(ConntionStr, SqlGetCntByUserId, param);
        }

        public static bool UpdateDefault(string userId,int id)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,id),
                    new MySqlParameter(ParamUid,userId)
                };

            return DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateDefault, param) > 0;
        }

        public static bool InsertWithFillId(UserContractDb usercontract)
        {
            var param = GetInsertParams(usercontract);
            var result = DbHelper.ExecuteReaderIdentityInt32(ConntionStr, SqlInsertWithRetId, param);

            if (result > 0)
            {
                usercontract.Id = result;
            }

            return result > 0;
        }
    }
}
