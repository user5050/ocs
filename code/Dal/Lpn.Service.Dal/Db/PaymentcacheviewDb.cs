using System;

/*
* 由自动生成工具完成
* 描述:VIEW
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db
{
    /// <summary>
    /// VIEW
    /// </summary>
    [Serializable]
    public partial class PaymentcacheviewDb
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
        private decimal _fOrderMoney;

        /// <summary>
        /// 订单金额
        /// </summary>
        public  decimal  OrderMoney
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

        #region ParkCode
        private string _fParkCode;

        /// <summary>
        /// ParkCode
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

        #region ParkName
        private string _fParkName;

        /// <summary>
        /// ParkName
        /// </summary>
        public  string  ParkName
        {
            get
            {
                return  _fParkName;
            }
            set
            {
                  _fParkName = value;
            }
         }
        #endregion

        #region City
        private string _fCity;

        /// <summary>
        /// City
        /// </summary>
        public  string  City
        {
            get
            {
                return  _fCity;
            }
            set
            {
                  _fCity = value;
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

        #region 用户名
        private string _fUserName;

        /// <summary>
        /// 用户名
        /// </summary>
        public  string  UserName
        {
            get
            {
                return  _fUserName;
            }
            set
            {
                  _fUserName = value;
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

     }
}

