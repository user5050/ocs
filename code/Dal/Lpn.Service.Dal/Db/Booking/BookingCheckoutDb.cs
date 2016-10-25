using System;

/*
* 由自动生成工具完成
* 描述:[booking_checkout]
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Booking
{
    /// <summary>
    /// [booking_checkout]
    /// </summary>
    [Serializable]
    public partial class BookingCheckoutDb
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

        #region Starttime
        private DateTime _fStarttime;

        /// <summary>
        /// Starttime
        /// </summary>
        public  DateTime  Starttime
        {
            get
            {
                return  _fStarttime;
            }
            set
            {
                  _fStarttime = value;
            }
         }
        #endregion

        #region Endtime
        private DateTime _fEndtime;

        /// <summary>
        /// Endtime
        /// </summary>
        public  DateTime  Endtime
        {
            get
            {
                return  _fEndtime;
            }
            set
            {
                  _fEndtime = value;
            }
         }
        #endregion

        #region Successcount
        private int _fSuccesscount;

        /// <summary>
        /// Successcount
        /// </summary>
        public  int  Successcount
        {
            get
            {
                return  _fSuccesscount;
            }
            set
            {
                  _fSuccesscount = value;
            }
         }
        #endregion

        #region Failcount
        private int _fFailcount;

        /// <summary>
        /// Failcount
        /// </summary>
        public  int  Failcount
        {
            get
            {
                return  _fFailcount;
            }
            set
            {
                  _fFailcount = value;
            }
         }
        #endregion

        #region Timeoutcount
        private int _fTimeoutcount;

        /// <summary>
        /// Timeoutcount
        /// </summary>
        public  int  Timeoutcount
        {
            get
            {
                return  _fTimeoutcount;
            }
            set
            {
                  _fTimeoutcount = value;
            }
         }
        #endregion

     }
}

