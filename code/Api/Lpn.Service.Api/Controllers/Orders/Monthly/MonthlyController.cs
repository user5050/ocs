using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Lpn.Service.Api.Core;
using Lpn.Service.Api.Core.Result;
using Lpn.Service.Api.Filters;
using Lpn.Service.Bll.Logic.Monthly;
using Lpn.Service.Bll.Logic.Montyly;
using Lpn.Service.Bll.Logic.Park;
using Lpn.Service.Bll.Logic.SysUser;
using Lpn.Service.Model.Dto.Request.Monthly;
using Lpn.Service.Model.Dto.Response.Monthly;
using Lpn.Service.Model.Extension.Monthly;
using Lpn.Service.Model.Result;

/*
 * 功能：月租车辆相关
 * 作者：lee & yang
 * 时间：2015/12/30
 * 详细：我的月租车
 *      时段月租
 */

namespace Lpn.Service.Api.Controllers.Monthly
{
    
    public class MonthlyController : BaseController
    {
        // 获取指定用户的所有月租车信息(包括APP添加的车牌)
        // GET: /Monthly/GetMonthlyCars
        [UserAuthFilter]
        public ActionResult GetMonthlyCars()
        {
            return new ClientResult(MonthlyCarInfoBll.GetMonthlyCars(UserId));
        }

        // APP根据已有月租车位添加车牌，并提交给本地停车场
        // GET: /Monthly/AddMonthlyCarViaApp
        [UserAuthFilter]
        public ActionResult AddMonthlyCarViaApp(ReqAddMonthlyCarViaAppDto data)
        {
            return new ClientResult(MontylyCarInfoaddByappBll.AddMonthlyCarViaApp(data.ParkCode, data.UserID, data.CarNo, data.OperationType));
        }


        // 获取时段月租车信息售卖列表
        // GET: /Monthly/GetMonthlyTimeForSale
        [UserAuthFilter]
        public ActionResult GetMonthlyTimeForSale(ReqGetMonthlyTimeForSaleDto data)
        {
            return new ClientResult(MonthlyTimecarinfoBll.GetForSale(data.Skip, data.Take));
        }


        // 获取时段月租车信息售卖列表(160412)
        // GET: /Monthly/GetMonthlyTimeForSaleV2
        [UserAuthFilter]
        public ActionResult GetMonthlyTimeForSaleV2(ReqGetMonthlyTimeForSaleDto data)
        {
            return new ClientResult(MonthlyTimecarinfoBll.GetForSale(data.City, data.OrderBy, data.Skip, data.Take,data.Lng, data.Lat));
        }

        // 获取时段月租车信息售卖列表(160412)
        // GET: /Monthly/GetMonthlyTimeForSaleV2
        [UserAuthFilter]
        public ActionResult GetMonthlyTimeForSaleV2Home(ReqGetMonthlyTimeForSaleDto data)
        {
            var defaultCity = SysUserBll.GetUserCity(UserId);
            var cities = ParkInfoBll.GetParkAllCitys();
            if (!cities.Contains(defaultCity))
            {
                defaultCity = "";
            }

            var sales = MonthlyTimecarinfoBll.GetForSale(defaultCity, data.OrderBy, data.Skip, data.Take, data.Lng, data.Lat).Result as List<ResMonthlyTimecarinfoDto>;

            return new ClientResult(ResultDto.DefaultSuccess(sales.ToHomeDto(defaultCity,cities)));
        }
         
        // 获取时段月租车信息售卖详情
        // GET: /Monthly/GetMonthlyTimeDetail
        [UserAuthFilter]
        public ActionResult GetMonthlyTimeDetail(ReqGetMonthlyTimeDetailDto data)
        {
            return new ClientResult(MonthlyTimecarinfoBll.GetSaleDetail(data.SaleId,DateTime.Now,false));
        }


        // 查询车辆是否可以用于购买时段月租
        // GET: /Monthly/IsCarOk
        [UserAuthFilter]
        public ActionResult IsCarOk(ReqIsCarOkDto data)
        {
            return new ClientResult(MonthlyTimecarinfoBll.IsCarOk(UserId, data.SaleId, data.CarNo));
        }


        // 获取指定车牌月租信息
        // GET: /Monthly/GetMonthlyInfoByCarNo
        public ActionResult GetMonthlyInfoByCarNo(ReqGetMonthlyInfoByCarNoDto data)
        {
            return new ClientResult(MonthlyCarInfoBll.GetMonthlyInfoByCarNo(data.CarNo));
        }

        // 验证用户是否为指定车牌月租车主
        // GET: /Monthly/IsMonthlyCarBindMobile
        [UserAuthFilter]
        public ActionResult IsMonthlyCarBindMobile(ReqIsMonthlyCarBindMobileDto data)
        {
            return new ClientResult(MonthlyCarInfoBll.IsMonthlyCarBindMobile(UserId,data.CarNo,data.ParkCode));
        }


        // 月租试用
        // GET: /Monthly/viptryout
        [UserAuthFilter]
        public ActionResult VipTryOut(ReqVipTryOutDto data)
        {
            return new ClientResult(MonthlyCarInfoBll.VipTryOut(data.CarNo, data.ParkCode));
        }


        // 月租车是否为会员月租
        // GET: /Monthly/IsVip
        [UserAuthFilter]
        public ActionResult IsVip(ReqVipTryOutDto data)
        {
            return new ClientResult(MonthlyCarInfoBll.IsVip(data.CarNo, data.ParkCode));
        }


        // 查询指定用户是否为任意停车场月租vip
        // GET: /Monthly/IsAnyParkMonthlyVip
        [UserAuthFilter]
        public ActionResult IsAnyParkMonthlyVip()
        {
            return new ClientResult(MonthlyCarInfoBll.IsAnyParkMonthlyVip(UserId));
        }
    }
}
