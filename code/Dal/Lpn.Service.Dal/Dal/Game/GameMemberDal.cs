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
    public partial class GameMemberDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from game_member;";
        //新增插入语句
        protected const string SqlInsert = "insert into game_member(`GameNo`,`UId`,`IpAddr`,`BuyAmount`,`StartNo`,`EndNo`,`OrderNo`,`RowTime`) values(?GameNo,?UId,?IpAddr,?BuyAmount,?StartNo,?EndNo,?OrderNo,?RowTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from game_member where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update game_member set `GameNo`=?GameNo,`UId`=?UId,`IpAddr`=?IpAddr,`BuyAmount`=?BuyAmount,`StartNo`=?StartNo,`EndNo`=?EndNo,`OrderNo`=?OrderNo,`RowTime`=?RowTime where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from game_member  where `Id`=?Id;";
        #endregion

        #region 参数
        protected const string ParamId = "?Id";
        protected const string ParamGameNo = "?GameNo";
        protected const string ParamUId = "?UId";
        protected const string ParamIpAddr = "?IpAddr";
        protected const string ParamBuyAmount = "?BuyAmount";
        protected const string ParamStartNo = "?StartNo";
        protected const string ParamEndNo = "?EndNo";
        protected const string ParamOrderNo = "?OrderNo";
        protected const string ParamRowTime = "?RowTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of GameMemberDb</returns>
        public static List<GameMemberDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="gamemember">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(GameMemberDb gamemember)
        {
            var param= GetInsertParams(gamemember);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>GameMemberDb</returns>
        public static GameMemberDb  GetByPriKey(long id)
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
        /// <param name="gamemember">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(GameMemberDb gamemember)
        {
            var param= GetUpdateParams(gamemember);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(long id)
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
        public static MySqlParameter[]  GetUpdateParams(GameMemberDb gamemember)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,gamemember.Id),
                    new MySqlParameter(ParamGameNo,gamemember.GameNo),
                    new MySqlParameter(ParamUId,gamemember.UId),
                    new MySqlParameter(ParamIpAddr,gamemember.IpAddr),
                    new MySqlParameter(ParamBuyAmount,gamemember.BuyAmount),
                    new MySqlParameter(ParamStartNo,gamemember.StartNo),
                    new MySqlParameter(ParamEndNo,gamemember.EndNo),
                    new MySqlParameter(ParamOrderNo,gamemember.OrderNo),
                    new MySqlParameter(ParamRowTime,gamemember.RowTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(GameMemberDb gamemember)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamGameNo,gamemember.GameNo),
                    new MySqlParameter(ParamUId,gamemember.UId),
                    new MySqlParameter(ParamIpAddr,gamemember.IpAddr),
                    new MySqlParameter(ParamBuyAmount,gamemember.BuyAmount),
                    new MySqlParameter(ParamStartNo,gamemember.StartNo),
                    new MySqlParameter(ParamEndNo,gamemember.EndNo),
                    new MySqlParameter(ParamOrderNo,gamemember.OrderNo),
                    new MySqlParameter(ParamRowTime,gamemember.RowTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>GameMemberDb</returns>
        public static GameMemberDb  ConvertToObject(DataRow dr)
        {
            var data = new GameMemberDb
                {
                    Id = DbChange.ToLong(dr["Id"],0),
                    GameNo = DbChange.ToString(dr["GameNo"]),
                    UId = DbChange.ToString(dr["UId"]),
                    IpAddr = DbChange.ToString(dr["IpAddr"]),
                    BuyAmount = DbChange.ToInt(dr["BuyAmount"],0),
                    StartNo = DbChange.ToInt(dr["StartNo"],0),
                    EndNo = DbChange.ToInt(dr["EndNo"],0),
                    OrderNo = DbChange.ToString(dr["OrderNo"]),
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
        /// <returns>List of GameMemberDb</returns>
        public static List<GameMemberDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<GameMemberDb>(); 
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
