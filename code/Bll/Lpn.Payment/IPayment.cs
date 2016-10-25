using System;
using System.Collections.Generic;
using OneCoin.Payment.Entity;
using OneCoin.Service.Model.Entity.Payment;

namespace OneCoin.Payment
{
    interface IPayment
    {
        /// <summary>
        /// 查询支付是否成功
        /// </summary>
        /// <param name="req">查询的请求参数</param>
        /// <param name="res">查询结论的反馈</param>
        /// <returns>true=调用成功 false=调用失败</returns>
        bool Query(PurchaseQueryReq req,ref PurchaseQueryRes res);


        /// <summary>
        /// 申请支付
        /// </summary>
        /// <param name="req">支付的请求参数</param>
        /// <param name="res">支付结论的反馈</param>
        /// <returns>true=调用成功 false=调用失败</returns>
        bool GetPurchaseNo(PurchaseReq req, ref PurchaseRes res);

        /// <summary>
        /// 是否支持撤费
        /// </summary>
        bool IsEnableCancel { get; }

        /// <summary>
        /// 撤费申请
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool CancelOrder(ref CanceledPaymentInfo info);


        /// <summary>
        /// 获取订单号
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        string GetOrderNo(IDictionary<String, String> param);

        /// <summary>
        /// 撤费查询
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool CancelOrderQuery(ref CanceledPaymentInfo info);

        /// <summary>
        /// 检测异步回调的支付通知
        /// </summary>
        /// <param name="info"></param> 
        /// <returns></returns>
        PurchaseNotify CheckNotify(CallBackPaymentInfo info);

        /// <summary>
        /// 检测异步回调的撤销通知
        /// </summary>
        /// <param name="info"></param> 
        /// <returns></returns>
        CanceledPaymentInfo CheckCancelNotify(CallBackPaymentInfo info);

        /// <summary>
        /// 支付名称
        /// </summary>
        /// <returns></returns>
        string PayName();
    }
}
