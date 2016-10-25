using System.Collections.Generic;
using System.Linq;
using OneCoin.Service.Model.Db.Orders;
using OneCoin.Service.Model.Dto.Response.Orders;
using OneCoin.Service.Model.Enum.Payment;
using OneCoin.Service.Model.Extension.Dto;

namespace OneCoin.Service.Model.Extension.Orders
{
    public static class OrdersExtension
    {
        #region 订单列表
        public static List<ResOrderLogDto> ToLogDto(this IEnumerable<OrdersSuccesDb> datas, Dictionary<string, string> parkNames,   Dictionary<string, string> spNames)
        {
            return datas.Select(p => p.ToLogDto(parkNames.ContainsKey(p.ParkCode) ? parkNames[p.ParkCode] : "",  spNames)).ToList();
        }

        public static ResOrderLogDto ToLogDto(this OrdersSuccesDb data, string parkName,  Dictionary<string, string> spNames)
        {
            return new ResOrderLogDto
            {
                CarNo = data.CarNo,
                PayType = data.PaymentType, 
                OrderMoney = data.OrderMoney,
                OrderTime = data.OrderTime.ToFormat(),
                OrderNo = data.OrderNo,
                IsIncome = data.Purpose == (int)PaymentPurpose.账户充值 ? 1 : 0,
                 RechargeMobile = data.Purpose == (int)PaymentPurpose.账户充值 ? data.CarNo : "",
                Purpose = data.Purpose,
                Extre = data.Extre,
                //ActivityName = activity != null ? activity.ActivityName : string.Empty
            };
        }


        public static List<ResOrderLogDto> ToLogDto(this IEnumerable<OrdersCanceledDb> datas, Dictionary<string, string> parkNames)
        {
            return datas.Select(p => p.ToLogDto(parkNames.ContainsKey(p.ParkCode)?parkNames[p.ParkCode]:"")).ToList();
        }

        public static ResOrderLogDto ToLogDto(this OrdersCanceledDb data, string parkName)
        {
            return new ResOrderLogDto
            {
                CarNo = data.CarNo,
                PayType = data.PaymentType,
                Description = data.Description,
                OrderMoney = data.OrderMoney,
                OrderTime = data.OrderTime.ToFormat(),
                OrderNo = data.OrderNo,
                IsIncome = data.Purpose == (int)PaymentPurpose.账户充值 ? 1 : 0,
                ParkName = parkName,
                RechargeMobile = data.Purpose == (int)PaymentPurpose.账户充值 ? data.CarNo : "",
                Purpose = data.Purpose,
                Extre = data.Extre
            };
        }
         
        #endregion

         
    }
}
