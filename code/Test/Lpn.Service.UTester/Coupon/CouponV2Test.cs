using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneCoin.Service.Api.Controllers.Coupon;
using OneCoin.Service.Bll.Logic.Coupon;
using OneCoin.Service.Bll.Logic.Coupon.V2;
using OneCoin.Service.Bll.Logic.Orders;
using OneCoin.Service.Model.Dto.Request.Coupon;
using OneCoin.Service.Model.Entity.Coupon;
using OneCoin.Service.Model.Enum.Payment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OneCoin.Service.UTester.Coupon
{
    [TestClass]
    public class CouponV2Test : TestBase
    {
        [TestMethod]
        public void Login()
        {
            var cc = new CouponV2Controller();

            var ret = cc.Get(new ReqGetCouponDto
                { 
                    Type = CouponType.Regist
                });

            Print(ret); 
        }

        [TestMethod]
        public void Recharge()
        {
            var cc = new CouponV2Controller();

            var ret = cc.Get(new ReqGetCouponDto
            {
                Type = CouponType.Recharge,
                OrderNo = "160419144538288443700002420"
            });

            Print(ret);
        }


        [TestMethod]
        public void Activity()
        {
            var cc = new CouponV2Controller();

            var ret = cc.Get(new ReqGetCouponDto
            {
                Type = CouponType.HtmlActivity,
                ActivityId = "ggccdd"
            });

            Print(ret);
        }


        [TestMethod]
        public void GetItems()
        {
            var cc = new CouponV2Controller();

            var ret = cc.CouponsCanPay(new ReqCouponsCanPayDto
                {
                    Purpose = PaymentPurpose.支付停车费,
                    ParkCode = "6666666666"
                    
                });

            Print(ret);



            ret = cc.CouponsCanPay(new ReqCouponsCanPayDto
            {
                Purpose = PaymentPurpose.商品购买,
                ParkCode = "6666666666"
            });

            Print(ret);


            ret = cc.CouponsCanPay(new ReqCouponsCanPayDto
            {
                Purpose = PaymentPurpose.购买时段月租,
                ParkCode = "6666666666"
            });

            Print(ret);

            ret = cc.CouponsCanPay(new ReqCouponsCanPayDto
            {
                Purpose = PaymentPurpose.账户充值
            });

            Print(ret);

            ret = cc.CouponsCanPay(new ReqCouponsCanPayDto
            {
                Purpose = PaymentPurpose.活动,
                ActivityId = "1020"
            });

            Print(ret);
        }

        [TestMethod]
        public void Description()
        {
            var cc = new CouponV2Controller();

            var ret = cc.Description(
                new ReqGetCouponDto() { Type = CouponType.RecommendNew }
            );

            Print(ret);
        }

        [TestMethod]
        public void GetRecommendCoupon()
        {
            var cc = new CouponV2Controller();

            var ret = cc.GetRecommendCoupon();

            Print(ret);
        }

        [TestMethod]
        public void GetRegisterCoupon()
        {
            var cc = new CouponV2Controller();

            var ret = cc.GetRegisterCoupon();

            Print(ret);
        }


        [TestMethod]
        public void GetValidCouponForProStopTest()
        {

            var couponId = "";
            var couponMoney = 0D;

            var ret = CouponBll.GetValidCouponForProStop(561, "19925123", "川A55585", out couponId, out couponMoney);

            Print(ret);
        }

        

        [TestMethod]
        public void LockFastPayCouponTest()
        {

            var ret = CouponBll.LockFastPayCoupon(222, "456", "0ab355fa-1651-11e6-a6f7-00e04c7db43c", "川AN6F39");

            Print(ret);
        }


         [TestMethod]
        public void CouponBllTest()
         {

             var ret = CouponBll.GetCanUseCouponsV2("", 611, "", "", PaymentPurpose.活动);

            Print(ret);
        }

        

        [TestMethod]
        public void GetRecommendUrl()
        {

            var cc = new CouponV2Controller();

            var ret = cc.GetRecommendUrl();

            Print(ret);
        }


        [TestMethod]
        public void SendGiftByAdminTest()
        {

            var cc = new CouponV2Controller();

            var ret = cc.SendGiftByAdmin(new ReqSendCouponToUserDto { CouponActivityId = 42, Mobiles = new List<string> { "13458555680" } });

            Print(ret);
        }

 


        [TestMethod]
        public void GetTest()
        {
            for (int i = 0; i < 100; i++)
            {
                var ret = CouponActivityBll.GetGiftForPreView("1");

                Print(ret);
                var data = ret.Result as GetGiftDto ?? new GetGiftDto();
                if (data != null)
                {
                    ret = CouponActivityBll.GetGift(0, CouponType.HtmlActivity, "", "1", "13596306"+i.ToString("D3"), data.GiftId);
                }

                Print(ret);
            }
            
        }


        [TestMethod]
        public void Register()
        {

            var ret = CouponActivityBll.GetGift(0, CouponType.HtmlActivity, "", "1", "13096306600");

            Print(ret);
        }


        [TestMethod]
        public void CouTemp()
        {

            var ret = CouponActivityTempBll.GetTemp("123123123123");

            Print(ret);
        }


        [TestMethod]
        public void TryGetActivity()
        {
            var order = OrdersSuccesBll.GetOrders("160808101859720531800006201");
            CouponActivityBll.TryGetCoupon(order); 
        }
    }
}
