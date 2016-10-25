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
    public partial class GameShowDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from game_show;";
        //新增插入语句
        protected const string SqlInsert = "insert into game_show(`UId`,`PName`,`PId`,`GameNo`,`Comment`,`Imgs`,`BuyAmount`,`RowTime`) values(?UId,?PName,?PId,?GameNo,?Comment,?Imgs,?BuyAmount,?RowTime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from game_show where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update game_show set `UId`=?UId,`PName`=?PName,`PId`=?PId,`GameNo`=?GameNo,`Comment`=?Comment,`Imgs`=?Imgs,`BuyAmount`=?BuyAmount,`RowTime`=?RowTime where `Id`=?Id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from game_show  where `Id`=?Id;";
        #endregion

        #region 参数
        protected const string ParamId = "?Id";
        protected const string ParamUId = "?UId";
        protected const string ParamPName = "?PName";
        protected const string ParamPId = "?PId";
        protected const string ParamGameNo = "?GameNo";
        protected const string ParamComment = "?Comment";
        protected const string ParamImgs = "?Imgs";
        protected const string ParamBuyAmount = "?BuyAmount";
        protected const string ParamRowTime = "?RowTime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of GameShowDb</returns>
        public static List<GameShowDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="gameshow">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(GameShowDb gameshow)
        {
            var param= GetInsertParams(gameshow);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>GameShowDb</returns>
        public static GameShowDb  GetByPriKey(long id)
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
        /// <param name="gameshow">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(GameShowDb gameshow)
        {
            var param= GetUpdateParams(gameshow);
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
        public static MySqlParameter[]  GetUpdateParams(GameShowDb gameshow)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamId,gameshow.Id),
                    new MySqlParameter(ParamUId,gameshow.UId),
                    new MySqlParameter(ParamPName,gameshow.PName),
                    new MySqlParameter(ParamPId,gameshow.PId),
                    new MySqlParameter(ParamGameNo,gameshow.GameNo),
                    new MySqlParameter(ParamComment,gameshow.Comment),
                    new MySqlParameter(ParamImgs,gameshow.Imgs),
                    new MySqlParameter(ParamBuyAmount,gameshow.BuyAmount),
                    new MySqlParameter(ParamRowTime,gameshow.RowTime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(GameShowDb gameshow)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUId,gameshow.UId),
                    new MySqlParameter(ParamPName,gameshow.PName),
                    new MySqlParameter(ParamPId,gameshow.PId),
                    new MySqlParameter(ParamGameNo,gameshow.GameNo),
                    new MySqlParameter(ParamComment,gameshow.Comment),
                    new MySqlParameter(ParamImgs,gameshow.Imgs),
                    new MySqlParameter(ParamBuyAmount,gameshow.BuyAmount),
                    new MySqlParameter(ParamRowTime,gameshow.RowTime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>GameShowDb</returns>
        public static GameShowDb  ConvertToObject(DataRow dr)
        {
            var data = new GameShowDb
                {
                    Id = DbChange.ToLong(dr["Id"],0),
                    UId = DbChange.ToString(dr["UId"]),
                    PName = DbChange.ToString(dr["PName"]),
                    PId = DbChange.ToString(dr["PId"]),
                    GameNo = DbChange.ToString(dr["GameNo"]),
                    Comment = DbChange.ToString(dr["Comment"]),
                    Imgs = DbChange.ToString(dr["Imgs"]),
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
        /// <returns>List of GameShowDb</returns>
        public static List<GameShowDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<GameShowDb>(); 
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
