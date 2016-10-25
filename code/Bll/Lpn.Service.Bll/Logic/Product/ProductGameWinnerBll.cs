using System.Collections.Generic;
using OneCoin.Service.Bll.Core;
using OneCoin.Service.Bll.Logic.SysUser;
using OneCoin.Service.Dal.Dal.Product;
using OneCoin.Service.Model.Dto.Response.Product;
using OneCoin.Service.Model.Extension.Product;
using OneCoin.Service.Model.Result;
using System.Linq;

namespace OneCoin.Service.Bll.Logic.Product
{
    public class ProductGameWinnerBll : BllBase
    {
        internal static Winer GetPrvWiner(string productId)
        {
            // 缓存中获取，每次计算后生成到缓存中
            return new Winer
                {
                    Amount = 1,
                    GameNo = "",
                    Head = "1",
                    Name = "",
                    Time = "",
                    WinNo = ""
                };
        }

        #region 往期揭晓
        /// <summary>
        /// 往期揭晓
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public static ResultDto GetWiners(string productId,int skip,int take)
        {
            var winers = ProductGameWinnerDal.GetGameWinners(productId, skip, take);
            var users = UserBll.GetUsers(winers.Select(x => x.Uid).ToList());

            return ResultDto.DefaultSuccess(winers.ToDto(users));
        }
        #endregion


        internal static List<Winer> GetWiners(List<string> gameNos)
        {
            var winers = ProductGameWinnerDal.GetGameWinners(gameNos);
     
            var users = UserBll.GetUsers(winers.Select(x => x.Uid).ToList());

            return winers.ToDto(users);
        }
    }
}
