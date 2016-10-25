using System;
using System.IO.Compression;
using System.Text;
using System.Web;
using System.Web.Mvc;
using OneCoin.Service.Helper.Log;

/*
 * 描述: 接口返回对象类 ,纯文字版本
 * 作者:lee
 * 创建时间:2015/10/21
 */


namespace OneCoin.Service.Api.Core.Result
{
    public class TextResult : JsonResult
    {
        private bool _isEnableGzip = false;
        #region 构造函数

        /// <summary>
        /// 返回对象
        /// </summary>
        /// <param name="result">对象</param>
        /// <param name="isEnableGzip"></param>
        public TextResult(string result,bool isEnableGzip)
        {
            Data = result;
            _isEnableGzip = isEnableGzip;
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

#if DEBUG 
            // 请求日志 
            LogHelper.Add(string.Format("\r\n返回:{0}", Data));
#endif 
            if (_isEnableGzip)
            {
                //gzip压缩  
                response.Filter = new GZipStream(response.Filter, CompressionMode.Compress);
                response.Headers.Remove("Content-Encoding");
                response.AppendHeader("Content-Encoding", "gzip");
            }
             
            response.Write(Data.ToString());
        }

    }
}