using System;

/*
* 由自动生成工具完成
* 描述:[booking_trace]
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Booking
{
    /// <summary>
    /// [booking_trace]
    /// </summary>
    [Serializable]
    public partial class BookingTraceDb
    {
        #region Id
        private int _fId;

        /// <summary>
        /// Id
        /// </summary>
        public  int  Id
        {
            get
            {
                return  _fId;
            }
            set
            {
                  _fId = value;
            }
         }
        #endregion

        #region Parkcode
        private string _fParkcode;

        /// <summary>
        /// Parkcode
        /// </summary>
        public  string  Parkcode
        {
            get
            {
                return  _fParkcode;
            }
            set
            {
                  _fParkcode = value;
            }
         }
        #endregion

        #region Bookingcode
        private string _fBookingcode;

        /// <summary>
        /// Bookingcode
        /// </summary>
        public  string  Bookingcode
        {
            get
            {
                return  _fBookingcode;
            }
            set
            {
                  _fBookingcode = value;
            }
         }
        #endregion

        #region State
        private int _fState;

        /// <summary>
        /// State
        /// </summary>
        public  int  State
        {
            get
            {
                return  _fState;
            }
            set
            {
                  _fState = value;
            }
         }
        #endregion

        #region Message
        private string _fMessage;

        /// <summary>
        /// Message
        /// </summary>
        public  string  Message
        {
            get
            {
                return  _fMessage;
            }
            set
            {
                  _fMessage = value;
            }
         }
        #endregion

        #region Eventtime
        private DateTime _fEventtime;

        /// <summary>
        /// Eventtime
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

     }
}

