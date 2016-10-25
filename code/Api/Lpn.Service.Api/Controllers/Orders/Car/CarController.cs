using System.Web.Mvc;
using Lpn.Service.Api.Core;
using Lpn.Service.Api.Core.Result;
using Lpn.Service.Api.Filters;
using Lpn.Service.Bll.Logic.Car;
using Lpn.Service.Bll.Logic.CarMent;
using Lpn.Service.Bll.Logic.ThirdParty;
using Lpn.Service.Model.Dto.Request.Car;
using Lpn.Service.Model.Dto.Response.PartnerService;

namespace Lpn.Service.Api.Controllers.Car
{
    [UserAuthFilter]
    public class CarController : BaseController
    {
        // 获取车牌授权用户信息
        // GET: /Car/GetAuthorizations
        public ActionResult GetAuthorizations(ReqGetAuthorizationDto data)
        {
            return new ClientResult(CarMentBll.GetAuthorizations(UserId, data.CarNo));
        }

        // 添加车牌授权用户信息
        // GET: /Car/AddAuthorization
        public ActionResult AddAuthorization(ReqAddAuthorizationDto data)
        {
            return new ClientResult(CarMentBll.AddAuthorization(UserId, data.CarNo, data.UserName));
        }

        // 删除车牌授权用户信息
        // GET: /Car/DelAuthorization
        public ActionResult DelAuthorization(ReqDelAuthorizationDto data)
        {
            return new ClientResult(CarMentBll.DelAuthorization(UserId, data.CarNo, data.UserName));
        }

        //注册车辆
        //GET: /Car/RegeditCar
        public ActionResult RegeditCar(ReqRegeditCarDto data)
        {
            return new ClientResult(CarMentBll.RegeditCar(UserId, data.Carno, data.CarBrand, data.CarModel, data.Color,ClientType));
        }

        //微信注册车辆
        //GET: /Car/RegeditCarForWeixin
        public ActionResult RegeditCarForWeixin(ReqRegeditCarDto data)
        {
            return new ClientResult(CarMentBll.RegeditCarForWeixin(UserId, data.Carno, data.CarBrand, data.CarModel, data.Color, ClientType));
        }

        //修改车辆
        //GET: /Car/UpdateCar
        public ActionResult UpdateCar(ReqUpdateCarDto data)
        {
            return new ClientResult(CarOwnerBll.UpdateCar(UserId, data.Carno, data.CarBrand, data.Color, data.Image));
        }

        //根据当前账户获取所有绑定车牌
        //GET: /Car/GetBindCarNoInfo
        public ActionResult GetBindCarNoInfo()
        {
            return new ClientResult(CarMentBll.GetBindCarNoInfo(UserId));
        }

        //找回车辆
        //GET: /Car/FindCar
        public ActionResult FindCar(ReqFindCarDto data)
        {
            return new ClientResult(CarOwnerAppBll.FindCar(UserId, data.Carno, data.Image));
        }

        //获取车辆信息
        //GET: /Car/GetCarInfo
        public ActionResult GetCarInfo(ReqGetCarInfoDto data)
        {
            return new ClientResult(CarOwnerBll.GetCarInfo(UserId, data.Carno));
        }

        //根据当前账户获取所有绑定车牌(包括分享和绑定)
        //GET: /Car/GetCarnos
        public ActionResult GetCarnos()
        {
            return new ClientResult(CarMentBll.GetCarnos(UserId));
        }

        //根据当前账户获取所有绑定车牌(包括分享和绑定)
        //GET: /Car/GetCarsV2
        public ActionResult GetCarsV2()
        {
            return new ClientResult(CarMentBll.GetCarsV2(UserId));
        }

        //删除车牌号
        //GET: /Car/DelCarno
        public ActionResult DelCarno(ReqDelCarnoDto data)
        {
            return new ClientResult(CarMentBll.DelCarno(UserId, data.Carno));
        }


        //查询指定车辆是否需要二次确认删除
        //GET: /Car/IsNeedConfirmDelCarNo
        public ActionResult IsNeedConfirmDelCarNo(ReqDelCarnoDto data)
        {
            return new ClientResult(CarMentBll.IsNeedConfirmDelCarNo(data.Carno));
        }

        public ActionResult Img(ReqDelCarnoDto data)
        {
            return new ClientResult(CarMentBll.IsNeedConfirmDelCarNo(data.Carno));
        }

        // 查询车场图片
        // GET: /car/image
        [PartnerAuthFilter]
        public ActionResult Image(ReqCarImageDto data)
        {
            return new ClientResult(PartnerServiceBll.ImageSmall(data.ParkCode, data.ImageId));
        }
    }
}
