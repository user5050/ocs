using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Dal.Core;
using OneCoin.Service.Helper.Http;
using OneCoin.Service.Model.Db.Game;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/22
*/
namespace OneCoin.Service.Dal.Dal.Game
{
    /// <summary>
    ///  Dal帮助类
    /// </summary> 
    public partial class GameExpresDal 
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetByGameNosFormatter = "select * from game_express where GameNo　in('{0}');";
        #endregion


        public static List<GameExpresDb> GetByGameNos(List<string> gameNos)
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, string.Format(SqlGetByGameNosFormatter, Spanner.Join(gameNos, "','")));

            return ConvertToObjects(dr);
        }

     }
}
