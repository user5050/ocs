using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db;

/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/3/8
*/
namespace Lpn.Service.Dal.Dal
{
    /// <summary>
    ///  Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ParksettlementDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parksettlement;";
        //新增插入语句
        protected const string SqlInsert = "insert into parksettlement(`id`,`parkcode`,`ebotemptotal`,`ebotempcoupon`,`ebomonthtotal`,`ebomonthcoupon`,`ebofreetotal`,`ebofreecoupon`,`ebobusytotal`,`ebobusycoupon`,`ebofreetemptotal`,`ebofreetempcoupon`,`ebobusytemptotal`,`ebobusytempcoupon`,`localfreetotal`,`localfreecoupon`,`localbusytotal`,`localbusycoupon`,`localfreetemptotal`,`localfreetempcoupon`,`localbusytemptotal`,`localbusytempcoupon`,`parkfee`,`monthfee`,`freefee`,`busyfee`,`overfreefee`,`overbusyfee`,`balancemoney`,`starttime`,`endtime`) values(?id,?parkcode,?ebotemptotal,?ebotempcoupon,?ebomonthtotal,?ebomonthcoupon,?ebofreetotal,?ebofreecoupon,?ebobusytotal,?ebobusycoupon,?ebofreetemptotal,?ebofreetempcoupon,?ebobusytemptotal,?ebobusytempcoupon,?localfreetotal,?localfreecoupon,?localbusytotal,?localbusycoupon,?localfreetemptotal,?localfreetempcoupon,?localbusytemptotal,?localbusytempcoupon,?parkfee,?monthfee,?freefee,?busyfee,?overfreefee,?overbusyfee,?balancemoney,?starttime,?endtime);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from parksettlement where `id`=?id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update parksettlement set `parkcode`=?parkcode,`ebotemptotal`=?ebotemptotal,`ebotempcoupon`=?ebotempcoupon,`ebomonthtotal`=?ebomonthtotal,`ebomonthcoupon`=?ebomonthcoupon,`ebofreetotal`=?ebofreetotal,`ebofreecoupon`=?ebofreecoupon,`ebobusytotal`=?ebobusytotal,`ebobusycoupon`=?ebobusycoupon,`ebofreetemptotal`=?ebofreetemptotal,`ebofreetempcoupon`=?ebofreetempcoupon,`ebobusytemptotal`=?ebobusytemptotal,`ebobusytempcoupon`=?ebobusytempcoupon,`localfreetotal`=?localfreetotal,`localfreecoupon`=?localfreecoupon,`localbusytotal`=?localbusytotal,`localbusycoupon`=?localbusycoupon,`localfreetemptotal`=?localfreetemptotal,`localfreetempcoupon`=?localfreetempcoupon,`localbusytemptotal`=?localbusytemptotal,`localbusytempcoupon`=?localbusytempcoupon,`parkfee`=?parkfee,`monthfee`=?monthfee,`freefee`=?freefee,`busyfee`=?busyfee,`overfreefee`=?overfreefee,`overbusyfee`=?overbusyfee,`balancemoney`=?balancemoney,`starttime`=?starttime,`endtime`=?endtime where `id`=?id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from parksettlement  where `id`=?id;";
        #endregion

        #region 参数
        protected const string Paramid = "?id";
        protected const string Paramparkcode = "?parkcode";
        protected const string Paramebotemptotal = "?ebotemptotal";
        protected const string Paramebotempcoupon = "?ebotempcoupon";
        protected const string Paramebomonthtotal = "?ebomonthtotal";
        protected const string Paramebomonthcoupon = "?ebomonthcoupon";
        protected const string Paramebofreetotal = "?ebofreetotal";
        protected const string Paramebofreecoupon = "?ebofreecoupon";
        protected const string Paramebobusytotal = "?ebobusytotal";
        protected const string Paramebobusycoupon = "?ebobusycoupon";
        protected const string Paramebofreetemptotal = "?ebofreetemptotal";
        protected const string Paramebofreetempcoupon = "?ebofreetempcoupon";
        protected const string Paramebobusytemptotal = "?ebobusytemptotal";
        protected const string Paramebobusytempcoupon = "?ebobusytempcoupon";
        protected const string Paramlocalfreetotal = "?localfreetotal";
        protected const string Paramlocalfreecoupon = "?localfreecoupon";
        protected const string Paramlocalbusytotal = "?localbusytotal";
        protected const string Paramlocalbusycoupon = "?localbusycoupon";
        protected const string Paramlocalfreetemptotal = "?localfreetemptotal";
        protected const string Paramlocalfreetempcoupon = "?localfreetempcoupon";
        protected const string Paramlocalbusytemptotal = "?localbusytemptotal";
        protected const string Paramlocalbusytempcoupon = "?localbusytempcoupon";
        protected const string Paramparkfee = "?parkfee";
        protected const string Parammonthfee = "?monthfee";
        protected const string Paramfreefee = "?freefee";
        protected const string Parambusyfee = "?busyfee";
        protected const string Paramoverfreefee = "?overfreefee";
        protected const string Paramoverbusyfee = "?overbusyfee";
        protected const string Parambalancemoney = "?balancemoney";
        protected const string Paramstarttime = "?starttime";
        protected const string Paramendtime = "?endtime";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParksettlementDb</returns>
        public static List<ParksettlementDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parksettlement">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParksettlementDb parksettlement)
        {
            var param= GetInsertParams(parksettlement);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>ParksettlementDb</returns>
        public static ParksettlementDb  GetByPriKey(string id)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramid,id)
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
        /// <param name="parksettlement">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ParksettlementDb parksettlement)
        {
            var param= GetUpdateParams(parksettlement);
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
        public static bool  DeleteByPriKey(string id)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramid,id)
                };

            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlDeleteByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 获取更新参数
        public static MySqlParameter[]  GetUpdateParams(ParksettlementDb parksettlement)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramid,parksettlement.Id),
                    new MySqlParameter(Paramparkcode,parksettlement.Parkcode),
                    new MySqlParameter(Paramebotemptotal,parksettlement.Ebotemptotal),
                    new MySqlParameter(Paramebotempcoupon,parksettlement.Ebotempcoupon),
                    new MySqlParameter(Paramebomonthtotal,parksettlement.Ebomonthtotal),
                    new MySqlParameter(Paramebomonthcoupon,parksettlement.Ebomonthcoupon),
                    new MySqlParameter(Paramebofreetotal,parksettlement.Ebofreetotal),
                    new MySqlParameter(Paramebofreecoupon,parksettlement.Ebofreecoupon),
                    new MySqlParameter(Paramebobusytotal,parksettlement.Ebobusytotal),
                    new MySqlParameter(Paramebobusycoupon,parksettlement.Ebobusycoupon),
                    new MySqlParameter(Paramebofreetemptotal,parksettlement.Ebofreetemptotal),
                    new MySqlParameter(Paramebofreetempcoupon,parksettlement.Ebofreetempcoupon),
                    new MySqlParameter(Paramebobusytemptotal,parksettlement.Ebobusytemptotal),
                    new MySqlParameter(Paramebobusytempcoupon,parksettlement.Ebobusytempcoupon),
                    new MySqlParameter(Paramlocalfreetotal,parksettlement.Localfreetotal),
                    new MySqlParameter(Paramlocalfreecoupon,parksettlement.Localfreecoupon),
                    new MySqlParameter(Paramlocalbusytotal,parksettlement.Localbusytotal),
                    new MySqlParameter(Paramlocalbusycoupon,parksettlement.Localbusycoupon),
                    new MySqlParameter(Paramlocalfreetemptotal,parksettlement.Localfreetemptotal),
                    new MySqlParameter(Paramlocalfreetempcoupon,parksettlement.Localfreetempcoupon),
                    new MySqlParameter(Paramlocalbusytemptotal,parksettlement.Localbusytemptotal),
                    new MySqlParameter(Paramlocalbusytempcoupon,parksettlement.Localbusytempcoupon),
                    new MySqlParameter(Paramparkfee,parksettlement.Parkfee),
                    new MySqlParameter(Parammonthfee,parksettlement.Monthfee),
                    new MySqlParameter(Paramfreefee,parksettlement.Freefee),
                    new MySqlParameter(Parambusyfee,parksettlement.Busyfee),
                    new MySqlParameter(Paramoverfreefee,parksettlement.Overfreefee),
                    new MySqlParameter(Paramoverbusyfee,parksettlement.Overbusyfee),
                    new MySqlParameter(Parambalancemoney,parksettlement.Balancemoney),
                    new MySqlParameter(Paramstarttime,parksettlement.Starttime),
                    new MySqlParameter(Paramendtime,parksettlement.Endtime)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParksettlementDb parksettlement)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramid,parksettlement.Id),
                    new MySqlParameter(Paramparkcode,parksettlement.Parkcode),
                    new MySqlParameter(Paramebotemptotal,parksettlement.Ebotemptotal),
                    new MySqlParameter(Paramebotempcoupon,parksettlement.Ebotempcoupon),
                    new MySqlParameter(Paramebomonthtotal,parksettlement.Ebomonthtotal),
                    new MySqlParameter(Paramebomonthcoupon,parksettlement.Ebomonthcoupon),
                    new MySqlParameter(Paramebofreetotal,parksettlement.Ebofreetotal),
                    new MySqlParameter(Paramebofreecoupon,parksettlement.Ebofreecoupon),
                    new MySqlParameter(Paramebobusytotal,parksettlement.Ebobusytotal),
                    new MySqlParameter(Paramebobusycoupon,parksettlement.Ebobusycoupon),
                    new MySqlParameter(Paramebofreetemptotal,parksettlement.Ebofreetemptotal),
                    new MySqlParameter(Paramebofreetempcoupon,parksettlement.Ebofreetempcoupon),
                    new MySqlParameter(Paramebobusytemptotal,parksettlement.Ebobusytemptotal),
                    new MySqlParameter(Paramebobusytempcoupon,parksettlement.Ebobusytempcoupon),
                    new MySqlParameter(Paramlocalfreetotal,parksettlement.Localfreetotal),
                    new MySqlParameter(Paramlocalfreecoupon,parksettlement.Localfreecoupon),
                    new MySqlParameter(Paramlocalbusytotal,parksettlement.Localbusytotal),
                    new MySqlParameter(Paramlocalbusycoupon,parksettlement.Localbusycoupon),
                    new MySqlParameter(Paramlocalfreetemptotal,parksettlement.Localfreetemptotal),
                    new MySqlParameter(Paramlocalfreetempcoupon,parksettlement.Localfreetempcoupon),
                    new MySqlParameter(Paramlocalbusytemptotal,parksettlement.Localbusytemptotal),
                    new MySqlParameter(Paramlocalbusytempcoupon,parksettlement.Localbusytempcoupon),
                    new MySqlParameter(Paramparkfee,parksettlement.Parkfee),
                    new MySqlParameter(Parammonthfee,parksettlement.Monthfee),
                    new MySqlParameter(Paramfreefee,parksettlement.Freefee),
                    new MySqlParameter(Parambusyfee,parksettlement.Busyfee),
                    new MySqlParameter(Paramoverfreefee,parksettlement.Overfreefee),
                    new MySqlParameter(Paramoverbusyfee,parksettlement.Overbusyfee),
                    new MySqlParameter(Parambalancemoney,parksettlement.Balancemoney),
                    new MySqlParameter(Paramstarttime,parksettlement.Starttime),
                    new MySqlParameter(Paramendtime,parksettlement.Endtime)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParksettlementDb</returns>
        public static ParksettlementDb  ConvertToObject(DataRow dr)
        {
            var data = new ParksettlementDb
                {
                    Id = DbChange.ToString(dr["id"]),
                    Parkcode = DbChange.ToString(dr["parkcode"]),
                    Ebotemptotal = DbChange.ToDecimal(dr["ebotemptotal"],0),
                    Ebotempcoupon = DbChange.ToDecimal(dr["ebotempcoupon"],0),
                    Ebomonthtotal = DbChange.ToDecimal(dr["ebomonthtotal"],0),
                    Ebomonthcoupon = DbChange.ToDecimal(dr["ebomonthcoupon"],0),
                    Ebofreetotal = DbChange.ToDecimal(dr["ebofreetotal"],0),
                    Ebofreecoupon = DbChange.ToDecimal(dr["ebofreecoupon"],0),
                    Ebobusytotal = DbChange.ToDecimal(dr["ebobusytotal"],0),
                    Ebobusycoupon = DbChange.ToDecimal(dr["ebobusycoupon"],0),
                    Ebofreetemptotal = DbChange.ToDecimal(dr["ebofreetemptotal"],0),
                    Ebofreetempcoupon = DbChange.ToDecimal(dr["ebofreetempcoupon"],0),
                    Ebobusytemptotal = DbChange.ToDecimal(dr["ebobusytemptotal"],0),
                    Ebobusytempcoupon = DbChange.ToDecimal(dr["ebobusytempcoupon"],0),
                    Localfreetotal = DbChange.ToDecimal(dr["localfreetotal"],0),
                    Localfreecoupon = DbChange.ToDecimal(dr["localfreecoupon"],0),
                    Localbusytotal = DbChange.ToDecimal(dr["localbusytotal"],0),
                    Localbusycoupon = DbChange.ToDecimal(dr["localbusycoupon"],0),
                    Localfreetemptotal = DbChange.ToDecimal(dr["localfreetemptotal"],0),
                    Localfreetempcoupon = DbChange.ToDecimal(dr["localfreetempcoupon"],0),
                    Localbusytemptotal = DbChange.ToDecimal(dr["localbusytemptotal"],0),
                    Localbusytempcoupon = DbChange.ToDecimal(dr["localbusytempcoupon"],0),
                    Parkfee = DbChange.ToDecimal(dr["parkfee"],0),
                    Monthfee = DbChange.ToDecimal(dr["monthfee"],0),
                    Freefee = DbChange.ToDecimal(dr["freefee"],0),
                    Busyfee = DbChange.ToDecimal(dr["busyfee"],0),
                    Overfreefee = DbChange.ToDecimal(dr["overfreefee"],0),
                    Overbusyfee = DbChange.ToDecimal(dr["overbusyfee"],0),
                    Balancemoney = DbChange.ToDecimal(dr["balancemoney"],0),
                    Starttime = DbChange.ToDateTime(dr["starttime"],DateTime.MinValue),
                    Endtime = DbChange.ToDateTime(dr["endtime"],DateTime.MinValue)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ParksettlementDb</returns>
        public static List<ParksettlementDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParksettlementDb>(); 
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
