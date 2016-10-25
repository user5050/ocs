/*
* 由自动生成工具完成
* 描述: Dal帮助类
* 作者:lee
* 创建时间:2016/10/22
*/

using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;
using OneCoin.Service.Dal.Utility;
using OneCoin.Service.Helper.Http;
using OneCoin.Service.Model.Db.Product;
using OneCoin.Service.Model.Dto.Response.Product;
using OneCoin.Service.Model.Enum.Product;

namespace OneCoin.Service.Dal.Dal.Product
{
    /// <summary>
    ///  Dal帮助类
    /// </summary> 
    public partial class ProductInfoDal
    {
        #region SQL
        //
        protected const string SqlGetInGame = @"SELECT p.`Img`,p.`Name`,pg.`GameNo`,pg.`UserCnt`,pg.`TotalMoney` FROM product_game  pg
INNER JOIN product_info p  ON pg.`Pid`=p.`Id`  WHERE p.`State`=1  ORDER BY p.`Order` DESC
LIMIT ?Skip,?Take";


        protected const string SqlGetInGameOfProduct = @"SELECT p.`Img`,p.`Name`,pg.`GameNo`,pg.`UserCnt`,pg.`TotalMoney` FROM product_game  pg
INNER JOIN product_info p  ON pg.`Pid`=p.`Id`  WHERE pg.`State`=1  and p.`Id`=?PId  ORDER BY p.`Order` DESC
LIMIT ?Skip,?Take";

        //
        protected const string SqlGetsFormatter = "select * from product_info where id in('{0}')";


        protected const string SqlGetByState = @"SELECT p.`Img`,p.`Name`,pg.`GameNo`,pg.`UserCnt`,pg.`TotalMoney` FROM product_game  pg
INNER JOIN product_info p  ON pg.`Pid`=p.`Id`  WHERE p.`State`=?State  ORDER BY p.`Order` DESC
LIMIT ?Skip,?Take";

        /// <summary>
        /// 1进行中2揭晓中
        /// </summary>
        protected const string SqlGetByJoin = @"SELECT gm.`BuyAmount`, p.`Img`,p.`Name`,pg.`GameNo`,pg.`UserCnt`,pg.`TotalMoney` FROM game_member_stat  gm
INNER JOIN  product_game  pg  ON gm.`GameNo`= pg.`GameNo`
INNER JOIN product_info p  ON pg.`Pid`=p.`Id`
WHERE pg.`State`=1 or  pg.`State`=2  AND  gm.`UId`=?Uid  ORDER BY gm.`Id` DESC
LIMIT ?Skip,?Take";



        protected const string SqlGetLogByState = @"SELECT gm.`BuyAmount`, p.`Img`,p.`Name`,pg.`GameNo`,pg.`UserCnt`,pg.`TotalMoney` FROM game_member_stat  gm
INNER JOIN  product_game  pg  ON gm.`GameNo`= pg.`GameNo`
INNER JOIN product_info p  ON pg.`Pid`=p.`Id`
WHERE pg.`State`=?State  AND  gm.`UId`=?Uid  ORDER BY gm.`Id` DESC
LIMIT ?Skip,?Take";



        protected const string SqlGetLogOfWin = @"SELECT gm.`BuyAmount`,gm.`WinNo`, p.`Img`,p.`Name`,pg.`GameNo`,pg.`UserCnt`,pg.`TotalMoney` FROM product_game_winner  gm
INNER JOIN  product_game  pg  ON gm.`GameNo`= pg.`GameNo`
INNER JOIN product_info p  ON pg.`Pid`=p.`Id`
WHERE pg.`State`=?State  AND  gm.`UId`=?Uid  ORDER BY gm.`RowTime` DESC
LIMIT ?Skip,?Take";
        #endregion

        #region 参数
      
        protected const string ParamSkip = "?Skip";
        protected const string ParamTake = "?Take";
        protected const string ParamUid = "?Uid";
        protected const string ParamPid = "?Pid"; 

        #endregion

        public static List<ProductInfoDb> Gets(List<string> pids)
        {
            var dr = DbHelper.ExecuteDataTable(ConntionStr, string.Format(SqlGetsFormatter, Spanner.Join(pids, "','")));

            return ConvertToObjects(dr);
        }


        #region 获取整表数据
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns>List of ProductInfoDb</returns>
        public static List<ResProductInGameDto> GetInGame(int skip, int take)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamSkip,skip),
                    new MySqlParameter(ParamTake,take)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetInGame, param);

            //判断是否存在数据
            if (null != dr && dr.Rows.Count > 0)
            {
                return ConvertToResObject(dr);
            }

            return new List<ResProductInGameDto>(); 
        }


        public static ResProductInGameDto GetInGameOfProduct(string productId)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamPid,productId)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetInGameOfProduct, param);

            //判断是否存在数据
            if (null != dr && dr.Rows.Count > 0)
            {
                return ConvertToResObject(dr).FirstOrDefault();
            }

            return null;
        }


        public static List<ResProductInGameDto> GetByState(GameState state, int skip, int take)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamState,(int)state),
                    new MySqlParameter(ParamSkip,skip),
                    new MySqlParameter(ParamTake,take)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetByState, param);

            //判断是否存在数据
            if (null != dr && dr.Rows.Count > 0)
            {
                return ConvertToResObject(dr);
            }

            return new List<ResProductInGameDto>();
        }


        public static List<ResProductInGameDto> GetByJoin(string userId, int skip, int take)
        {
            var param = new[]
                {  
                    new MySqlParameter(ParamUid,userId),
                    new MySqlParameter(ParamSkip,skip),
                    new MySqlParameter(ParamTake,take)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetByJoin, param);

            //判断是否存在数据
            if (null != dr && dr.Rows.Count > 0)
            {
                return ConvertToResObject(dr);
            }

            return new List<ResProductInGameDto>();
        }


        public static List<ResProductInGameDto> GetLogByState(string userId,GameState state, int skip, int take)
        {
            var param = new[]
                { 
                    new MySqlParameter(ParamState,(int)state),
                    new MySqlParameter(ParamUid,userId),
                    new MySqlParameter(ParamSkip,skip),
                    new MySqlParameter(ParamTake,take)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetLogByState, param);

            //判断是否存在数据
            if (null != dr && dr.Rows.Count > 0)
            {
                return ConvertToResObject2(dr);
            }

            return new List<ResProductInGameDto>();
        }


        public static List<ResProductInGameDto> GetLogWin(string userId, int skip, int take)
        {
            var param = new[]
                {  
                    new MySqlParameter(ParamUid,userId),
                    new MySqlParameter(ParamSkip,skip),
                    new MySqlParameter(ParamTake,take)
                };

            var dr = DbHelper.ExecuteDataTable(ConntionStr, SqlGetLogOfWin, param);

            //判断是否存在数据
            if (null != dr && dr.Rows.Count > 0)
            {
                return ConvertToResObject3(dr);
            }

            return new List<ResProductInGameDto>();
        }

        private static List<ResProductInGameDto> ConvertToResObject(DataTable dt)
        {
            var datas = new List<ResProductInGameDto>();

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var dr = dt.Rows[i];

                datas.Add(new ResProductInGameDto
                    {
                        Name = DbChange.ToString(dr["Name"]),
                        Img = DbChange.ToString(dr["Img"]),
                        Total = DbChange.ToInt(dr["TotalMoney"], 0),
                        Cur = DbChange.ToInt(dr["UserCnt"], 0),
                        GameNo = DbChange.ToString(dr["GameNo"])
                    });
            }

            return datas;
        }

        private static List<ResProductInGameDto> ConvertToResObject2(DataTable dt)
        {
            var datas = new List<ResProductInGameDto>();

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var dr = dt.Rows[i];

                datas.Add(new ResProductInGameDto
                {
                    Name = DbChange.ToString(dr["Name"]),
                    Img = DbChange.ToString(dr["Img"]),
                    Total = DbChange.ToInt(dr["TotalMoney"], 0),
                    Cur = DbChange.ToInt(dr["UserCnt"], 0),
                    GameNo = DbChange.ToString(dr["GameNo"]),
                    BuyTotalCnt = DbChange.ToInt(dr["BuyAmount"],0)
                });
            }

            return datas;
        }


        private static List<ResProductInGameDto> ConvertToResObject3(DataTable dt)
        {
            var datas = new List<ResProductInGameDto>();

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var dr = dt.Rows[i];

                datas.Add(new ResProductInGameDto
                {
                    Name = DbChange.ToString(dr["Name"]),
                    Img = DbChange.ToString(dr["Img"]),
                    Total = DbChange.ToInt(dr["TotalMoney"], 0),
                    Cur = DbChange.ToInt(dr["UserCnt"], 0),
                    GameNo = DbChange.ToString(dr["GameNo"]),
                    WinNo = DbChange.ToString(dr["WinNo"]),
                    BuyTotalCnt = DbChange.ToInt(dr["BuyAmount"], 0)
                });
            }

            return datas;
        }
        #endregion
     }
}
