using System;
using System.Collections.Generic;
using OneCoin.Payment.Entity;
using OneCoin.Service.Helper.Log;
using OneCoin.Service.Model.Entity.Payment;
using OneCoin.Service.Model.Enum.Payment;

namespace OneCoin.Payment
{
    public class PaymentMgr
    {
        private static readonly Dictionary<string, IPayment> PaymentList = new Dictionary<string, IPayment>(); //存放所有可用的支付接口
        private static readonly object Lock = new object();

        #region init
        static PaymentMgr()
        {
            if (PaymentList.Count <= 0)
            {
                lock (Lock)
                {
                    if (PaymentList.Count <= 0)
                        LoadPlugins();
                }

            }
        }

        /// <summary>
        /// 载入所有支付插件
        /// </summary> 
        private static void LoadPlugins()
        {
            var module = typeof(IPayment).Module;
            var types = module.GetTypes();

            // 加载支付插件
            foreach (var item in types)
            {
                if (!item.IsAbstract && item.IsClass && item.GetInterface(typeof(IPayment).Name) != null && !item.Name.Equals("Payments"))
                {
                    try
                    {
                        if (!PaymentList.ContainsKey(item.Name))
                        {
                            var obj = Activator.CreateInstance(item) as IPayment;
                            PaymentList.Add(item.Name, obj);
                        }
                        LogHelper.Add(string.Format("载入支付插件{0}", item.Name));
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Add(string.Format("载入支付插件{0}出错", item.Name), ex);
                    }
                }
            } 
        }
        #endregion

        /// <summary>
        /// 做订单的撤费处理
        /// </summary>
        /// <param name="info">撤费的信息</param>
        /// <returns></returns>
        public static bool CancelOrder(ref CanceledPaymentInfo info)
        {
            if (PaymentList[info.PaymentType.ToString()].IsEnableCancel)
            {
                return PaymentList[info.PaymentType.ToString()].CancelOrder(ref info);
            }

            return false;
        }

        /// <summary>
        /// 做订单的撤费查询处理
        /// </summary>
        /// <param name="info">撤费的信息</param>
        /// <returns></returns>
        public static bool CancelOrderQuery(ref CanceledPaymentInfo info)
        {
            if (PaymentList[info.PaymentType.ToString()].IsEnableCancel)
            {
                return PaymentList[info.PaymentType.ToString()].CancelOrderQuery(ref info);
            }

            return false;
        }

        /// <summary>
        /// 查询已支付订单是否成功
        /// </summary>
        /// <param name="req"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public static bool Query(PurchaseQueryReq req, ref PurchaseQueryRes res)
        {
            return PaymentList[req.PaymentType.ToString()].Query(req, ref res);
        }

        /// <summary>
        /// 获取支付流水号
        /// </summary>
        /// <param name="req"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public static bool GetPurchaseNo(PurchaseReq req, ref PurchaseRes res)
        {
            return PaymentList[req.PaymentType.ToString()].GetPurchaseNo(req, ref res);
        }

        /// <summary>
        /// 检测异步回调的支付通知
        /// </summary>
        /// <param name="info"></param> 
        /// <returns></returns>
        public static PurchaseNotify CheckNotify(CallBackPaymentInfo info)
        {
            return PaymentList[info.Type.ToString()].CheckNotify(info);
        }

        /// <summary>
        /// 撤费异步回调通知
        /// </summary>
        /// <param name="info"></param> 
        /// <returns></returns>
        public static CanceledPaymentInfo CheckCancelNotify(CallBackPaymentInfo info)
        {
            return PaymentList[info.Type.ToString()].CheckCancelNotify(info);
        }


        /// <summary>
        ///  是否支持撤单
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsEnableCancel(PaymentType type)
        {
            return PaymentList[type.ToString()].IsEnableCancel;
        }


        /// <summary>
        /// 尝试获取订单号
        /// </summary>
        /// <param name="type"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string TryGetOrderNo(PaymentType type,IDictionary<string,string>  param)
        {
            return PaymentList[type.ToString()].GetOrderNo(param);
        }

        /// <summary>
        /// 支付名称
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string PayTypeName(PaymentType type)
        {
            return PaymentList[type.ToString()].PayName();
        }
    }
}
