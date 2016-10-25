<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="Lpn.Service.Api.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div style="color: red">
    <label runat="server" id="lbMsg"></label></div><br/>
    <form id="form1" action="Test.aspx?action=monthlysync" runat="server">
        <div style="background:gainsboro">
        
        <label>合作商ID</label><asp:TextBox ID="PartnerId" value="test" runat="server"></asp:TextBox><br/>
        <label>停车场编码</label><asp:TextBox ID="ParkCode" value="66666666"  runat="server"></asp:TextBox><br/>
        </div>

         <br/>-----------------------------------------------------------------------------------<br/>
       <div> 
        
        <label>用户唯一标识</label><asp:TextBox ID="UserToken" value=""  runat="server"></asp:TextBox><br/>
        <label>手机号</label><asp:TextBox ID="Mobile" value=""  runat="server"></asp:TextBox><br/>
        <label>姓名</label><asp:TextBox ID="Name" value=""  runat="server"></asp:TextBox><br/>
        <label>车牌号码(多个以英文半角分割)</label><asp:TextBox ID="CarNos" value=""  runat="server"></asp:TextBox><br/>
        <label>缴费时间</label><asp:TextBox ID="StartTime"  runat="server"></asp:TextBox><br/>
        <label>过期时间</label><asp:TextBox ID="TillTime"  runat="server"></asp:TextBox><br/>
    
        <label>缴费金额(整数)</label><asp:TextBox ID="Consume" value=""  runat="server"></asp:TextBox><br/>
        <label>车位数量(整数)</label><asp:TextBox ID="ParkingAmount" value=""  runat="server"></asp:TextBox><br/>
        <label>车位号(多个以英文半角分割)</label><asp:TextBox ID="ParkingNos" value=""  runat="server"></asp:TextBox><br/>
        <label>月租费率(整数)</label><asp:TextBox ID="Rate" value=""  runat="server"></asp:TextBox><br/>
        <label>续费算费类型(1 上次到期时间+1开始算费 2 购买日+1开始算费)</label><asp:TextBox ID="RateType" value=""  runat="server"></asp:TextBox><br/>
        <asp:Button type="submit" value="提交" Text="提交" runat="server" OnClick="Unnamed14_Click"/>
         
        <br/>-----------------------------------------------------------------------------------<br/>
        
        <label>开始时间</label><asp:TextBox ID="tbStartTime" value=""  runat="server"></asp:TextBox><br/>
        <label>获取数量</label><asp:TextBox ID="tbTake" value=""  runat="server"></asp:TextBox><br/>
        <asp:Button ID="GetMonthlyRenewal" type="submit" value="提交" Text="查询续费记录" runat="server" OnClick="GetMonthlyRenewal_Click"/>
  
        
         <br/>-----------------------------------------------------------------------------------<br/>
          
        <label>入场截止时间</label><asp:TextBox ID="tbEntranceTime" value="test" runat="server"></asp:TextBox><br/>
        <label>出场截止时间</label><asp:TextBox ID="tbExitTime" value="66666666"  runat="server"></asp:TextBox><br/>
        <label>页号</label><asp:TextBox ID="tbPindex" value=""  runat="server"></asp:TextBox><br/>
        <label>页大小</label><asp:TextBox ID="tbPsize" value=""  runat="server"></asp:TextBox><br/>
        <asp:Button ID="Button1" type="submit" value="提交" Text="查询临停缴费记录" runat="server" OnClick="Button1_Click"/>
     </div>
    </form>
</body>
</html>
