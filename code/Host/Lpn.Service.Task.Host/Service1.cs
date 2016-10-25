using System;
using System.ServiceProcess;
using OneCoin.Service.Bll.Logic.Coupon.Task;
using OneCoin.Service.Bll.Logic.Orders.Task;
using OneCoin.Service.Helper.Log;

namespace OneCoin.Service.Task.Host
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        { 
            LogHelper.Add("服务开始启动");

            try
            {
                OrdersTaskBll.Start(); 
                CouponTaskBll.Start(); 
            }
            catch (Exception ex)
            {
                LogHelper.Add("服务异常",ex);
                throw;
            }
             
            LogHelper.Add("服务完成启动");
        }

        protected override void OnStop()
        {
            LogHelper.Add("服务关闭");
        }
    }
}
