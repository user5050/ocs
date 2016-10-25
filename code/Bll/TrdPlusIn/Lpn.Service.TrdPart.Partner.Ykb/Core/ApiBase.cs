using System;
using System.Net;
using System.Text;
using Lpn.Service.Helper.Http;
using Lpn.Service.Helper.Log;
using Lpn.Service.Helper.Serialization;
using Lpn.Service.TrdPart.Partner.Core.Core;

namespace Lpn.Service.TrdPart.Partner.Ykb.Core
{
    public class ApiBase : ApiCoreBase
    {
        protected static T RemoteQuery<T>(string method,string token, object param)
        {
            try
            {
                var keyValues = SimpleSerialization.ToKeyValue(param);
                var postString = new StringBuilder();

                foreach (var key in keyValues.Keys)
                {
                    postString.AppendFormat("{0}={1}&", key, WebUtility.UrlEncode(keyValues[key]));
                }

                if (postString.Length > 0) postString.Length--;

                var client = new HttpClient
                {
                    Url = string.Format("{0}{1}", ConfigDef.ApiHost, method),
                    PostString = postString.ToString(),
                    ContentType = "application/x-www-form-urlencoded"//application/json
                };

                var ret = client.GetString();

                LogHelper.Add(string.Format("优快报上报Query：{0}==>{1}=>{2}", client.Url, client.PostString, ret));

                if (!string.IsNullOrEmpty(ret))
                {
                    return SimpleSerialization.JsonToObject<T>(ret);
                }

                return default(T);
            }
            catch (Exception ex)
            {
                LogHelper.Add(string.Format("优快报上报异常：{0}", ex.Message));
            }

            return default(T);
        }

    }
}
