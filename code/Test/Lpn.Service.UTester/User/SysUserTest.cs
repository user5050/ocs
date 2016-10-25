using OneCoin.Service.Api.Controllers.User;
using OneCoin.Service.Bll.Logic.SysUser;
using OneCoin.Service.Cache.Vcode;
using OneCoin.Service.Model.Dto.Request.SysUser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OneCoin.Service.UTester.User
{
    [TestClass]
    public class SysUserTest : TestBase
    {
        [TestMethod]
        public void Login()
        {
            const string mobile = "13096306608";

            // 先发短信
            VCodeCacheMgr.SetVCode(mobile, "1111");

            var userC = new UserController();
            var ret =userC.Login(new ReqRegistDto
                {
                    Devicetoken = "11111",
                    Mobile = mobile,
                    Vcode = "1111",
                    OpenId = string.Empty,
                    Uuid = string.Empty
                });

            Print(ret);
        }


        [TestMethod]
        public void Regist()
        { 
            var userC = new UserController();
            var ret = userC.Update(new ReqUpdateDto
                {
                    Driverlicence = "",
                    Nickname = "我是测试",
                    Realname = "系鞋带",
                    Sex = "男"
                });

            Print(ret);
        }


        [TestMethod]
        public void UpdateHead()
        {
            var userC = new UserController();
            var ret = userC.UpdateHead(new ReqUpdateHeadDto
            {
             Head   = "head.jpg"
            });

            Print(ret);
        }


        [TestMethod]
        public void SaveCity()
        {
            SysUserBll.TrySaveCity(344, "66666666");
             
        }

        [TestMethod]
        public void SaveCity01()
        {
            SysUserBll.TrySaveCity(334, "31", "104");
        }
         


        [TestMethod]
        public void BindMobile()
        {
            const string mobile = "13090000002";

            // 先发短信
            VCodeCacheMgr.SetVCode(mobile, "1111");

            var userC = new UserController();
            var ret = userC.BindMobile(new ReqBindMobileDto
            {
                Mobile = mobile,
                Vcode = "1111"
            });

            Print(ret);
        }
    }
}
