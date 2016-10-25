using System;
using OneCoin.Service.Api.Controllers.PayPlatform;
using OneCoin.Service.Api.Controllers.Payment;
using OneCoin.Service.Bll.Logic.Orders;
using OneCoin.Service.Bll.Logic.Payment;
using OneCoin.Service.Cache.Car;
using OneCoin.Service.Model.Dto.Request.Payment;
using OneCoin.Service.Model.Entity.Payment;
using OneCoin.Service.Model.Enum.Payment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OneCoin.Service.UTester.Orders
{
    /// <summary>
    /// Summary description for PaymentTest
    /// </summary>
    [TestClass]
    public class PaymentTest  : TestBase
    {
        public PaymentTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void ResGetProStopDtoTest()
        {
            var ret1 = PaymentBll.GetProStopFroWx("omHabuBu1EJHzhMbsU1oX5TiV-pY");
            Print(ret1);


            var cc = new PaymentController();
            var ret = cc.GetProStop(new ReqGetProStopDto
                {
                    CarNo = "川A00006",
                    PartnerId = "pengruili"
                });


            var r = new PurchaseReq
                {
                    ActivityId = "",
                    CarNo = "川A00006",
                    ClientIp = "",
                    ClientType = 1,
                    CouponId = "",
                    CouponMoney = 0,
                    DeduId = "",
                    DeduMoney = 0, 
                    Description = "",
                    EntranceTime = DateTime.Now.AddHours(-10),
                    ExitTime = DateTime.Now,
                    ErrMsg = "",
                    PaymentType = PaymentType.AliPay,
                    Purpose = PaymentPurpose.支付停车费,
                    SubPurpose = PaymentSubPurpose.支付停车费,
                };

            var cacheData = CarCacheMgr.GetProStopInfo("川A00006");
            if (cacheData != null)
            {
                r.TotalMoney = (decimal)cacheData.Money;
                r.PartnerId = cacheData.PartnerId;
            }

            OrdersBll.GetProStopOrder(r);


            var ret2 = CarCacheMgr.GetProStopInfo(TestConfig.VehicleNo);

            //var ret= new ClientResult(ResultDto.DefaultSuccess(new ResGetMoneyForMonthlyFeeDto
            //{
            //    Money = 10,
            //    ParkCode ="1111",
            //    ParkName = "环球中心",
            //    RenewalMonths = 3,
            //    TillDate = DateTime.Now.ToFormat(),
            //    VehicleNo = "川A01223"
            //}));

            Print(ret);
        }


        [TestMethod]
        public void GetMoneyForMonthlyFee()
        {
            var cc = new PaymentController();
            var ret = cc.GetMoneyForMonthlyFee(new ReqGetMoneyForMonthlyFeeDto
                {
                    carno = TestConfig.VehicleNo,
                    parkcode = "55555555",
                    renewalmonths = 1,
                    tilldate = DateTime.Now
                });

            Print(ret);
        }


        [TestMethod]
        public void WexinCallBackTest()
        {
            var cc = new PayPlatformController();
            var ret = cc.WexinCallBack();

            Print(ret);
        }
        
        [TestMethod]
        public void GetMoneyForMonthlyRenewTest()
        {
            var cc = new PaymentController();
            var ret = cc.GetMoneyForMonthlyRenew(new ReqGetMoneyForMonthlyFeeDto
                {
                    carno = "川BWWWWW",
                    parkcode = "000001",
                    renewalmonths = 1,
                    SaleId = "000001$3",
                    tilldate = DateTime.Now
                });

            Print(ret);
        }
        
        
    }
}
