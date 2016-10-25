using System;
using System.Globalization;
using OneCoin.Service.Model.Config;

namespace OneCoin.Service.Model.Extension.Dto
{
    public static class CommExtension
    {

        /// <summary>
        /// 时间返回给客户端字符串
        /// </summary>
        /// <param name="date">时间</param>
        /// <returns></returns>
        public static string ToFormat(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }


        /// <summary>
        /// 时间返回给客户端字符串
        /// </summary>
        /// <param name="date">时间</param>
        /// <returns></returns>
        public static string ToFormat(this string date)
        {
            DateTime dt;
            if (DateTime.TryParse(date, out dt))
            {
                return dt.ToFormat();
            }

            return date;
        }

        /// <summary>
        /// 时间返回给客户端字符串
        /// </summary>
        /// <param name="date">时间</param>
        /// <returns></returns>
        public static string ToDateFormat(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        public static string ToDateFormatChina(this DateTime date)
        {
            return date.ToString("MM月dd日");
        }

        /// <summary>
        /// 返回云存储完整的访问地址
        /// </summary>
        /// <param name="storeKey">云存储资源Key</param>
        /// <returns></returns>
        public static string ToFullUrl(this string storeKey)
        {
            if (string.IsNullOrEmpty(storeKey)) return storeKey;
            if (storeKey.StartsWith("http", true, CultureInfo.CurrentCulture)) return storeKey;
 
            return string.Format("{0}/{1}", WebConfig.ResourceDomain, storeKey);
        }


        /// <summary>
        /// 时间返回给客户端字符串
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static string Tstr(this object data)
        {
            return data == null ? string.Empty : data.ToString();
        }


        /// <summary>
        /// 时间返回给客户端字符串
        /// </summary>
        /// <param name="orderNo">时间</param>
        /// <param name="enableMask">是否遮掩部分</param>
        /// <returns></returns>
        public static string ToOrderSubPart(this string orderNo,bool enableMask)
        {
            if (string.IsNullOrEmpty(orderNo)) return string.Empty;

            if (orderNo.Length <= 12) return string.Empty;

            var subOrder = orderNo.Substring(orderNo.Length - 12, 12);

            subOrder= subOrder.Insert(8, "-");
            subOrder= subOrder.Insert(4, "-");

            return enableMask ? string.Format("{0}***{1}",subOrder.Substring(0,1), subOrder.Substring(4, 10)) : subOrder;
        }
    }
}
