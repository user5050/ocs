using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Activity
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class ActivityDn97Db
    {
        #region 订单号
        private string _fOrderNo;

        /// <summary>
        /// 订单号
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

        #region 活动id
        private string _fActivityId;

        /// <summary>
        /// 活动id
        /// </summary>
        public  string  ActivityId
        {
            get
            {
                return  _fActivityId;
            }
            set
            {
                  _fActivityId = value;
            }
         }
        #endregion

        #region 活动名称
        private string _fActivityName;

        /// <summary>
        /// 活动名称
        /// </summary>
        public  string  ActivityName
        {
            get
            {
                return  _fActivityName;
            }
            set
            {
                  _fActivityName = value;
            }
         }
        #endregion

        #region 活动服务地址
        private string _fServiceAddr;

        /// <summary>
        /// 活动服务地址
        /// </summary>
        public  string  ServiceAddr
        {
            get
            {
                return  _fServiceAddr;
            }
            set
            {
                  _fServiceAddr = value;
            }
         }
        #endregion

        #region 姓名
        private string _fName;

        /// <summary>
        /// 姓名
        /// </summary>
        public  string  Name
        {
            get
            {
                return  _fName;
            }
            set
            {
                  _fName = value;
            }
         }
        #endregion

        #region 联系方式
        private string _fContract;

        /// <summary>
        /// 联系方式
        /// </summary>
        public  string  Contract
        {
            get
            {
                return  _fContract;
            }
            set
            {
                  _fContract = value;
            }
         }
        #endregion

        #region 车型
        private string _fCarType;

        /// <summary>
        /// 车型
        /// </summary>
        public  string  CarType
        {
            get
            {
                return  _fCarType;
            }
            set
            {
                  _fCarType = value;
            }
         }
        #endregion

        #region 车牌
        private string _fCarNo;

        /// <summary>
        /// 车牌
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

        #region 车色
        private string _fCarColor;

        /// <summary>
        /// 车色
        /// </summary>
        public  string  CarColor
        {
            get
            {
                return  _fCarColor;
            }
            set
            {
                  _fCarColor = value;
            }
         }
        #endregion

        #region 车位信息
        private string _fParkingLot;

        /// <summary>
        /// 车位信息
        /// </summary>
        public  string  ParkingLot
        {
            get
            {
                return  _fParkingLot;
            }
            set
            {
                  _fParkingLot = value;
            }
         }
        #endregion

        #region 付款备注
        private string _fPayDesc;

        /// <summary>
        /// 付款备注
        /// </summary>
        public  string  PayDesc
        {
            get
            {
                return  _fPayDesc;
            }
            set
            {
                  _fPayDesc = value;
            }
         }
        #endregion

        #region 备注
        private string _fRemark;

        /// <summary>
        /// 备注
        /// </summary>
        public  string  Remark
        {
            get
            {
                return  _fRemark;
            }
            set
            {
                  _fRemark = value;
            }
         }
        #endregion

        #region 时间
        private DateTime _fRowTime;

        /// <summary>
        /// 时间
        /// </summary>
        public  DateTime  RowTime
        {
            get
            {
                return  _fRowTime;
            }
            set
            {
                  _fRowTime = value;
            }
         }
        #endregion

        #region 是否已支付(1支付)
        private int _fIsPay;

        /// <summary>
        /// 是否已支付(1支付)
        /// </summary>
        public  int  IsPay
        {
            get
            {
                return  _fIsPay;
            }
            set
            {
                  _fIsPay = value;
            }
         }
        #endregion

     }
}

