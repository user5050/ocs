using System.Linq;
using System.Web.Mvc;
using OneCoin.Service.Api.Core;
using OneCoin.Service.Api.Core.Result;
using OneCoin.Service.Bll.Logic.Product;
using OneCoin.Service.Helper.Http;
using OneCoin.Service.Model.Dto.Request;
using OneCoin.Service.Model.Dto.Request.Product;

namespace OneCoin.Service.Api.Controllers.Product
{
    public class ProductController : BaseController
    { 
        #region 商品内

        public ActionResult Index(RequestPageDto data)
        {
            return new ClientResult(ProductBll.Get(data.Skip, data.Take));
        }

        public ActionResult Detail(ReqStrIdDto data)
        {
            return new ClientResult(ProductBll.Detail(data.Id));
        } 

        public ActionResult GetMembers(ReqGameMemberDto data)
        {
            return new ClientResult(ProductBll.GetMembers(data.GameNo, data.Skip, data.Take));
        }

        public ActionResult GetPrvs(ReqGameWinerDto data)
        {
            return new ClientResult(ProductGameWinnerBll.GetWiners(data.Pid, data.Skip, data.Take));
        }


        public ActionResult GetProductGameLastInfo(ReqStrIdDto data)
        {
            return new ClientResult(ProductBll.GetProductGameLastInfo(data.Id));
        }

        #endregion

        #region 晒单
        /// <summary>
        /// 晒单
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ActionResult GetGameShow(RequestPageDto data)
        {
            return new ClientResult(ProductBll.GetGameShow(data.Skip, data.Take));
        }
        #endregion

        #region 揭晓
        /// <summary>
        /// 揭晓
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ActionResult WaitForCompute(RequestPageDto data)
        {
            return new ClientResult(ProductBll.WaitForCompute(data.Skip, data.Take));
        }
        #endregion 

        #region 数量统计

        public ActionResult JoinCntStat(ReqStrIdDto data)
        {
            return new ClientResult(ProductBll.GetCurJoinStat(Spanner.SpliteStrings(data.Id,",").ToList()));
        }

        #endregion
    }
}
