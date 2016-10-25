using System;
using OneCoin.Service.Api.Controllers.Thirdparty;
using OneCoin.Service.Api.Core.Result;
using OneCoin.Service.Model.Dto.Request.Subscribe;
using OneCoin.Service.Model.Dto.Response.PartnerService;
using OneCoin.Service.Model.Result;
using OneCoin.Service.TrdPart.Partner.TianHong.Api.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OneCoin.Service.UTester.TrdPart
{
    [TestClass]
    public class PartnerServiceTest : TestBase
    {
        private const string ParkCode = "66666666";
        private const string CarNo = "川A58585";

        [TestMethod]
        public void GetProStopTest()
        {

            var c = new PartnerServiceController();
            var r =c.GetProStop(new ReqGetProStopDto
                {
                    CarNo = CarNo,
                });

            Print(r);

            var ret = r as ClientResult;
            if (ret != null)
            {
                var data = ret.Data as ResultDto;
                if (data != null)
                {
                    if (data.IsSuccess)
                    {
                        var carPayInfo = data.Result as Model.Dto.Response.Subscribe.ResGetProStopDto;

                        if (carPayInfo != null)
                        {
                             r=c.PaySync(new ReqPaySyncDto
                                {
                                    CarNo = CarNo,
                                    ConAmount = carPayInfo.ConAmount,
                                    ClientIp = "127.0.0.1",
                                    EnterTime = DateTime.Parse(carPayInfo.EnterTime),
                                    ExitTime = DateTime.Parse(carPayInfo.ExitTime),
                                    MerchantUrl = "",
                                    ParkCode = ParkCode,
                                    Qn = DateTime.Now.Ticks.ToString(),
                                    totalmoney = (decimal)carPayInfo.ConAmount
                                });

                             Print(r);
                        }
                    }
                }
            }

        }


        [TestMethod]
        public void GetImage()
        {

            var c = new PartnerServiceController();
            var r = c.CarImage(new ReqCarImageDto
                {
                    ImageId = "9089",
                    ParkCode = ParkCode
                });

            Print(r);
        }

        [TestMethod]
        public void WhiteList()
        {
            var r=TianHongApi.CarList("66666666", DateTime.Now);
            
            Print(r);
        }
    }
}
