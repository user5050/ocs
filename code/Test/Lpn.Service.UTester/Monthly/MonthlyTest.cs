using System;
using OneCoin.Library.Service.Park.Model.platform.Request;
using OneCoin.Service.Api.Controllers.Monthly;
using OneCoin.Service.Api.Core.Result;
using OneCoin.Service.Bll.HttpTw;
using OneCoin.Service.Bll.Logic.Monthly;
using OneCoin.Service.Model.Dto.Request.Monthly;
using OneCoin.Service.Model.Extension.Dto;
using OneCoin.Service.Model.Result;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OneCoin.Service.UTester.Monthly
{
     [TestClass]
    public class MonthlyTest:TestBase
    {
         private MonthlyController controler = new MonthlyController();

        [TestMethod]
        public void GetMonthlyCars()
        {
            ClientResult result = controler.GetMonthlyCars() as ClientResult;
            var data = result.Data as ResultDto;
            Assert.IsTrue(data.State == 0, "获取月租数据失败");
            Print(data);
        }


        [TestMethod]
        public void GetMonthlyInfoByCarNoTest()
        {
            ClientResult result = controler.GetMonthlyInfoByCarNo(new ReqGetMonthlyInfoByCarNoDto
                {
                    CarNo = "川BWWWWW"
                }) as ClientResult;
            var data = result.Data as ResultDto;
            Assert.IsTrue(data.State == 0, "获取指定车牌月租信息失败");
            Print(data);
        }


        [TestMethod]
        public void AddMonthlyCarViaApp()
        {
            ReqAddMonthlyCarViaAppDto rdata = new ReqAddMonthlyCarViaAppDto();
            rdata.CarNo = "川A63256";
            rdata.UserID = 59;
            rdata.OperationType = 2;
            rdata.ParkCode = "55555555";
            ClientResult result = controler.AddMonthlyCarViaApp(rdata) as ClientResult;
            var data = result.Data as ResultDto;
            Assert.IsTrue(data.State == 0, "管理本地月租数据失败");
            Print(data);
        }


        [TestMethod]
        public void GetMonthlyTimeForSaleTest()
        {
            var result = controler.GetMonthlyTimeForSale(new ReqGetMonthlyTimeForSaleDto(){Skip = 0,Take = 10}) as ClientResult;
            var data = result.Data as ResultDto;
            Assert.IsTrue(data.State == 0, "获取月租数据失败");
            Print(data);
        }


        [TestMethod]
        public void GetMonthlyTimeForSaleDetailTest()
        {
            var result = controler.GetMonthlyTimeDetail(new ReqGetMonthlyTimeDetailDto() { SaleId = "90001$3" }) as ClientResult;
            var data = result.Data as ResultDto;
            Assert.IsTrue(data.State == 0, "获取月租数据失败");
            Print(data);
        }


        [TestMethod]
        public void BuyMonthlyTimeForSale()
        {
            var fee = new MonthlyTimeFee
            {
                AllMoney = 200,
                ParkCode = "66666666",
                PayMoney = 200,
                RenewalMonths =1,
                TillDate = DateTime.Now.ToFormat(),
                VehicleNo = "川A123BC,川A123BA",
                OrderNo = "15121015370467678544000000222008",
                MonthlySort = 4,
                UserName = "13096306665"
            };

            // 通知停车场
            var notifyParkRet = HttpTwMgr.MonthlyTimeFee(fee);
            Print(notifyParkRet);
        }


        [TestMethod]
        public void MonthlyTimeFeeCarCheck()
        {
            var fee = new MonthlyTimeFeeCarCheck
            {
                CarNo = "川A00000"
            };

            // 通知停车场
            var notifyParkRet = HttpTwMgr.MonthlyTimeFeeCarCheck("66666666",fee);
            Print(notifyParkRet);
        }
        
         [TestMethod]
        public void GetMonthlyTimeForSaleV2HomeTest()
         {
             var fee = new MonthlyController();
             var ret= fee.GetMonthlyTimeForSaleV2Home(new ReqGetMonthlyTimeForSaleDto
                 {
                     City = "",
                     Lat = "31",
                     Lng = "104",
                     Skip = 0,
                     Take = 10
                 });
              
             Print(ret);
        }


         [TestMethod]
         public void IsMonthlyCarBindMobileTest()
         {
             var ret = MonthlyCarInfoBll.IsMonthlyCarBindMobile(123, "川A11111", "000001");

             Print(ret);
         }
        
    }
}
