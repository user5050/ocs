using OneCoin.Service.Api.Controllers.Banner;
using OneCoin.Service.Api.Core.Result;
using OneCoin.Service.Model.Dto.Request.Banner;
using OneCoin.Service.Model.Result;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OneCoin.Service.UTester.Antithief
{
     [TestClass]
    public class SysBannerTest : TestBase
    {
         private BannerController controler = new BannerController();

         [TestMethod]
         public void GetBanner()
         {
             ReqGetDto rdata = new ReqGetDto();
             rdata.Sign = "";
             ClientResult result = controler.Get(rdata) as ClientResult;
             var data = result.Data as ResultDto;
             Assert.IsTrue(data.State == 0, "获取Banner失败");
             Print(data);
         }

         [TestMethod]
         public void GetBannerNew()
         {
             ReqGetDto rdata = new ReqGetDto();
             rdata.Sign = "";
             //成都
             rdata.Lat = "30.67";
             rdata.Lng = "104.06";

             //重庆
             //rdata.Lat = "29.5";
             //rdata.Lng = "106.5";

             //西安 108.95000,34.26667
             //rdata.Lat = "34.26667";
             //rdata.Lng = "108.95";

             ClientResult result = controler.Get(rdata) as ClientResult;
             var data = result.Data as ResultDto;
             Assert.IsTrue(data.State == 0, "获取Banner失败");
             Print(data);
         }
    }
}
