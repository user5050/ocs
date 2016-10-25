using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Lpn.Service.Dal.Utility;
using Lpn.Service.Dal.Core;
using Lpn.Service.Model.Db.Park;

/*
* 由自动生成工具完成
* 描述:[park_balance_detail]停车场结算详细信息 Dal帮助类
* 作者:lee
* 创建时间:2016/10/24
*/
namespace Lpn.Service.Dal.Dal.Park
{
    /// <summary>
    /// [park_balance_detail]停车场结算详细信息 Dal帮助类
    /// </summary>
    [Serializable]
    public partial class ParkBalanceDetailDal : DalBase
    {
        #region SQL
        //获取整个表数据
        protected const string SqlGetAll = "select * from parkbalance_detail;";
        //新增插入语句
        protected const string SqlInsert = "insert into parkbalance_detail(`id`,`parkbalance_id`,`ebotemptotal`,`ebotempcoupon`,`ebomonthtotal`,`ebomonthcoupon`,`ebofreetotal`,`ebofreecoupon`,`ebobusytotal`,`ebobusycoupon`,`ebofreetemptotal`,`ebofreetempcoupon`,`ebobusytemptotal`,`ebobusytempcoupon`,`localfreetotal`,`localfreecoupon`,`localbusytotal`,`localbusycoupon`,`localfreetemptotal`,`localfreetempcoupon`,`localbusytemptotal`,`localbusytempcoupon`,`parkfee`,`monthfee`,`freefee`,`busyfee`,`overfreefee`,`overbusyfee`,`balancemoney`,`starttime`,`endtime`,`activitycount`,`activityprice`,`activitytimededu`,`localmembertotal`,`ebomembertotal`,`memberfee`) values(?id,?parkbalance_id,?ebotemptotal,?ebotempcoupon,?ebomonthtotal,?ebomonthcoupon,?ebofreetotal,?ebofreecoupon,?ebobusytotal,?ebobusycoupon,?ebofreetemptotal,?ebofreetempcoupon,?ebobusytemptotal,?ebobusytempcoupon,?localfreetotal,?localfreecoupon,?localbusytotal,?localbusycoupon,?localfreetemptotal,?localfreetempcoupon,?localbusytemptotal,?localbusytempcoupon,?parkfee,?monthfee,?freefee,?busyfee,?overfreefee,?overbusyfee,?balancemoney,?starttime,?endtime,?activitycount,?activityprice,?activitytimededu,?localmembertotal,?ebomembertotal,?memberfee);";
        //获取根据主键查询
        protected const string SqlGetByPriKey = "select * from parkbalance_detail where `id`=?id;";
        //根据主键更新整行数据
        protected const string SqlUpdateByPriKey = "update parkbalance_detail set `parkbalance_id`=?parkbalance_id,`ebotemptotal`=?ebotemptotal,`ebotempcoupon`=?ebotempcoupon,`ebomonthtotal`=?ebomonthtotal,`ebomonthcoupon`=?ebomonthcoupon,`ebofreetotal`=?ebofreetotal,`ebofreecoupon`=?ebofreecoupon,`ebobusytotal`=?ebobusytotal,`ebobusycoupon`=?ebobusycoupon,`ebofreetemptotal`=?ebofreetemptotal,`ebofreetempcoupon`=?ebofreetempcoupon,`ebobusytemptotal`=?ebobusytemptotal,`ebobusytempcoupon`=?ebobusytempcoupon,`localfreetotal`=?localfreetotal,`localfreecoupon`=?localfreecoupon,`localbusytotal`=?localbusytotal,`localbusycoupon`=?localbusycoupon,`localfreetemptotal`=?localfreetemptotal,`localfreetempcoupon`=?localfreetempcoupon,`localbusytemptotal`=?localbusytemptotal,`localbusytempcoupon`=?localbusytempcoupon,`parkfee`=?parkfee,`monthfee`=?monthfee,`freefee`=?freefee,`busyfee`=?busyfee,`overfreefee`=?overfreefee,`overbusyfee`=?overbusyfee,`balancemoney`=?balancemoney,`starttime`=?starttime,`endtime`=?endtime,`activitycount`=?activitycount,`activityprice`=?activityprice,`activitytimededu`=?activitytimededu,`localmembertotal`=?localmembertotal,`ebomembertotal`=?ebomembertotal,`memberfee`=?memberfee where `id`=?id;";
        //根据主键更新整行数据
        protected const string SqlDeleteByPriKey = "delete from parkbalance_detail  where `id`=?id;";
        #endregion

        #region 参数
        protected const string Paramid = "?id";
        protected const string Paramparkbalance_id = "?parkbalance_id";
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
        protected const string Paramactivitycount = "?activitycount";
        protected const string Paramactivityprice = "?activityprice";
        protected const string Paramactivitytimededu = "?activitytimededu";
        protected const string Paramlocalmembertotal = "?localmembertotal";
        protected const string Paramebomembertotal = "?ebomembertotal";
        protected const string Parammemberfee = "?memberfee";
        #endregion

        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ParkBalanceDetailDb</returns>
        public static List<ParkBalanceDetailDb>  GetAll()
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetAll);

            return ConvertToObjects(dr);
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="parkbalancedetail">新增对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  Insert(ParkBalanceDetailDb parkbalancedetail)
        {
            var param= GetInsertParams(parkbalancedetail);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlInsert, param);

            return result > 0;
        }
        #endregion

        #region 获取主键查询数据
        /// <summary>
        /// 获取主键查询数据
        /// </summary>
        /// <param name="id">标识</param> 
        /// <returns>ParkBalanceDetailDb</returns>
        public static ParkBalanceDetailDb  GetByPriKey(string id)
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
        /// <param name="parkbalancedetail">更新对象</param> 
        /// <returns>bool(true or false)</returns>
        public static bool  UpdateByPriKey(ParkBalanceDetailDb parkbalancedetail)
        {
            var param= GetUpdateParams(parkbalancedetail);
            var result = DbHelper.ExecuteNonQuery(ConntionStr, SqlUpdateByPriKey, param);

            return result > 0;
        }
        #endregion

        #region 根据主键删除表数据
        /// <summary>
        /// 根据主键删除表数据
        /// </summary>
        /// <param name="id">标识</param> 
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
        public static MySqlParameter[]  GetUpdateParams(ParkBalanceDetailDb parkbalancedetail)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramid,parkbalancedetail.Id),
                    new MySqlParameter(Paramparkbalance_id,parkbalancedetail.Parkbalance_id),
                    new MySqlParameter(Paramebotemptotal,parkbalancedetail.Ebotemptotal),
                    new MySqlParameter(Paramebotempcoupon,parkbalancedetail.Ebotempcoupon),
                    new MySqlParameter(Paramebomonthtotal,parkbalancedetail.Ebomonthtotal),
                    new MySqlParameter(Paramebomonthcoupon,parkbalancedetail.Ebomonthcoupon),
                    new MySqlParameter(Paramebofreetotal,parkbalancedetail.Ebofreetotal),
                    new MySqlParameter(Paramebofreecoupon,parkbalancedetail.Ebofreecoupon),
                    new MySqlParameter(Paramebobusytotal,parkbalancedetail.Ebobusytotal),
                    new MySqlParameter(Paramebobusycoupon,parkbalancedetail.Ebobusycoupon),
                    new MySqlParameter(Paramebofreetemptotal,parkbalancedetail.Ebofreetemptotal),
                    new MySqlParameter(Paramebofreetempcoupon,parkbalancedetail.Ebofreetempcoupon),
                    new MySqlParameter(Paramebobusytemptotal,parkbalancedetail.Ebobusytemptotal),
                    new MySqlParameter(Paramebobusytempcoupon,parkbalancedetail.Ebobusytempcoupon),
                    new MySqlParameter(Paramlocalfreetotal,parkbalancedetail.Localfreetotal),
                    new MySqlParameter(Paramlocalfreecoupon,parkbalancedetail.Localfreecoupon),
                    new MySqlParameter(Paramlocalbusytotal,parkbalancedetail.Localbusytotal),
                    new MySqlParameter(Paramlocalbusycoupon,parkbalancedetail.Localbusycoupon),
                    new MySqlParameter(Paramlocalfreetemptotal,parkbalancedetail.Localfreetemptotal),
                    new MySqlParameter(Paramlocalfreetempcoupon,parkbalancedetail.Localfreetempcoupon),
                    new MySqlParameter(Paramlocalbusytemptotal,parkbalancedetail.Localbusytemptotal),
                    new MySqlParameter(Paramlocalbusytempcoupon,parkbalancedetail.Localbusytempcoupon),
                    new MySqlParameter(Paramparkfee,parkbalancedetail.Parkfee),
                    new MySqlParameter(Parammonthfee,parkbalancedetail.Monthfee),
                    new MySqlParameter(Paramfreefee,parkbalancedetail.Freefee),
                    new MySqlParameter(Parambusyfee,parkbalancedetail.Busyfee),
                    new MySqlParameter(Paramoverfreefee,parkbalancedetail.Overfreefee),
                    new MySqlParameter(Paramoverbusyfee,parkbalancedetail.Overbusyfee),
                    new MySqlParameter(Parambalancemoney,parkbalancedetail.Balancemoney),
                    new MySqlParameter(Paramstarttime,parkbalancedetail.Starttime),
                    new MySqlParameter(Paramendtime,parkbalancedetail.Endtime),
                    new MySqlParameter(Paramactivitycount,parkbalancedetail.Activitycount),
                    new MySqlParameter(Paramactivityprice,parkbalancedetail.Activityprice),
                    new MySqlParameter(Paramactivitytimededu,parkbalancedetail.Activitytimededu),
                    new MySqlParameter(Paramlocalmembertotal,parkbalancedetail.Localmembertotal),
                    new MySqlParameter(Paramebomembertotal,parkbalancedetail.Ebomembertotal),
                    new MySqlParameter(Parammemberfee,parkbalancedetail.Memberfee)
                };

        return param;
        }
        #endregion

        #region 获取新增参数
        public static MySqlParameter[]  GetInsertParams(ParkBalanceDetailDb parkbalancedetail)
        {
            var param = new[]
                { 
                    new MySqlParameter(Paramid,parkbalancedetail.Id),
                    new MySqlParameter(Paramparkbalance_id,parkbalancedetail.Parkbalance_id),
                    new MySqlParameter(Paramebotemptotal,parkbalancedetail.Ebotemptotal),
                    new MySqlParameter(Paramebotempcoupon,parkbalancedetail.Ebotempcoupon),
                    new MySqlParameter(Paramebomonthtotal,parkbalancedetail.Ebomonthtotal),
                    new MySqlParameter(Paramebomonthcoupon,parkbalancedetail.Ebomonthcoupon),
                    new MySqlParameter(Paramebofreetotal,parkbalancedetail.Ebofreetotal),
                    new MySqlParameter(Paramebofreecoupon,parkbalancedetail.Ebofreecoupon),
                    new MySqlParameter(Paramebobusytotal,parkbalancedetail.Ebobusytotal),
                    new MySqlParameter(Paramebobusycoupon,parkbalancedetail.Ebobusycoupon),
                    new MySqlParameter(Paramebofreetemptotal,parkbalancedetail.Ebofreetemptotal),
                    new MySqlParameter(Paramebofreetempcoupon,parkbalancedetail.Ebofreetempcoupon),
                    new MySqlParameter(Paramebobusytemptotal,parkbalancedetail.Ebobusytemptotal),
                    new MySqlParameter(Paramebobusytempcoupon,parkbalancedetail.Ebobusytempcoupon),
                    new MySqlParameter(Paramlocalfreetotal,parkbalancedetail.Localfreetotal),
                    new MySqlParameter(Paramlocalfreecoupon,parkbalancedetail.Localfreecoupon),
                    new MySqlParameter(Paramlocalbusytotal,parkbalancedetail.Localbusytotal),
                    new MySqlParameter(Paramlocalbusycoupon,parkbalancedetail.Localbusycoupon),
                    new MySqlParameter(Paramlocalfreetemptotal,parkbalancedetail.Localfreetemptotal),
                    new MySqlParameter(Paramlocalfreetempcoupon,parkbalancedetail.Localfreetempcoupon),
                    new MySqlParameter(Paramlocalbusytemptotal,parkbalancedetail.Localbusytemptotal),
                    new MySqlParameter(Paramlocalbusytempcoupon,parkbalancedetail.Localbusytempcoupon),
                    new MySqlParameter(Paramparkfee,parkbalancedetail.Parkfee),
                    new MySqlParameter(Parammonthfee,parkbalancedetail.Monthfee),
                    new MySqlParameter(Paramfreefee,parkbalancedetail.Freefee),
                    new MySqlParameter(Parambusyfee,parkbalancedetail.Busyfee),
                    new MySqlParameter(Paramoverfreefee,parkbalancedetail.Overfreefee),
                    new MySqlParameter(Paramoverbusyfee,parkbalancedetail.Overbusyfee),
                    new MySqlParameter(Parambalancemoney,parkbalancedetail.Balancemoney),
                    new MySqlParameter(Paramstarttime,parkbalancedetail.Starttime),
                    new MySqlParameter(Paramendtime,parkbalancedetail.Endtime),
                    new MySqlParameter(Paramactivitycount,parkbalancedetail.Activitycount),
                    new MySqlParameter(Paramactivityprice,parkbalancedetail.Activityprice),
                    new MySqlParameter(Paramactivitytimededu,parkbalancedetail.Activitytimededu),
                    new MySqlParameter(Paramlocalmembertotal,parkbalancedetail.Localmembertotal),
                    new MySqlParameter(Paramebomembertotal,parkbalancedetail.Ebomembertotal),
                    new MySqlParameter(Parammemberfee,parkbalancedetail.Memberfee)
                };

        return param;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dr">DataRow数据</param>
        /// <returns>ParkBalanceDetailDb</returns>
        public static ParkBalanceDetailDb  ConvertToObject(DataRow dr)
        {
            var data = new ParkBalanceDetailDb
                {
                    Id = DbChange.ToString(dr["id"]),
                    Parkbalance_id = DbChange.ToString(dr["parkbalance_id"]),
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
                    Endtime = DbChange.ToDateTime(dr["endtime"],DateTime.MinValue),
                    Activitycount = DbChange.ToDecimal(dr["activitycount"],0),
                    Activityprice = DbChange.ToDecimal(dr["activityprice"],0),
                    Activitytimededu = DbChange.ToDecimal(dr["activitytimededu"],0),
                    Localmembertotal = DbChange.ToDecimal(dr["localmembertotal"],0),
                    Ebomembertotal = DbChange.ToDecimal(dr["ebomembertotal"],0),
                    Memberfee = DbChange.ToDecimal(dr["memberfee"],0)
                };

            return data;
        }
        #endregion

        #region 对象转换
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dt">DataTable数据</param>
        /// <returns>List of ParkBalanceDetailDb</returns>
        public static List<ParkBalanceDetailDb>  ConvertToObjects(DataTable dt)
        {
            var datas = new List<ParkBalanceDetailDb>(); 
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
