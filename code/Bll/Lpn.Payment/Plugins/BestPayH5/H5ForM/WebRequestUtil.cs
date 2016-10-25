using OneCoin.Service.Helper.Http;
using OneCoin.Service.Helper.Serialization;

namespace OneCoin.Payment.Plugins.BestPayH5.H5ForM
{
    public class WebRequestUtil
    {
        public static T PostAndResponse<T>(string url,object obj)
        {
            var client = new HttpClient(url) {ContentType = "application/json",
                                              PostString = SimpleSerialization.ObjectToJson(obj)
            };

            var ret = client.GetString();

            if (!string.IsNullOrEmpty(ret))
            {
                return SimpleSerialization.JsonToObject<T>(ret);
            }

            return default(T);
        }
    }
}
