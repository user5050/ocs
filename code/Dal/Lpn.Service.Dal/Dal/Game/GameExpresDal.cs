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
    public partial class GameExpresDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from game_express;";
        //新增插入语句
        protected const string SqlInsert = "insert into game_express(`GameNo`,`Name`,`Contract`,`Address`,`ExpressNo`,`Img`,`SpName`,`SendTime`,`State`) values(?GameNo,?Name,?Contract,?Address,?ExpressNo,?Img,?SpName,?SendTime,?State);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from game_express where `GameNo`=?GameNo;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update game_express set `Name`=?Name,`Contract`=?Contract,`Address`=?Address,`ExpressNo`=?ExpressNo,`Img`=?Img,`SpName`=?SpName,`SendTime`=?SendTime,`State`=?State where `GameNo`=?GameNo;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from game_express  where `GameNo`=?GameNo;";
        #endregion

        #region 参数
        protected const string ParamGameNo = "?GameNo";
        protected const string ParamName = "?Name";
        protected const string ParamContract = "?Contract";
        protected const string ParamAddress = "?Address";
        protected const string ParamExpressNo = "?ExpressNo";
        protected const string ParamImg = "?Img";
        protected const string ParamSpName = "?SpName";
        protected const string ParamSendTime = "?SendTime";
        protected const string ParamState = "?State";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of GameExpresDb</returns>
        public static List<GameExpresDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="gameexpres">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(GameExpresDb gameexpres)
        {
            var param= GetInsertParams(gameexpres);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="gameNo">期号</param> 
        /// <returns>GameExpresDb</returns>
        public static GameExpresDb  GetByPriKey(string gameNo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamGameNo,gameNo)
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
        /// <param name="gameexpres">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(GameExpresDb gameexpres)
        {
            var param= GetUpdateParams(gameexpres);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="gameNo">期号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string gameNo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamGameNo,gameNo)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(GameExpresDb gameexpres)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamGameNo,gameexpres.GameNo),
                    new MySqlParameter(ParamName,gameexpres.Name),
                    new MySqlParameter(ParamContract,gameexpres.Contract),
                    new MySqlParameter(ParamAddress,gameexpres.Address),
                    new MySqlParameter(ParamExpressNo,gameexpres.ExpressNo),
                    new MySqlParameter(ParamImg,gameexpres.Img),
                    new MySqlParameter(ParamSpName,gameexpres.SpName),
                    new MySqlParameter(ParamSendTime,gameexpres.SendTime),
                    new MySqlParameter(ParamState,gameexpres.State)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(GameExpresDb gameexpres)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamGameNo,gameexpres.GameNo),
                    new MySqlParameter(ParamName,gameexpres.Name),
                    new MySqlParameter(ParamContract,gameexpres.Contract),
                    new MySqlParameter(ParamAddress,gameexpres.Address),
                    new MySqlParameter(ParamExpressNo,gameexpres.ExpressNo),
                    new MySqlParameter(ParamImg,gameexpres.Img),
                    new MySqlParameter(ParamSpName,gameexpres.SpName),
                    new MySqlParameter(ParamSendTime,gameexpres.SendTime),
                    new MySqlParameter(ParamState,gameexpres.State)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>GameExpresDb</returns>
        public static GameExpresDb  ConvertToObject(DataRow dr)
        {
            var data = new GameExpresDb
                {
                    GameNo = DbChange.ToString(dr["GameNo"]),
                    Name = DbChange.ToString(dr["Name"]),
                    Contract = DbChange.ToString(dr["Contract"]),
                    Address = DbChange.ToString(dr["Address"]),
                    ExpressNo = DbChange.ToString(dr["ExpressNo"]),
                    Img = DbChange.ToString(dr["Img"]),
                    SpName = DbChange.ToString(dr["SpName"]),
                    SendTime = DbChange.ToDateTime(dr["SendTime"],DateTime.MinValue),
                    State = DbChange.ToInt(dr["State"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of GameExpresDb</returns>
        public static List<GameExpresDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<GameExpresDb>(); 
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
