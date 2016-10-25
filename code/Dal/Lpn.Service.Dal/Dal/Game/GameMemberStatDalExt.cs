using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using OneCoin.Service.Model.Db.Game;
using OneCoin.Service.Dal.Utility;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace OneCoin.Service.Dal.Dal.Game
{
    /// <summary>
    ///  Dal帮助类
    /// </summary> 
    public partial class GameMemberStatDal 
    {
        #region SQL 
        //新增插入语句
        protected const string SqlSaveStat = @"INSERT INTO  `game_member_stat` (`GameNo`,`UId`,`BuyAmount`,`RowTime`) 
VALUES(?GameNo,?UId,?BuyAmount,NOW())  ON DUPLICATE KEY UPDATE     `BuyAmount`=`BuyAmount`+?BuyAmount;";

        protected const string SqlGet = @"select * from `game_member_stat`  where  `GameNo`=?GameNo and `UId`=?UId;";

        #endregion


        public static bool Save(MySqlConnection conn, GameMemberStatDb gamememberstat)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamGameNo,gamememberstat.GameNo),
                    new MySqlParameter(ParamUId,gamememberstat.UId),
                    new MySqlParameter(ParamBuyAmount,gamememberstat.BuyAmount)
                };

            var result = DbHelper.ExecuteNonQuery(conn, SqlSaveStat,true, param);

            return result > 0;
        }


        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of GameMemberStatDb</returns>
        public static GameMemberStatDb Get(string gameNo,string userId)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamGameNo,gameNo),
                    new MySqlParameter(ParamUId,userId)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGet,param);

            //判断是否存在数据
            if (null != dr && dr.Rows.Count > 0)
            {
                return ConvertToObject(dr.Rows[0]);
            }

            return null;
        }
        #endregion

     }
}
