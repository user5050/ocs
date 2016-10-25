using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneCoin.Service.Api.Controllers.Sys;
using OneCoin.Service.Api.Core.Result;
using OneCoin.Service.Bll.Logic.Sms;
using OneCoin.Service.Model.Result;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace OneCoin.Service.UTester.Sms
{
    [TestClass]
    public class SysItemCodeTest:TestBase
    {
        private SysItemCodeController controler = new SysItemCodeController();

        [TestMethod]
        public void Get()
        {
            var b = (controler.Get() as ClientResult).Data as ResultDto;
            Assert.IsTrue(b.IsSuccess, "获取系统参数失败");
            Debug.Print(JsonConvert.SerializeObject(b));
        }
    }
}
