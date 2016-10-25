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
* 创建时间:2016/10/22
*/
namespace OneCoin.Service.Dal.Dal.Game
{
    /// <summary>
    ///  Dal帮助类
    /// </summary> 
    public partial class GameMemberDal
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetMembers = "SELECT * FROM game_member  WHERE gameno =?GameNo and Id <?Skip order by Id desc LIMIT 0,?Take;";

        protected const string SqlFindMemberWithNo = "SELECT * FROM game_member  WHERE gameno =?GameNo  AND  StartNo <= ?StartNo ORDER BY StartNo DESC LIMIT 0,1;";
        #endregion

        #region 参数
        protected const string ParamSkip = "?Skip";
        protected const string ParamTake = "?Take";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of GameMemberDb</returns>
        public static List<GameMemberDb> GetMembers(string gameNo,int lastNo,int take)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamSkip,lastNo),
                    new MySqlParameter(ParamTake,take),
                    new MySqlParameter(ParamGameNo,gameNo)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetMembers,param);

            return ConvertToObjects(dr);
        }
        #endregion


        public static GameMemberDb FindMemberWithNo(string gameNo, int winNo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamStartNo,winNo), 
                    new MySqlParameter(ParamGameNo,gameNo)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlFindMemberWithNo, param);

            //判断是否存在数据
            if (null != dr && dr.Rows.Count > 0)
            {
                return ConvertToObject(dr.Rows[0]);
            }

            return null;
        }


        public static bool Insert(MySqlConnection conn, GameMemberDb gamemember)
        {
            var param = GetInsertParams(gamemember);
            var result = DbHelper.ExecuteNonQuery(conn, SqlInsert,true, param);

            return result > 0;
        }
    
     }
}
