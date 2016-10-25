using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Model.Db.Game;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Dal.Dal.Game
{
    /// <summary>
    ///  Dal帮助类
    /// </summary> 
    public partial class GameComputeFactorDal
    {

        #region 新增数据

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="gamecomputefactor">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool Insert(MySqlConnection conn, GameComputeFactorDb gamecomputefactor)
        {
            var param = GetInsertParams(gamecomputefactor);
            var result = DbHelper.ExecuteNonQuery(conn, SqlInsert, true,param);

            return result > 0;
        }
        #endregion
      

     }
}
