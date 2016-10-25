using Lpn.Service.Cache.Partner;
using Lpn.Service.Helper.Encrypt;
using Lpn.Service.Helper.Http;
using Lpn.Service.Helper.Log;
using Lpn.Service.Helper.Serialization;

namespace Lpn.Service.TrdPart.Partner.TianHong.Api.Core
{
    public class ApiBase 
    {

        protected static T RemoteQuery<T>(string method, object param)
        {
            var postString = SimpleSerialization.ObjectToJson(param);
            var signSource = string.Format("{0}{1}", postString, PartnerCacheMgr.GetKey(ConfigDef.PartnerId));
            var sign = EncryptMgr.MD5(signSource);

            var client = new HttpClient
                {
                    Url = string.Format("{0}{1}?sign={2}", ConfigDef.ApiServer, method, sign),
                    PostString = postString,
                    ContentType = "application/json"
                };

            var ret= client.GetString();

            LogHelper.Add(string.Format("天虹上报Query：{0}==>{1}=>{2}", client.Url, client.PostString, ret));
 
            if (!string.IsNullOrEmpty(ret))
            {
                return SimpleSerialization.JsonToObject<T>(ret);
            }

            return default(T);
        }

    }
}
