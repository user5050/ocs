using System.Net;
using System.Text;
using System.Web;
using Lpn.Proxy.BoBo.Api.Model.Request;
using Lpn.Service.Helper.Http;
using Lpn.Service.Helper.Log;
using Newtonsoft.Json;

namespace Lpn.Proxy.BoBo.Api
{
    public class BaseProxy
    {
#if DEBUG
        //测试
        private const string BaseUrl = "http://app-2.parkbobo.com/";
#else
        //生产环境
        private const string BaseUrl = "http://app1.parkbobo.com/";
#endif

        public static string Query(string method, ReqDto req)
        {
            if (req == null) return string.Empty;
            if (req.head == null)
            {
                req.head = new ReqHeadDto
                    {
                        key = "weibokeji",
                        partner = "parkbobo",
                        mdkey = "a9ece8a79e0c6bac83e3f75566443f9e"
                    };
            }

            var json = JsonConvert.SerializeObject(req);
            var hc = new HttpClient
                {
                    ContentType = "application/x-www-form-urlencoded",
                    Url = string.Format("{0}{1}", BaseUrl, method)
                };

            hc.PostingData.Add("request", HttpUtility.UrlEncode(json));

            var ret= hc.GetString();


            LogHelper.Add( string.Format("BoBo.Api {0}\r\n{1}", json,ret));

            return ret;
        }
    }
}
