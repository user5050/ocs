using System;
using System.IO.Compression;
using System.Text;
using System.Web;
using System.Web.Mvc;
using OneCoin.Service.Helper.Log;
using OneCoin.Service.Model.Enum;
using OneCoin.Service.Model.Result;
using Newtonsoft.Json;

/*
 * 描述: 接口返回对象类 
 * 作者:lee
 * 创建时间:2015/10/21
 */

namespace OneCoin.Service.Api.Core.Result
{
    public class ClientResult : ClientResult<object>
    {
        public ClientResult(int state,  object data) :base(state,data)
        {
        }

        public ClientResult(ResultDto result)
            : base(result)
        { 
        } 
    }

    /// <summary>
    /// 接口返回对象类
    /// </summary>
    public class ClientResult<T> : JsonResult
    {
        private static readonly JsonSerializerSettings Setting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

        #region 构造函数
        /// <summary>
        /// 返回ResultDTO对象
        /// </summary>
        /// <param name="state">状态码</param>
        /// <param name="data">对象</param>
        public ClientResult(int state, T data)
        {
            Data = new ResultDto { State = state, Result = data };
        }

        /// <summary>
        /// 返回对象
        /// </summary>
        /// <param name="result">对象</param>
        public ClientResult(T result)
        {
            Data = result;
        } 
        #endregion


        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
           
            HttpResponseBase response = context.HttpContext.Response;

            if (!String.IsNullOrEmpty(ContentType))
            {
                response.ContentType = ContentType;
            }
            else
            {
                response.ContentType = "text/plain";
            }

            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }
            else
            {
                response.ContentEncoding = Encoding.UTF8;
            }

            if (Data == null)
            {
                Data = new ResultDto { State = (int)ResultState.Unknow, Result = "未知错误" };
            }

            var ret = JsonConvert.SerializeObject(Data, Setting);
  

#if DEBUG 
            // 请求日志 
            LogHelper.Add(string.Format("\r\n返回:{0}", ret));
#else
            if (!((ResultDto) Data).IsSuccess)
            {
                // 请求日志 
                LogHelper.Add(string.Format("\r\n返回:{0}", ret));
            }
#endif
            
            //gzip压缩  
            response.Filter = new GZipStream(response.Filter, CompressionMode.Compress);
            response.Headers.Remove("Content-Encoding");
            response.AppendHeader("Content-Encoding", "gzip");
 
            response.Write(ret);
        }
    }
}