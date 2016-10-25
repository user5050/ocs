using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Api.Map.Baidu.Com.Geocoder
{
    public class MapGeocoder
    {
        public static string RenderReverse(string lat, string lng)
        {
            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                return client.DownloadString(string.Format("{0}/geocoder/v2/?ak={1}&location={2},{3}&output=json&pois=1",
                                                    ConfigDefine.Api, ConfigDefine.Ak, lat, lng));
            }
        }

        public static string GetCity(string lat, string lng)
        {
            var reverse = RenderReverse(lat, lng);

            var regex = new Regex("\"city\":\"([^\"]+)\"",RegexOptions.IgnoreCase);
            var match = regex.Match(reverse);
            if (match.Success)
            {
                return match.Groups[1].ToString();
            }

            return string.Empty;
        }
    }
}
