using System;

/*
* 由自动生成工具完成
* 描述:车辆进场记录表
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Parkin
{
    /// <summary>
    /// 车辆进场记录表
    /// </summary>
    [Serializable]
    public partial class ParkinInfoDb
    {
        #region 车辆进场记录编号
        private int _fID;

        /// <summary>
        /// 车辆进场记录编号
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

        #region 入场时间
        private DateTime _fEventtime;

        /// <summary>
        /// 入场时间
        /// </summary>
        public  DateTime  Eventtime
        {
            get
            {
                return  _fEventtime;
            }
            set
            {
                  _fEventtime = value;
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

        #region 车辆照片
        private string _fCarCabimg;

        /// <summary>
        /// 车辆照片
        /// </summary>
        public  string  CarCabimg
        {
            get
            {
                return  _fCarCabimg;
            }
            set
            {
                  _fCarCabimg = value;
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

