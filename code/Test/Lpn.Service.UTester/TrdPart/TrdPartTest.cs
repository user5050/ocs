using System.Collections.Generic;
using OneCoin.Service.Api.Controllers.Thirdparty;
using OneCoin.Service.Bll.Logic.Activity;
using OneCoin.Service.Bll.Logic.Orders;
using OneCoin.Service.Bll.Logic.ThirdParty;
using OneCoin.Service.Bll.Logic.ThirdParty.Task;
using OneCoin.Service.Model.Dto.Request.ThirdParty;
using OneCoin.Service.TrdPart.Partner.Core.Interface.Model;
using OneCoin.Service.TrdPart.Partner.Core.Model;
using OneCoin.Service.TrdPart.Partner.XiChen;
using OneCoin.Service.TrdPart.Partner.XiChen.Model.Request;
using OneCoin.Service.TrdPart.Partner.Ykb;
using OneCoin.Service.TrdPart.Partner.Ykb.Model.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OneCoin.Service.UTester.TrdPart
{
    [TestClass]
    public class TrdPartTest : TestBase
    {
        private const string ParkCode = "000001";

        [TestMethod]
        public void MonthlyInfoSync()
        {
            var c = new PartnerActionController();
            var r =c.MonthlyInfoSync(new ReqThirdPartyMonthlySyncDto
                {
                    CarNos = new List<string> {"川A12345", "川A54321"},
                    Consume = 100,
                    Mobile = "13096333333",
                    Name = "tester",
                    ParkCode = ParkCode,
                    ParkingAmount = 1,
                    ParkingNos = new List<string> {"A001"},
                    Rate = 100,
                    RateType = 1,
                    StartTime = "2016-4-5",
                    TillTime = "2016-5-5",
                    UserToken = "2222222"
                });

            Print(r);
        }


        [TestMethod]
        public void GetMonthlyRenewal()
        {
            var c = new PartnerActionController();
            var r = c.GetMonthlyRenewal(new ReqGetRenewalDto
            {
                ParkCode = ParkCode,
                Take=10,
                Time = "2016-04-1"
            });

            Print(r);
        }


        [TestMethod]
        public void GetProStopPayment()
        {
            var c = new PartnerActionController();
            var r = c.GetProStopPayment(new ReqGetProStopPaymentDto
                {
                    ParkCode = ParkCode,
                    EntranceTime = "2016-1-1",
                    ExitTime = "2016-1-1",
                    PageIndex = 1,
                    PageSize = 10
                });

            Print(r);
        }


        [TestMethod]
        public void ThirdpartyMonthlyUploadTaskTest()
        {
            ThirdpartyMonthlyUploadTaskBll.NotifyToSync(ParkCode);
        }



        [TestMethod]
        public void YKBResGorder()
        {
            var msg = "";
            var api = new YkbApiMgr();
            var ret = api.SyncActivity(new SyncActivityDto
                {
                    brandName = "雪弗兰",
                    carNo = "川A11112",
                    carType = 1,
                    carWashId = 7279,
                    compToken = "",
                    latitude = 0,
                    longitude = 0,
                    memberPhone = "13099996666",
                    memberPrice = 15,
                    moreRequiry = "",
                    seriesName = "",
                    serviceAddr = "",
                    serviceId = "0",
                    serviceTime = "",
                    serviceType = "Wash",
                    thirdTradeNo = "160601172449888074800006431"
                }, out msg);

        }

        
        [TestMethod]
        public void XiChenApiMgrTest1()
        {
            var ret= new XiChenApiMgr().GetSpots();
            Print(ret);
            var msg = "";
        }


        [TestMethod]
        public void XiChenApiMgrTest2()
        {
            var ret = new XiChenApiMgr().GetTickets("12");
            Print(ret);
            var msg = "";
        }


        [TestMethod]
        public void XiChenApiMgrTest3()
        {
            var ticks = new XiChenApiMgr().GetTickets("151")[0];
            var preOrderNo = "";
            var msg = "";

            var ret = new XiChenApiMgr().AddOrder(new ReqAddOrderDto
                {
                    idcard = "",
                    name = "测试",
                    needmsg = 0,
                    num = 1,
                    phone = "13096306603",
                    tid = ticks.tid,
                    apiOrderId = "13096306603",
                    is_payment = "1",
                    price = "",
                    travelDates = ""
                }, out preOrderNo, out msg);

            Print(ret);
           
        }



         [TestMethod]
        public void PartnerServiceBllTest()
         {
             var orderNo = "161014102025013278100006820";
             var order = OrdersSuccesBll.GetOrders(orderNo);
              var activity = ActivityDn97Bll.GetByNo(orderNo);

             var t = PartnerServiceBll.SyncActivity(order, "13096306603", activity);
         }


        
    }
}
