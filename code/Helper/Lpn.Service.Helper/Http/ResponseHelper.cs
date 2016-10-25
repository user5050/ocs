using System.Web;
using OneCoin.Service.Helper.Serialization;

namespace OneCoin.Service.Helper.Http
{
    public class ResponseHelper
    {
       
        /// <summary>
        /// 获取返回给客户端加密字符串
        /// </summary>
        /// <param name="response">返回对象</param>
        /// <returns></returns>
        private static string GetString(object response)
        {
            var responseString = SimpleSerialization.ObjectToJson(response);

          
                return responseString;
            
        }

        /// <summary>
        /// 将返回对象加入输出流
        /// </summary>
        /// <param name="response">返回对象</param>
        public static void Response(object response)
        {
            Response(response);
        }

    
        /// <summary>
        /// 将返回对象加入输出流,并停止该页的执行
        /// </summary>
        /// <param name="response"></param>
        public static void ResponseAndEnd(object response)
        {
            Response(response, true);
        }

        /// <summary>
        /// 将返回对象加入输出流
        /// </summary>
        /// <param name="response">返回对象</param>
        /// <param name="isEnd">是否停止该页的执行</param>
        public static void Response(object response, bool isEnd)
        {
            var responseString = GetString(response);
            HttpContext.Current.Response.Write(responseString);
            if (isEnd)
            {
                HttpContext.Current.Response.End();
            }
        }
    }
}
