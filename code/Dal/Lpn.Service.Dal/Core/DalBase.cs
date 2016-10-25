/*
 * 功能：DAL层基类
 * 创建人：lee
 * 创建时间：2013-6-26
 */
using System.Configuration;

namespace OneCoin.Service.Dal.Core
{
    public class DalBase
    {
        /// <summary>
        /// 游戏数据库连接地址
        /// </summary>
        internal static readonly string DcString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        static DalBase()
        { 
        }

        protected static string  ConntionStr
        {
            get { return DcString; }
        } 
    }
}
