using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Park;

/*
* 由自动生成工具完成
* 描述:[park_news]停车场新闻列表 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Park
{
    /// <summary>
    /// [park_news]停车场新闻列表 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ParkNewDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parknews;";
        //新增插入语句
        protected const string SqlInsert = "insert into parknews(`Title`,`InfoType`,`Abstract`,`Img`,`Html`,`Operator`,`OperationTime`,`IsPublished`,`Url`,`SendTime`,`Rule`,`RuleType`) values(?Title,?InfoType,?Abstract,?Img,?Html,?Operator,?OperationTime,?IsPublished,?Url,?SendTime,?Rule,?RuleType);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from parknews where `NewsID`=?NewsID;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update parknews set `Title`=?Title,`InfoType`=?InfoType,`Abstract`=?Abstract,`Img`=?Img,`Html`=?Html,`Operator`=?Operator,`OperationTime`=?OperationTime,`IsPublished`=?IsPublished,`Url`=?Url,`SendTime`=?SendTime,`Rule`=?Rule,`RuleType`=?RuleType where `NewsID`=?NewsID;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from parknews  where `NewsID`=?NewsID;";
        #endregion

        #region 参数
        protected const string ParamNewsID = "?NewsID";
        protected const string ParamTitle = "?Title";
        protected const string ParamInfoType = "?InfoType";
        protected const string ParamAbstract = "?Abstract";
        protected const string ParamImg = "?Img";
        protected const string ParamHtml = "?Html";
        protected const string ParamOperator = "?Operator";
        protected const string ParamOperationTime = "?OperationTime";
        protected const string ParamIsPublished = "?IsPublished";
        protected const string ParamUrl = "?Url";
        protected const string ParamSendTime = "?SendTime";
        protected const string ParamRule = "?Rule";
        protected const string ParamRuleType = "?RuleType";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParkNewDb</returns>
        public static List<ParkNewDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parknew">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParkNewDb parknew)
        {
            var param= GetInsertParams(parknew);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="newsID">新闻编号</param> 
        /// <returns>ParkNewDb</returns>
        public static ParkNewDb  GetByPriKey(int newsID)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamNewsID,newsID)
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
        /// <param name="parknew">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ParkNewDb parknew)
        {
            var param= GetUpdateParams(parknew);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="newsID">新闻编号</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  DeleteByPriKey(int newsID)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamNewsID,newsID)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(ParkNewDb parknew)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamNewsID,parknew.NewsID),
                    new MySqlParameter(ParamTitle,parknew.Title),
                    new MySqlParameter(ParamInfoType,parknew.InfoType),
                    new MySqlParameter(ParamAbstract,parknew.Abstract),
                    new MySqlParameter(ParamImg,parknew.Img),
                    new MySqlParameter(ParamHtml,parknew.Html),
                    new MySqlParameter(ParamOperator,parknew.Operator),
                    new MySqlParameter(ParamOperationTime,parknew.OperationTime),
                    new MySqlParameter(ParamIsPublished,parknew.IsPublished),
                    new MySqlParameter(ParamUrl,parknew.Url),
                    new MySqlParameter(ParamSendTime,parknew.SendTime),
                    new MySqlParameter(ParamRule,parknew.Rule),
                    new MySqlParameter(ParamRuleType,parknew.RuleType)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParkNewDb parknew)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamTitle,parknew.Title),
                    new MySqlParameter(ParamInfoType,parknew.InfoType),
                    new MySqlParameter(ParamAbstract,parknew.Abstract),
                    new MySqlParameter(ParamImg,parknew.Img),
                    new MySqlParameter(ParamHtml,parknew.Html),
                    new MySqlParameter(ParamOperator,parknew.Operator),
                    new MySqlParameter(ParamOperationTime,parknew.OperationTime),
                    new MySqlParameter(ParamIsPublished,parknew.IsPublished),
                    new MySqlParameter(ParamUrl,parknew.Url),
                    new MySqlParameter(ParamSendTime,parknew.SendTime),
                    new MySqlParameter(ParamRule,parknew.Rule),
                    new MySqlParameter(ParamRuleType,parknew.RuleType)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParkNewDb</returns>
        public static ParkNewDb  ConvertToObject(DataRow dr)
        {
            var data = new ParkNewDb
                {
                    NewsID = DbChange.ToInt(dr["NewsID"],0),
                    Title = DbChange.ToString(dr["Title"]),
                    InfoType = DbChange.ToInt(dr["InfoType"],0),
                    Abstract = DbChange.ToString(dr["Abstract"]),
                    Img = DbChange.ToString(dr["Img"]),
                    Html = DbChange.ToString(dr["Html"]),
                    Operator = DbChange.ToInt(dr["Operator"],0),
                    OperationTime = DbChange.ToDateTime(dr["OperationTime"],DateTime.MinValue),
                    IsPublished = DbChange.ToInt(dr["IsPublished"],0),
                    Url = DbChange.ToString(dr["Url"]),
                    SendTime = DbChange.ToDateTime(dr["SendTime"],DateTime.MinValue),
                    Rule = DbChange.ToString(dr["Rule"]),
                    RuleType = DbChange.ToInt(dr["RuleType"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ParkNewDb</returns>
        public static List<ParkNewDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParkNewDb>(); 
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
