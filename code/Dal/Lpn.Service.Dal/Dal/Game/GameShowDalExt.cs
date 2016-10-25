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
    public partial class GameShowDal 
    {
        #region SQL

        protected const string SqlGetByPage = "select * from game_show  order by id desc limit ?Skip,?Take ;";

        protected const string SqlGetByGameNo = "select * from game_show where GameNo=?GameNo  order by id desc limit ?Skip,?Take ;";
       
        protected const string SqlGetByUser = "select * from game_show where Uid=?Uid  order by id desc limit ?Skip,?Take ;";
        #endregion

        #region 参数

        protected const string ParamSkip = "?Skip";
        protected const string ParamTake = "?Take";
         
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of GameShowDb</returns>
        public static List<GameShowDb> GetByPage(int skip,int take)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamSkip,skip),
                    new MySqlParameter(ParamTake,take)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetByPage, param);

            return ConvertToObjects(dr);
        }
        #endregion


        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of GameShowDb</returns>
        public static List<GameShowDb> GetByGameNoPage(string gameNo,int skip, int take)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamGameNo,gameNo),
                    new MySqlParameter(ParamSkip,skip),
                    new MySqlParameter(ParamTake,take)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetByGameNo, param);

            return ConvertToObjects(dr);
        }
        #endregion


        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of GameShowDb</returns>
        public static List<GameShowDb> GetByUser(string userId, int skip, int take)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamUId,userId),
                    new MySqlParameter(ParamSkip,skip),
                    new MySqlParameter(ParamTake,take)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetByUser, param);

            return ConvertToObjects(dr);
        }
        #endregion
     }
}
