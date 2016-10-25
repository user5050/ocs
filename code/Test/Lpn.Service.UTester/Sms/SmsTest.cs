using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneCoin.Service.Bll.Logic.Sms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OneCoin.Service.UTester.Sms
{
    [TestClass]
    public class SmsTest
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
        public void SMSSendTest()
        {
            string config= "type=chanzorService;username=eboche;pwd=152433;server=http://sms.chanzor.com:8001/sms.aspx?action=send";
            var ret = SmsBll.SmsSend(config, "18980594170", "1234");

            Assert.IsTrue(ret.IsSuccess, "验证码发送");
        }

        [TestMethod]
        public void SMSValidateTest()
        {
            var ret = SmsBll.Validate("18980594170", "1234");

            Assert.IsTrue(ret, "验证");
        }
    }
}
