﻿using System;

/*
* 由自动生成工具完成
* 描述:撤费表
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Model.Db.Orders
{
    /// <summary>
    /// 撤费表
    /// </summary>
    [Serializable]
    public partial class OrdersCanceledDb
    {
        #region 订单编号
        private string _fOrderNo;

        /// <summary>
        /// 订单编号
        /// </summary>
        public  string  OrderNo
        {
            get
            {
                return  _fOrderNo;
            }
            set
            {
                  _fOrderNo = value;
            }
         }
        #endregion

        #region 订单时间
        private DateTime _fOrderTime;

        /// <summary>
        /// 订单时间
        /// </summary>
        public  DateTime  OrderTime
        {
            get
            {
                return  _fOrderTime;
            }
            set
            {
                  _fOrderTime = value;
            }
         }
        #endregion

        #region 订单金额
        private int _fOrderMoney;

        /// <summary>
        /// 订单金额
        /// </summary>
        public  int  OrderMoney
        {
            get
            {
                return  _fOrderMoney;
            }
            set
            {
                  _fOrderMoney = value;
            }
         }
        #endregion

        #region 停车场编码
        private string _fParkCode;

        /// <summary>
        /// 停车场编码
        /// </summary>
        public  string  ParkCode
        {
            get
            {
                return  _fParkCode;
            }
            set
            {
                  _fParkCode = value;
            }
         }
        #endregion

        #region 车牌号
        private string _fCarNo;

        /// <summary>
        /// 车牌号
        /// </summary>
        public  string  CarNo
        {
            get
            {
                return  _fCarNo;
            }
            set
            {
                  _fCarNo = value;
            }
         }
        #endregion

        #region 用户编号
        private string _fUserID;

        /// <summary>
        /// 用户编号
        /// </summary>
        public  string  UserID
        {
            get
            {
                return  _fUserID;
            }
            set
            {
                  _fUserID = value;
            }
         }
        #endregion

        #region 支付方式
        private int _fPaymentType;

        /// <summary>
        /// 支付方式
        /// </summary>
        public  int  PaymentType
        {
            get
            {
                return  _fPaymentType;
            }
            set
            {
                  _fPaymentType = value;
            }
         }
        #endregion

        #region 支付目的
        private int _fPurpose;

        /// <summary>
        /// 支付目的
        /// </summary>
        public  int  Purpose
        {
            get
            {
                return  _fPurpose;
            }
            set
            {
                  _fPurpose = value;
            }
         }
        #endregion

        #region 订单描述
        private string _fDescription;

        /// <summary>
        /// 订单描述
        /// </summary>
        public  string  Description
        {
            get
            {
                return  _fDescription;
            }
            set
            {
                  _fDescription = value;
            }
         }
        #endregion

        #region 订单流水
        private string _fQN;

        /// <summary>
        /// 订单流水
        /// </summary>
        public  string  QN
        {
            get
            {
                return  _fQN;
            }
            set
            {
                  _fQN = value;
            }
         }
        #endregion

        #region 撤费编号
        private string _fCancelOrderNo;

        /// <summary>
        /// 撤费编号
        /// </summary>
        public  string  CancelOrderNo
        {
            get
            {
                return  _fCancelOrderNo;
            }
            set
            {
                  _fCancelOrderNo = value;
            }
         }
        #endregion

        #region 处理状态
        private int _fIsProcessed;

        /// <summary>
        /// 处理状态
        /// </summary>
        public  int  IsProcessed
        {
            get
            {
                return  _fIsProcessed;
            }
            set
            {
                  _fIsProcessed = value;
            }
         }
        #endregion

        #region 校验状态(0未确认退费，1已确认退费)
        private int _fIsChecked;

        /// <summary>
        /// 校验状态(0未确认退费，1已确认退费)
        /// </summary>
        public  int  IsChecked
        {
            get
            {
                return  _fIsChecked;
            }
            set
            {
                  _fIsChecked = value;
            }
         }
        #endregion

        #region 优惠金额
        private int _fCouponMoney;

        /// <summary>
        /// 优惠金额
        /// </summary>
        public  int  CouponMoney
        {
            get
            {
                return  _fCouponMoney;
            }
            set
            {
                  _fCouponMoney = value;
            }
         }
        #endregion

        #region 停车场已经抵扣的金额(对账使用)
        private int _fDeduMoney;

        /// <summary>
        /// 停车场已经抵扣的金额(对账使用)
        /// </summary>
        public  int  DeduMoney
        {
            get
            {
                return  _fDeduMoney;
            }
            set
            {
                  _fDeduMoney = value;
            }
         }
        #endregion

        #region 总金额
        private int _fTotalMoney;

        /// <summary>
        /// 总金额
        /// </summary>
        public  int  TotalMoney
        {
            get
            {
                return  _fTotalMoney;
            }
            set
            {
                  _fTotalMoney = value;
            }
         }
        #endregion

        #region 优惠券编号
        private string _fCouponID;

        /// <summary>
        /// 优惠券编号
        /// </summary>
        public  string  CouponID
        {
            get
            {
                return  _fCouponID;
            }
            set
            {
                  _fCouponID = value;
            }
         }
        #endregion

        #region 公众号支付时用户ID
        private string _fOpenId;

        /// <summary>
        /// 公众号支付时用户ID
        /// </summary>
        public  string  OpenId
        {
            get
            {
                return  _fOpenId;
            }
            set
            {
                  _fOpenId = value;
            }
         }
        #endregion

        #region 客户端类型(IOS 1 Andriod 2 IOS WX 3 Andriod WX 4)
        private int _fClientType;

        /// <summary>
        /// 客户端类型(IOS 1 Andriod 2 IOS WX 3 Andriod WX 4)
        /// </summary>
        public  int  ClientType
        {
            get
            {
                return  _fClientType;
            }
            set
            {
                  _fClientType = value;
            }
         }
        #endregion

        #region 合作商Id
        private string _fPartnerId;

        /// <summary>
        /// 合作商Id
        /// </summary>
        public  string  PartnerId
        {
            get
            {
                return  _fPartnerId;
            }
            set
            {
                  _fPartnerId = value;
            }
         }
        #endregion

        #region 扩展标记
        private int _fExtre;

        /// <summary>
        /// 扩展标记
        /// </summary>
        public  int  Extre
        {
            get
            {
                return  _fExtre;
            }
            set
            {
                  _fExtre = value;
            }
         }
        #endregion

        #region 支付明细目的
        private int _fSubPurpose;

        /// <summary>
        /// 支付明细目的
        /// </summary>
        public  int  SubPurpose
        {
            get
            {
                return  _fSubPurpose;
            }
            set
            {
                  _fSubPurpose = value;
            }
         }
        #endregion

     }
}

