using System;
using System.Collections.Generic;
using OneCoin.Payment.Entity;
using OneCoin.Service.Helper.Log;
using OneCoin.Service.Model.Entity.Payment;

namespace OneCoin.Payment.Plugins.EPark
{
    /// <summary>
    /// e泊账户
    /// </summary>
    public class EPark : IPayment
    {
        /// <summary>
        /// 是否支持撤费
        /// </summary>
        public bool IsEnableCancel
        {
            get { return false; }
        }

        /// <summary>
        /// 消费查询是否成功
        /// </summary>
        /// <param name="req">查询的请求参数</param>
        /// <param name="res">查询结论的反馈</param>
        /// <returns>true=调用成功 false=调用失败</returns>
        public bool Query(PurchaseQueryReq req, ref PurchaseQueryRes res)
        {
             throw new NotSupportedException();
        }


        public string GetOrderNo(IDictionary<string, string> param)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 撤费查询
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool CancelOrderQuery(ref CanceledPaymentInfo info)
        {
            throw new NotSupportedException();
        }


        /// <summary>
        /// 申请支付
        /// </summary>
        /// <param name="req">支付的请求参数</param>
        /// <param name="res">支付结论的反馈</param>
        /// <returns>true=调用成功 false=调用失败</returns>
        public bool GetPurchaseNo(PurchaseReq req, ref PurchaseRes res)
        {
            try
            {
                res.CarNo = req.CarNo;
                res.Description = req.Description;

                res.OrderMoney = req.OrderMoney;
                res.OrderNo = req.OrderNo;
                res.OrderTime = req.OrderTime;
                res.ParkCode = req.ParkCode;
                res.Purpose = req.Purpose;
                res.Description = req.Description;

                res.EntranceTime = req.EntranceTime;
                res.ExitTime = req.ExitTime;

                res.TillDate = req.TillDate;
                res.RenewalMonths = req.RenewalMonths;

                res.PaymentType = req.PaymentType;
                res.UserId = req.UserId;
                res.Result = 1;

                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Add("bool ePark.GetPurchaseNo(PurchaseReq req, ref PurchaseRes res)", ex);
                return false;
            }
        }

        /// <summary>
        /// 撤费申请
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool CancelOrder(ref CanceledPaymentInfo info)
        {
            throw new NotSupportedException();

        }

        /// <summary>
        /// 检测异步回调的支付通知
        /// </summary>
        /// <param name="info"></param> 
        /// <returns></returns>
        public PurchaseNotify CheckNotify(CallBackPaymentInfo info)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// 检测异步回调的撤销通知(没有异步回调撤费通知)
        /// </summary>
        /// <param name="info"></param> 
        /// <returns></returns>
        public CanceledPaymentInfo CheckCancelNotify(CallBackPaymentInfo info)
        {
            throw new NotSupportedException();
        }

        public string PayName()
        {
            return "余额支付";
        }
    }
}
