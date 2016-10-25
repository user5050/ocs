using System;

/*
* 由自动生成工具完成
* 描述:[park_out_info]车辆出场记录
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Park
{
    /// <summary>
    /// [park_out_info]车辆出场记录
    /// </summary>
    [Serializable]
    public partial class ParkOutInfoDb
    {
        #region 车辆出场记录编号
        private int _fID;

        /// <summary>
        /// 车辆出场记录编号
        /// </summary>
        public  int  ID
        {
            get
            {
                return  _fID;
            }
            set
            {
                  _fID = value;
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
        private string _fCarno;

        /// <summary>
        /// 车牌号
        /// </summary>
        public  string  Carno
        {
            get
            {
                return  _fCarno;
            }
            set
            {
                  _fCarno = value;
            }
         }
        #endregion

        #region 出场时间
        private DateTime _fEventTime;

        /// <summary>
        /// 出场时间
        /// </summary>
        public  DateTime  EventTime
        {
            get
            {
                return  _fEventTime;
            }
            set
            {
                  _fEventTime = value;
            }
         }
        #endregion

        #region 是否预约
        private int _fIsOrdered;

        /// <summary>
        /// 是否预约
        /// </summary>
        public  int  IsOrdered
        {
            get
            {
                return  _fIsOrdered;
            }
            set
            {
                  _fIsOrdered = value;
            }
         }
        #endregion

        #region 车辆照片
        private string _fCarImg;

        /// <summary>
        /// 车辆照片
        /// </summary>
        public  string  CarImg
        {
            get
            {
                return  _fCarImg;
            }
            set
            {
                  _fCarImg = value;
            }
         }
        #endregion

        #region 车辆照片
        private string _fCarnoImg;

        /// <summary>
        /// 车辆照片
        /// </summary>
        public  string  CarnoImg
        {
            get
            {
                return  _fCarnoImg;
            }
            set
            {
                  _fCarnoImg = value;
            }
         }
        #endregion

        #region 车辆内室照片
        private string _fCarCabImg;

        /// <summary>
        /// 车辆内室照片
        /// </summary>
        public  string  CarCabImg
        {
            get
            {
                return  _fCarCabImg;
            }
            set
            {
                  _fCarCabImg = value;
            }
         }
        #endregion

        #region 入场时间
        private DateTime _fStartTime;

        /// <summary>
        /// 入场时间
        /// </summary>
        public  DateTime  StartTime
        {
            get
            {
                return  _fStartTime;
            }
            set
            {
                  _fStartTime = value;
            }
         }
        #endregion

        #region 出场金额
        private decimal _fMoneyAll;

        /// <summary>
        /// 出场金额
        /// </summary>
        public  decimal  MoneyAll
        {
            get
            {
                return  _fMoneyAll;
            }
            set
            {
                  _fMoneyAll = value;
            }
         }
        #endregion

        #region 预约号
        private string _fBookingCode;

        /// <summary>
        /// 预约号
        /// </summary>
        public  string  BookingCode
        {
            get
            {
                return  _fBookingCode;
            }
            set
            {
                  _fBookingCode = value;
            }
         }
        #endregion

     }
}

