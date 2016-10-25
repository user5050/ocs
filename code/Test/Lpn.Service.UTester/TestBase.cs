using System.Diagnostics;
using System.IO;
using System.Text;
using System.Web;
using OneCoin.Service.Api.Core.Result;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace OneCoin.Service.UTester
{
    [TestClass]
    public class TestBase
    {
        [TestInitialize]
        public void Init()
        {
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://localhost", ""), new HttpResponse(new StringWriter(new StringBuilder())));

            HttpContext.Current.Items["_id"] = TestConfig.UserId;
        }


        protected void Print(object data)
        {
            var result = data as ClientResult;
            if (result != null)
            {
                var cr = result;
                Debug.Print(JsonConvert.SerializeObject(cr.Data,
                                                        new JsonSerializerSettings
                                                            {
                                                                NullValueHandling = NullValueHandling.Ignore
                                                            }));

            }
            else
            {
                Debug.Print(JsonConvert.SerializeObject(data, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
                
            }
        }
    }
}
