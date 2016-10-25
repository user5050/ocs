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
    [Serializable]
    public partial class GameMemberStatDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from game_member_stat;";
        //新增插入语句
        protected const string SqlInsert = "insert into game_member_stat(`GameNo`,`UId`,`BuyAmount`,`RowTime`) values(?GameNo,?UId,?BuyAmount,?RowTime);";
        #endregion

        #region 参数
        protected const string ParamGameNo = "?GameNo";
        protected const string ParamUId = "?UId";
        protected const string ParamBuyAmount = "?BuyAmount";
        protected const string ParamRowTime = "?RowTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of GameMemberStatDb</returns>
        public static List<GameMemberStatDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="gamememberstat">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(GameMemberStatDb gamememberstat)
        {
            var param= GetInsertParams(gamememberstat);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(GameMemberStatDb gamememberstat)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamGameNo,gamememberstat.GameNo),
                    new MySqlParameter(ParamUId,gamememberstat.UId),
                    new MySqlParameter(ParamBuyAmount,gamememberstat.BuyAmount),
                    new MySqlParameter(ParamRowTime,gamememberstat.RowTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>GameMemberStatDb</returns>
        public static GameMemberStatDb  ConvertToObject(DataRow dr)
        {
            var data = new GameMemberStatDb
                {
                    GameNo = DbChange.ToString(dr["GameNo"]),
                    UId = DbChange.ToString(dr["UId"]),
                    BuyAmount = DbChange.ToInt(dr["BuyAmount"],0),
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
        /// <returns>List of GameMemberStatDb</returns>
        public static List<GameMemberStatDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<GameMemberStatDb>(); 
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
