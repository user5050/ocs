using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using OneCoin.Payment;
using OneCoin.Payment.Entity;
using OneCoin.Service.Api.Controllers.Orders;
using OneCoin.Service.Bll.Logic.Activity;
using OneCoin.Service.Bll.Logic.Coupon;
using OneCoin.Service.Bll.Logic.Coupon.V2;
using OneCoin.Service.Bll.Logic.Orders;
using OneCoin.Service.Bll.Logic.Orders.Task;
using OneCoin.Service.Bll.Logic.Orders.Task.OrderProccess;
using OneCoin.Service.Bll.Logic.Partnerpay;
using OneCoin.Service.Model.Dto.Request.Activity;
using OneCoin.Service.Model.Dto.Request.Orders;
using OneCoin.Service.Model.Dto.Response.Coupon;
using OneCoin.Service.Model.Dto.Response.Orders;
using OneCoin.Service.Model.Entity.Payment;
using OneCoin.Service.Model.Entity.Payment.Activity;
using OneCoin.Service.Model.Enum;
using OneCoin.Service.Model.Enum.Payment;
using OneCoin.Service.Model.Result;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace OneCoin.Service.UTester.Orders
{
    /// <summary>
    /// Summary description for OrdersTest
    /// </summary>
    [TestClass]
    public class OrdersTest : TestBase
    {
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


        [TestMethod]
        public void RechargeTest()
        { 
           
            var orderMoney = new decimal(100);
            var pt = PaymentType.BestPay;
            var dt = DateTime.Now;

            var ret =OrdersBll.GetRechargeOrder(new PurchaseReq
                {
                    CarNo = "15828082036",
                    OpenId = "123232",
                    CouponId = "",
                    CouponMoney = 1,
                    DeduMoney = 5,
                    Description = "预约车位",
                    OrderMoney = orderMoney,
                    PaymentType = pt,
                    Purpose = PaymentPurpose.预约车位,
                    UserId = 222,
                    OrderTime = dt

                });

            Assert.IsTrue(ret.IsSuccess,"获取充值订单号失败");
            Debug.Print(JsonConvert.SerializeObject(ret));

            var o = ret.Result as ResOrderDto;

            var res = new PurchaseQueryRes();
             PaymentMgr.Query(new PurchaseQueryReq
                 {
                     OrderNo = o.OrderNo,
                     PaymentType = pt,
                     IsWxApp = true,
                     Purpose = PaymentPurpose.账户充值,
                     OrderTime = dt.ToString()
                 }, ref res);


            var cf = new CanceledPaymentInfo
                {
                    OrderNo = o.OrderNo,
                    PaymentType = pt,
                    IsWxApp = true,
                    Purpose = PaymentPurpose.账户充值,
                    OrderTime = dt,
                    OrderMoney = orderMoney
                };
             PaymentMgr.CancelOrderQuery(ref cf);



             cf = new CanceledPaymentInfo
             {
                 OrderNo = o.OrderNo,
                 PaymentType = pt,
                 IsWxApp = true,
                 Purpose = PaymentPurpose.账户充值,
                 OrderTime = dt,
                 qn = "151217100142848753200003690",
                 OrderMoney = orderMoney
             };

             PaymentMgr.CancelOrder(ref cf);

            // 回调
            ret = OrdersBll.PaySuccessCallBackFroUnitTest(((ResOrderDto)ret.Result).OrderNo, Guid.NewGuid().ToString(), orderMoney);
            Assert.IsTrue(ret.IsSuccess, "充值回调失败");
        }


        [TestMethod]
        public void ProStopOrder()
        {
            var orderMoney = 10;
            var ret = OrdersBll.GetProStopOrder(new PurchaseReq
            {
                CarNo = "川AUUU22",
                OpenId = "dfsfsdfds",
                CouponId = "",
                CouponMoney = 1,
                DeduMoney = 5,
                Description = "测试临停支付",
                OrderMoney = orderMoney,
                PaymentType = PaymentType.WeixinPay,
                Purpose = PaymentPurpose.支付停车费,
                UserId = 140,
                OrderTime = DateTime.Now,
                EntranceTime = DateTime.Now.Subtract(new TimeSpan(5,1,1)),
                ExitTime = DateTime.Now,
                ErrMsg = "",
                ParkCode = "99999999",
                ParkName = "test"
            });

            Assert.IsTrue(ret.IsSuccess, "测试临停支付订单号失败");
             

 
            var data = ret.Result as ResOrderDto;
 
            // 回调
            ret = OrdersBll.PaySuccessCallBackFroUnitTest(data.OrderNo, Guid.NewGuid().ToString(), orderMoney);
            Assert.IsTrue(ret.IsSuccess, "测试临停支付回调失败");
        }


        [TestMethod]
        public void MonthlyFeeOrder()
        {
            var orderMoney = 22;
            var parkCode = "000001";
            var carNo = "川AAAA01";
            var userId = 222;

            var conpons = CouponBll.GetCanUseCoupons(parkCode, userId, carNo, string.Empty, PaymentPurpose.商品购买);
            var couponDtos = conpons.Result as List<ResCouponInfoDto>;
            var coupondt0 = couponDtos != null ? couponDtos.FirstOrDefault() : null;


            var ret = OrdersBll.GetMonthlyFeeOrder(new PurchaseReq
            {
                CarNo = carNo,
                OpenId = "",
                CouponId = coupondt0 == null ? "" : coupondt0.couponid,
                CouponMoney = coupondt0 == null ? 0 : coupondt0.couponmoney,
                DeduMoney = 0,
                Description = "测试月租支付",
                OrderMoney = coupondt0 == null ? orderMoney : Math.Max(0,orderMoney-coupondt0.couponmoney),
                PaymentType = PaymentType.EPark,
                Purpose = PaymentPurpose.商品购买,
                UserId = userId,
                OrderTime = DateTime.Now, 
                ErrMsg = "",
                ParkCode = parkCode,
                ParkName = "test",
                RenewalMonths = 1,
                TillDate = DateTime.Parse("2016-4-25")
            });

            Assert.IsTrue(ret.IsSuccess, "测试月租支付失败");

            if (ret.IsSuccess)
            {
                var order = ret.Result as ResOrderDto;
                ret = OrdersBll.PaySuccessCallBackFroUnitTest(order.OrderNo, Guid.NewGuid().ToString(), orderMoney);
            }

            // 回调
            
            Assert.IsTrue(ret.IsSuccess, "测试月租支付回调失败");
        }



        [TestMethod]
        public void ActivityOrder()
        {
            var orderMoney = 97;
            var parkCode = "2222";
            var carNo = "川A12345";
            var userId = 222;

        
            var ret = OrdersBll.GetActivityOrder(new ActivityPurchaseReq
                {
                    CarNo = "川A12345",
                    OpenId = "",
                    CouponId = "",
                    CouponMoney = 0,
                    DeduMoney = 0,
                    Description = "房车露营地",
                    OrderMoney = orderMoney,
                    PaymentType = PaymentType.EPark,
                    Purpose = PaymentPurpose.活动,
                    SubPurpose = PaymentSubPurpose.房车露营地,
                    UserId = 363,
                    OrderTime = DateTime.Now,
                    ErrMsg = "",
                    ParkCode = parkCode,
                    ParkName = "test",
                    RenewalMonths = 3,
                    TillDate = DateTime.Now,
                    SelectedDate = DateTime.Now,
                    ClientType = 2,
                    ActivityId = "fclyd2016",
                    ActivityName = "房车露营地"
                });

            Assert.IsTrue(ret.IsSuccess, "测试月租支付失败"); 
        }


      
        [TestMethod]
        public void MonthlyTimeFeeOrder()
        { 
            var orderMoney = 150;
            var parkCode = "000001";
            var carNo = "川AA0001";
            var userId = 363;

            var conpons = CouponBll.GetCanUseCoupons(parkCode, userId, carNo, string.Empty, PaymentPurpose.购买时段月租);
            var couponDtos = conpons.Result as List<ResCouponInfoDto>;


            var ret = OrdersBll.GetMonthlyTimeFeeOrder(new PurchaseReq
            {
                CarNo = carNo,
                OpenId = "",
                CouponId = (couponDtos != null ? couponDtos.FirstOrDefault() : null) == null ? "" : (couponDtos != null ? couponDtos.FirstOrDefault() : null).couponid,
                CouponMoney = (couponDtos != null ? couponDtos.FirstOrDefault() : null) == null ? 0 : (couponDtos != null ? couponDtos.FirstOrDefault() : null).couponmoney,
                DeduMoney = 0,
                Description = "购买时段月租",
                OrderMoney = (couponDtos != null ? couponDtos.FirstOrDefault() : null) == null ? orderMoney : Math.Max(0, orderMoney - (couponDtos != null ? couponDtos.FirstOrDefault() : null).couponmoney),
                PaymentType = PaymentType.EPark,
                Purpose = PaymentPurpose.购买时段月租,
                UserId = userId,
                OrderTime = DateTime.Now,
                ErrMsg = "",
                ParkCode = parkCode,
                ParkName = "test",
                RenewalMonths = 1,
                TillDate = DateTime.Now,
                SaleId = "000001$3", 
            });

            if (ret.IsSuccess)
            {
                var order = ret.Result as ResOrderDto;
                ret = OrdersBll.PaySuccessCallBackFroUnitTest(order.OrderNo, Guid.NewGuid().ToString(), orderMoney);
            }
             
            Assert.IsTrue(ret.IsSuccess, "测试月租支付回调失败");
        }




        [TestMethod]
        public void MonthlyTimeFeeOrderRenew()
        {
            var orderMoney = 150;
            var parkCode = "000001";
            var carNo = "川AA0001";
            var userId = 222;

            var conpons = CouponBll.GetCanUseCoupons(parkCode, userId, carNo, string.Empty, PaymentPurpose.购买时段月租);
            var couponDtos = conpons.Result as List<ResCouponInfoDto>;
            var coupondt0 = couponDtos != null ? couponDtos.FirstOrDefault() : null;



            var req = new PurchaseReq
            { 
                Purpose = PaymentPurpose.购买时段月租,
                SubPurpose = PaymentSubPurpose.时段月租续费,
                CarNo = carNo,
                ParkCode = parkCode,
                OrderMoney = coupondt0 == null ? orderMoney : Math.Max(0, orderMoney - coupondt0.couponmoney),
                OrderTime = DateTime.Now,
                Description = "",
                UserId = userId,
                OpenId = "",
                ClientType = 2,
                PaymentType = PaymentType.EPark,
                RenewalMonths = 1,
                SaleId = "000001$3",
                CouponId = coupondt0 == null ? "" : coupondt0.couponid,
                TillDate = DateTime.Parse("2016-6-6")
            };
             

             var ret=OrdersBll.GetMonthlyFeeOrder(req);


            if (ret.IsSuccess)
            {
                var order = ret.Result as ResOrderDto;
                ret = OrdersBll.PaySuccessCallBackFroUnitTest(order.OrderNo, Guid.NewGuid().ToString(), orderMoney);
            }

            Assert.IsTrue(ret.IsSuccess, "测试月租支付回调失败");
        }


        [TestMethod]
        public void OrderConfirmTest()
        {
            OrdersBll.ConfrimOrderNo("160825163157351418500002220");
        }

        [TestMethod]
        public void CancelOrderTest()
        {

            var cp = new CanceledPaymentInfo
            {
                OrderNo = "160624151308982666000164060",
                OrderMoney = 350,
                OrderTime = DateTime.Parse("2016-06-24 15:13:08"),
                ParkCode = "",
                qn = "201606241513089982888",
                PaymentType = (PaymentType)PaymentType.UnionPay, 
            };

            PaymentMgr.CancelOrder(ref cp);
        }


        [TestMethod]
        public void CancelOrderNoTest()
        {  
            var order = OrdersSuccesBll.GetOrders("160517153407700065800004781");

            var res = new CanceledPaymentInfo();
            res.CancelOrderNo = order.QN;
            res.IsWxApp = false;
            res.OrderNo = order.OrderNo;
            res.PaymentType = (PaymentType) order.PaymentType;
            res.Purpose = (PaymentPurpose)order.Purpose;
             
            // 检查参数合法信及额外信息
            PaymentMgr.CancelOrder(ref res);
              
        }

        [TestMethod]
        public void OrdersTaskTest()
        {
            OrdersTaskBll.Start();

            //Thread.Sleep(300000);
        }

     
         
        [TestMethod]
        public void CallBack()
         {
             var ret = OrdersBll.PaySuccessCallBackFroUnitTest("160825162959458575100002220", "1", 10);

            Assert.IsTrue(ret.IsSuccess, "测试支付回调失败");

         }


         [TestMethod]
        public void Proccess()
         {
             OrderProccessBll.Proccess(OrdersSuccesBll.GetOrders("160825162959458575100002220"));


         }
        

 
        [TestMethod]
        public void IsCanUseDefaultPayment()
        {

            var ret = PartnerpayControlBll.IsCanUseDefaultPayment("000000");
            ret = PartnerpayControlBll.IsCanUseDefaultPayment("666666666");
            ret = PartnerpayControlBll.IsCanUseDefaultPayment("22222");
            

            Print(ret);
        }

        [TestMethod]
        public void IsSubscribeCarTest()
        {

            var ret = OrdersSuccesBll.IsSubscribeCar("川A66669", DateTime.Parse("2016-04-20 11:32:29"));
             

            Print(ret);
        }


        [TestMethod]
        public void NotifySuccessTest()
        {
            var order = OrdersSuccesBll.GetOrders("160715143021697725400006200");
             ActivityBll.NotifySuccess(order);
        }



        [TestMethod]
        public void NotifySuccess1Test()
        {
            var order = CouponActivityBll.GetRecommendCoupon(); 
        }



        [TestMethod]
        public void GetLogs()
        {

            var ret = new OrdersController();

            var r= ret.GetOrderLogsV2(new ReqGetOrderLogsDto
                {
                    Take = 10,
                    Type = 7
                });


            Print(r);
        }


        [TestMethod]
        public void GetLogDetails()
        {

            var ret = new OrdersController();

            var r = ret.GetOrderLogDetail(new ReqGetOrderLogsDto
            {
                OrderNo = "160714174221908605500006110"
            });


            Print(r);
        }

        [TestMethod]
        public void GetPayAmountStatTest()
        {
            var order = new OrdersController().BuyAmountStat(new ReqGetActivityOrderNoDto{ActivityId = "fclyd2016"});

            Print(order);
        }


        [TestMethod]
        public void UpdateUsed()
        {
            var order = ActivityDn97Bll.UpdateUsed("868200004910");

            Print(order);
        }
        
        
        
    }
}
