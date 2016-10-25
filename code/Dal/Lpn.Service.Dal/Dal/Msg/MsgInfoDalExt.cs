using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Model.Db.Msg;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/22
*/
namespace OneCoin.Service.Dal.Dal.Msg
{
    /// <summary>
    ///  Dal帮助类
    /// </summary> 
    public partial class MsgInfoDal
    {
        #region SQL

        protected const string SqlGetByUserId = "SELECT * FROM msg_info WHERE  uid=?Uid AND  sendtime <= NOW() AND endTime >= NOW() order by sendtime desc LIMIT ?Skip,?Take;";
         
        #endregion

        #region 参数

        protected const string ParamSkip = "?Skip";
        protected const string ParamTake = "?Take";

        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of MsgInfoDb</returns>
        public static List<MsgInfoDb> GetByUserId(string userId,int skip,int take)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUid,userId),
                    new MySqlParameter(ParamSkip,skip),
                    new MySqlParameter(ParamTake,take)
                };
             
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetByUserId, param);

            return ConvertToObjects(dr);
        }
        #endregion

     }
}
