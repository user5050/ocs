using System;
using System.Collections.Generic;
using System.Linq;
using OneCoin.Service.Helper.Http;
using OneCoin.Service.Model.Db.Game;
using OneCoin.Service.Model.Db.Product;
using OneCoin.Service.Model.Db.User;
using OneCoin.Service.Model.Dto.Response.Product;
using OneCoin.Service.Model.Extension.Dto;

namespace OneCoin.Service.Model.Extension.Product
{
    public static class ProductExtensions
    {
        #region  首页

        public static ResProductGameDetailDto ToDetail(this ProductGameDb pg, ProductInfoDb pi, Winer winer, int showCnt, List<GameMember> members)
        {
            return new ResProductGameDetailDto
                {
                    PreWiner = winer,
                    ProductInfo = pg.ToDto(pi),
                    ShowCnt = showCnt,
                    Members = members
                };
        }

        public static ResProductInGameDto ToDto(this ProductGameDb pg, ProductInfoDb product)
        {
            return new ResProductInGameDto
                {
                    Name = product.Name,
                    Img = product.Id,
                    Imgs = Spanner.SpliteStringsClearEmpty(product.Imgs, ",").ToList(),
                    Total = pg.TotalMoney,
                    Cur = pg.UserCnt,
                    GameNo = pg.GameNo
                };
        }
        #endregion

        #region 成员
        public static List<GameMember> ToDto(this List<GameMemberDb> data, List<UserBaseDb> users)
        {
            return data.Select(x => x.ToDto(users.FirstOrDefault(y => y.Id == x.UId))).ToList();
        }

        public static GameMember ToDto(this GameMemberDb data, UserBaseDb user)
        {
            return new GameMember
                {
                    Name = user != null ? user.Name : "",
                    Amount = data.BuyAmount,
                    Head = user != null ? user.Head : "",
                    Time = data.RowTime.ToFormat()
                };
        }
        #endregion

        #region 晒单

        public static List<ResGameShowDto> ToDto(this List<GameShowDb> datas, List<UserBaseDb> users,List<ProductInfoDb> products)
        {
            return datas.Select(x => x.ToDto(users.FirstOrDefault(y => y.Id == x.UId), products.FirstOrDefault(y=>y.Id==x.PId))).ToList();
        }

        public static List<ResGameShowDto> ToDto(this List<GameShowDb> datas, List<UserBaseDb> users, ProductInfoDb product)
        {
            return datas.Select(x => x.ToDto(users.FirstOrDefault(y => y.Id == x.UId), product)).ToList();
        }

        public static ResGameShowDto ToDto(this GameShowDb data, UserBaseDb user,ProductInfoDb product)
        {
            return new ResGameShowDto
                {
                    Comment = data.Comment,
                    Imgs = Spanner.SpliteStringsClearEmpty(data.Imgs, ",").ToList(),
                    Product = product.ToBase(),
                    User = user.ToWinerBase(data.GameNo, data.RowTime)
                };
        }

        public static ResProductDto ToBase(this ProductInfoDb data)
        {
            if (data == null) return null;

            return new ResProductDto
                {
                    Img = data.Img,
                    Name = data.Name
                };
        }

        public static WinerBase ToWinerBase(this UserBaseDb user,string gameNo,DateTime time)
        {
            if (user == null) return null;

            return new WinerBase
                {
                    GameNo = gameNo,
                    Head = user.Head,
                    Name = user.Name,
                    Time = time.ToFormat()
                };
        }
        #endregion

        #region 往期

        public static List<Winer> ToDto(this List<ProductGameWinnerDb> datas, List<UserBaseDb> users)
        {
            return datas.Select(x => x.ToDto(users.FirstOrDefault(y => y.Id == x.Uid))).ToList();
        }


        public static Winer ToDto(this ProductGameWinnerDb data, UserBaseDb user)
        {
            return new Winer
                {
                    Amount=data.BuyAmount,
                    GameNo = data.GameNo,
                    Head = user.Head,
                    Name=user.Name,
                    Time = data.RowTime.ToFormat(),
                    WinNo = data.WinNo.ToString()
                };
        }
        #endregion


        #region 已揭晓

        public static List<ResProductWaitForDto> ToWaitDto(this List<ResProductInGameDto> datas, List<Winer> winers)
        {
            return datas.Select(x => x.ToDto(winers.FirstOrDefault(y => y.GameNo == x.GameNo))).ToList();
        }


        public static ResProductWaitForDto ToDto(this ResProductInGameDto data, Winer user)
        {
            return new ResProductWaitForDto
                {
                    Product = data,
                    Winer = user
                };
        }

        #endregion



        #region 中奖

        public static List<ResProductWinDto> ToWinDto(this List<ResProductInGameDto> datas, List<Winer> winers, List<GameExpresDb> expres)
        {
            return datas.Select(x => x.ToWinDto(winers.FirstOrDefault(y => y.GameNo == x.GameNo),expres.FirstOrDefault(y => y.GameNo == x.GameNo))).ToList();
        }


        public static ResProductWinDto ToWinDto(this ResProductInGameDto data, Winer user, GameExpresDb expres)
        {
            return new ResProductWinDto
            {
                Product = data,
                Winer = user,
                Exress = expres.ToDto()
            };
        }


        public static ResExpresDto ToDto(this GameExpresDb data)
        {
            if (data == null) return null;

            return new ResExpresDto
                {
                    Address = data.Address,
                    Name = data.Name,
                    State = data.State
                };
        }
        #endregion

    }
}
