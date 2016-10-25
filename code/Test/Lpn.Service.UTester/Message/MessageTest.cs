using System;
using OneCoin.Service.Bll.Logic.Notification;
using OneCoin.Service.Bll.Logic.Orders;
using OneCoin.Service.Bll.Logic.Sms;
using OneCoin.Service.Bll.Notification;
using OneCoin.Service.Model.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OneCoin.Service.UTester.Message
{
     [TestClass]
    public class MessageTest:TestBase
    {
         [TestMethod]
         public void WxLogin()
         {
             NotificationHelper.NotificationCombineWXlogin(227, "13980952841", "川A12345");
         }

         [TestMethod]
         public void ParkIn()
         {
             //NotificationHelper.NotificationCombine103(227, "510107005","2014-11-12 05:42:36", "川A12345","积");
         }

         [TestMethod]
         public void ParkOut()
         {
             //NotificationHelper.NotificationCombine106(227, "2014-11-12 05:42:36","川A12345","布鲁布鲁","2014-11-11 01:42:36" ,"10" , "8","2",false,"0.0");
         }

         [TestMethod]
         public void PrivateNotification()
         {
             var item=NotificationBll.PrivateNotification(227);
             Print(item);
         }

         [TestMethod]
         public void PublicNotification()
         {
             var item = NotificationBll.PublicNotification(3,0);
             Print(item);
         }

         [TestMethod]
         public void AddPublicNotification()
         {
             var item = NotificationBll.AddPublicNotification(2,"测试数据1","我就是水","test.com");
         }

         [TestMethod]
         public void RevmovePublicNotification()
         {
             var item = NotificationBll.RevmovePublicNotification(1);
         }


         [TestMethod]
         public void GetSendingTimeMsgTest()
         {
             string smsConfig = WebConfig.SmsConfig;
             string randomCode = new Random().Next(9999).ToString().PadLeft(4, '0');
             SmsBll.SmsSend(smsConfig, "13096306603", randomCode);
         }


         [TestMethod]
         public void MonthTest()
         {
             // 充值
             var order = OrdersSuccesBll.GetOrders("160718154636754107300006110");

             NotificationHelper.SendForOrderProccessed(order);

             // 月租续费
             order = OrdersSuccesBll.GetOrders("160608170419536882100005560");

             NotificationHelper.SendForOrderProccessed(order);

             // 时段月租续费
             order = OrdersSuccesBll.GetOrders("160706164246941030200006060");

             NotificationHelper.SendForOrderProccessed(order);


             NotificationHelper.NotificationCombine601(620, "13096306603", "川A12121");
             NotificationHelper.NotificationCombine604(620, "13096306603", "川A12121");
         } 
          
    }
}
