using OneCoin.Service.Api.Controllers.User;
using OneCoin.Service.Bll.Logic.SysUser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OneCoin.Service.UTester.User
{
    [TestClass]
    public class WalletTest : TestBase
    { 
        [TestMethod]
        public void OrdersTaskTest()
        {
            var wc = new WalletController();
            var b = wc.Balance();

            Print(b);
        }

        
    }
}
