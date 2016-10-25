using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Model.Db.Home;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/22
*/
namespace OneCoin.Service.Dal.Dal.Home
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    public partial class HomeNewDal
    {
        #region SQL

        //获取整个表数据
        protected const string SqlGets = "select * from home_news where `StartTime` <= now() and now()<= `ExpiredTime` order by `StartTime` desc;";

        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary> 
        /// <returns>HomeNewDb</returns>
        public static List<HomeNewDb> Gets()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGets);
              
            return ConvertToObjects(dr);
        }
        #endregion

    }
}
