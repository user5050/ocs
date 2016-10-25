using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class ParkmemberfeeDb
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

        #region FeePerMoon
        private decimal _fFeePerMoon;

        /// <summary>
        /// FeePerMoon
        /// </summary>
        public  decimal  FeePerMoon
        {
            get
            {
                return  _fFeePerMoon;
            }
            set
            {
                  _fFeePerMoon = value;
            }
         }
        #endregion

        #region FeePerSeason
        private decimal _fFeePerSeason;

        /// <summary>
        /// FeePerSeason
        /// </summary>
        public  decimal  FeePerSeason
        {
            get
            {
                return  _fFeePerSeason;
            }
            set
            {
                  _fFeePerSeason = value;
            }
         }
        #endregion

        #region FeePerYear
        private decimal _fFeePerYear;

        /// <summary>
        /// FeePerYear
        /// </summary>
        public  decimal  FeePerYear
        {
            get
            {
                return  _fFeePerYear;
            }
            set
            {
                  _fFeePerYear = value;
            }
         }
        #endregion

        #region FreeDays
        private int _fFreeDays;

        /// <summary>
        /// FreeDays
        /// </summary>
        public  int  FreeDays
        {
            get
            {
                return  _fFreeDays;
            }
            set
            {
                  _fFreeDays = value;
            }
         }
        #endregion

        #region ParkID
        private int _fParkID;

        /// <summary>
        /// ParkID
        /// </summary>
        public  int  ParkID
        {
            get
            {
                return  _fParkID;
            }
            set
            {
                  _fParkID = value;
            }
         }
        #endregion

     }
}

