using OneCoin.Service.Api.Controllers.Coupon;
using OneCoin.Service.Model.Dto.Request.Coupon;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OneCoin.Service.UTester.Coupon
{
    [TestClass]
    public class CouponTest : TestBase
    { 

        [TestMethod]
        public void GetItems()
        {
            var cc = new CouponController();

            var ret = cc.CouponsOfUser(new ReqCouponsOfUserDto
                {
                    Skip = 0,
                    Take = 100
                });

            Print(ret); 
        }

 

        [TestMethod]
        public void LockTest()
        {
   

        }
    }
}
