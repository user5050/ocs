using System;

/*
* 由自动生成工具完成
* 描述:[CountryLanguage]
* 作者:lee
* 创建时间:2015/10/21
*/
namespace Lpn.Service.Helper.Db
{
    /// <summary>
    /// [CountryLanguage]
    /// </summary>
    [Serializable]
    public partial class CountryLanguageDb
    {
        #region CountryCode
        private string _fCountryCode;

        /// <summary>
        /// CountryCode
        /// </summary>
        public  string  CountryCode
        {
            get
            {
                return  _fCountryCode;
            }
            set
            {
                  _fCountryCode = value;
            }
         }
        #endregion

        #region Language
        private string _fLanguage;

        /// <summary>
        /// Language
        /// </summary>
        public  string  Language
        {
            get
            {
                return  _fLanguage;
            }
            set
            {
                  _fLanguage = value;
            }
         }
        #endregion

        #region IsOfficial
        private string _fIsOfficial;

        /// <summary>
        /// IsOfficial
        /// </summary>
        public  string  IsOfficial
        {
            get
            {
                return  _fIsOfficial;
            }
            set
            {
                  _fIsOfficial = value;
            }
         }
        #endregion

        #region Percentage
        private double _fPercentage;

        /// <summary>
        /// Percentage
        /// </summary>
        public  double  Percentage
        {
            get
            {
                return  _fPercentage;
            }
            set
            {
                  _fPercentage = value;
            }
         }
        #endregion

     }
}

