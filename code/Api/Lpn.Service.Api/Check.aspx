<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false"  Inherits="System.Web.UI.Page" %>
<%@ Import Namespace="Lpn.Service.Bll.Logic.Coupon" %>
<%@ Import Namespace="Lpn.Service.Bll.Logic.Orders" %>
<%@ Import Namespace="Lpn.Service.Bll.Logic.SysUser" %>
<%@ Import Namespace="Lpn.Service.Dal.Dal.Orders" %>
<%@ Import Namespace="Lpn.Service.Helper.Http" %>
<%@ Import Namespace="Lpn.Service.Helper.Serialization" %>
<%@ Import Namespace="Lpn.Service.Model.Entity.Coupon" %>
<%@ Import Namespace="Lpn.Service.Model.Entity.Payment" %>
<%@ Import Namespace="Lpn.Service.Model.Enum.Payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" method="post" action="Check.aspx">
    <div>
    <%
        //var orderMoney = new decimal(1);
        //var pt = PaymentType.UnionPay;
        //var dt = DateTime.Now;

        //var ret = OrdersBll.GetRechargeOrder(new PurchaseReq
        //{
        //    CarNo = "15828082036",
        //    OpenId = "",
        //    CouponId = "",
        //    CouponMoney = 1,
        //    DeduMoney = 5,
        //    Description = "测试充值",
        //    OrderMoney = orderMoney,
        //    PaymentType = pt,
        //    Purpose = PaymentPurpose.账户充值,
        //    UserId = 222,
        //    OrderTime = dt
        //});
        
        if (Request.HttpMethod.ToLower()=="post")
        {
            var orderNo = HttpHelper.GetPramaValue("orderno", "");

            if (!string.IsNullOrEmpty(orderNo))
            {
                var order = OrdersSuccesDal.GetByPriKey(orderNo);
                if (order != null)
                {
                    if (order.Purpose != (int) PaymentPurpose.账户充值)
                    {
                        Response.Write("非充值类订单号");
                    }
                    else
                    {
                        var ret = CouponBll.GetCoupon(order.UserID, CouponType.RechargeBigMoney, orderNo, 0);

                        if (ret.IsSuccess)
                        {
                            Response.Write("补发成功");
                        }
                        else
                        {
                            Response.Write("无发券活动或已领取");
                        }
                    }
                    
                }
                else
                {
                    Response.Write("无此订单号");
                } 
            }
            else
            {
                Response.Write("请输入订单号");
            }
        }  
    %>
    </div>
        
        请填写订单号 ：<input type="text" name="orderno" style="width: 200px"/>
        <input type="submit"  value="补发充值获取优惠券"/>
    </form>
</body>
</html>
