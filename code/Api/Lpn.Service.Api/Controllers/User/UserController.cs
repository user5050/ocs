using System;
using System.Web.Mvc;
using OneCoin.Service.Api.Core;
using OneCoin.Service.Api.Core.Result;
using OneCoin.Service.Api.Filters;
using OneCoin.Service.Bll.Logic.Coupon;
using OneCoin.Service.Bll.Logic.Msg;
using OneCoin.Service.Bll.Logic.Product;
using OneCoin.Service.Bll.Logic.SysUser;
using OneCoin.Service.Model.Dto.Request;
using OneCoin.Service.Model.Dto.Request.SysUser;
using OneCoin.Service.Model.Dto.Response.User;
using OneCoin.Service.Model.Enum.Product;

namespace OneCoin.Service.Api.Controllers.User
{
    public class UserController : BaseController
    {
        #region 基础
        // /user/login
        // 登录
        public ActionResult Login(ReqRegistDto data)
        {
            return new ClientResult(UserBll.LoginOrRegist(data.Mobile, data.Vcode, data.Devicetoken, ClientType));
        }

        // /user/update
        // 更新资料
        [UserAuthFilter]
        public ActionResult Update(ReqUpdateDto data)
        {
            return new ClientResult(UserBll.Update(UserId,data.Nickname, data.Head));
        }

         
        // 更新头像
        [UserAuthFilter]
        public ActionResult UpdateHead(ReqUpdateHeadDto data)
        {
            return new ClientResult(UserBll.UpdateHead(UserId, data.Head));
        }

        // /user/bindmobile
        // 重新绑定手机号
        [UserAuthFilter]
        public ActionResult BindMobile(ReqBindMobileDto data)
        {
            return new ClientResult(UserBll.BindMobile(UserId, data.Mobile, data.Vcode));
        }

        #endregion

        #region 个人中心

        #region 参与情况
        /// <summary>
        /// 参与情况
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [UserAuthFilter]
        public ActionResult GameLogs(ReqGameLogsDto data)
        {
            switch (data.Type)
            {
                case GameLogsType.OnGoinOrWaitForCompute:
                    return new ClientResult(ProductBll.GameLogOfOnGoin(UserId, data.Skip, data.Take));
                    break;
                case GameLogsType.Couputed:
                    return new ClientResult(ProductBll.GameLogOfPublicity(UserId, data.Skip, data.Take));
                    break;
                case GameLogsType.Win:
                    return new ClientResult(ProductBll.GameLogOfWin(UserId, data.Skip, data.Take));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }
        #endregion

        #region 我的地址

        [UserAuthFilter]
        public ActionResult GetAddress()
        {
            return new ClientResult(UserContractBll.Gets(UserId));
        }

        [UserAuthFilter]
        public ActionResult Save(ResContractDto data)
        {
            return new ClientResult(UserContractBll.Save(UserId, data));
        }

        [UserAuthFilter]
        public ActionResult Del(ReqIntIdDto data)
        {
            return new ClientResult(UserContractBll.Del(UserId, data.Id));
        }


        [UserAuthFilter]
        public ActionResult SetDefault(ReqIntIdDto data)
        {
            return new ClientResult(UserContractBll.SetDefault(UserId, data.Id));
        }

        #endregion

        #region 我的晒单

        [UserAuthFilter]
        public ActionResult GameShows(RequestPageDto data)
        {
            return new ClientResult(ProductBll.GetUserGameShow(UserId, data.Skip, data.Take));
        }

        #endregion

        #region 我的消息

        [UserAuthFilter]
        public ActionResult Msgs(RequestPageDto data)
        {
            return new ClientResult(MsgInfoBll.Gets(UserId, data.Skip, data.Take));
        }

        [UserAuthFilter]
        public ActionResult MsgDetail(ReqIntIdDto data)
        {
            return new ClientResult(MsgInfoBll.GetDetail(UserId,data.Id));
        }

        [UserAuthFilter]
        public ActionResult DelMsg(ReqIntIdDto data)
        {
            return new ClientResult(MsgInfoBll.Del(UserId, data.Id));
        }

        #endregion

        #region 我的优惠券

        [UserAuthFilter]
        public ActionResult Coupons(RequestPageDto data)
        {
            return new ClientResult(CouponBll.GetCouponList(UserId, data.Skip, data.Take));
        }

        #endregion

        #endregion

    }
}
