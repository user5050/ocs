using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Setting
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class SettingHolidayDb
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

        #region Year
        private int _fYear;

        /// <summary>
        /// Year
        /// </summary>
        public  int  Year
        {
            get
            {
                return  _fYear;
            }
            set
            {
                  _fYear = value;
            }
         }
        #endregion

        #region Month
        private int _fMonth;

        /// <summary>
        /// Month
        /// </summary>
        public  int  Month
        {
            get
            {
                return  _fMonth;
            }
            set
            {
                  _fMonth = value;
            }
         }
        #endregion

        #region Holiday
        private string _fHoliday;

        /// <summary>
        /// Holiday
        /// </summary>
        public  string  Holiday
        {
            get
            {
                return  _fHoliday;
            }
            set
            {
                  _fHoliday = value;
            }
         }
        #endregion

     }
}

