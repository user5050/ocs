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
    public partial class GameStockInfoDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from game_stock_info;";
        //新增插入语句
        protected const string SqlInsert = "insert into game_stock_info(`Code`,`Name`) values(?Code,?Name);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from game_stock_info where `Code`=?Code;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update game_stock_info set `Name`=?Name where `Code`=?Code;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from game_stock_info  where `Code`=?Code;";
        #endregion

        #region 参数
        protected const string ParamCode = "?Code";
        protected const string ParamName = "?Name";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of GameStockInfoDb</returns>
        public static List<GameStockInfoDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="gamestockinfo">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(GameStockInfoDb gamestockinfo)
        {
            var param= GetInsertParams(gamestockinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="code"></param> 
        /// <returns>GameStockInfoDb</returns>
        public static GameStockInfoDb  GetByPriKey(string code)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCode,code)
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
        /// <param name="gamestockinfo">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(GameStockInfoDb gamestockinfo)
        {
            var param= GetUpdateParams(gamestockinfo);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="code"></param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(string code)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCode,code)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(GameStockInfoDb gamestockinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCode,gamestockinfo.Code),
                    new MySqlParameter(ParamName,gamestockinfo.Name)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(GameStockInfoDb gamestockinfo)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamCode,gamestockinfo.Code),
                    new MySqlParameter(ParamName,gamestockinfo.Name)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>GameStockInfoDb</returns>
        public static GameStockInfoDb  ConvertToObject(DataRow dr)
        {
            var data = new GameStockInfoDb
                {
                    Code = DbChange.ToString(dr["Code"]),
                    Name = DbChange.ToString(dr["Name"])
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of GameStockInfoDb</returns>
        public static List<GameStockInfoDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<GameStockInfoDb>(); 
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
