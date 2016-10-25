using System;

/*
* 由自动生成工具完成
* 描述:城市信息表
* 作者:lee
* 创建时间:2015/10/21
*/
namespace Lpn.Service.Helper.Db
{
    /// <summary>
    /// 城市信息表
    /// </summary>
    [Serializable]
    public partial class CityDb
    {
        #region ID
        private int _fID;

        /// <summary>
        /// ID
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

        #region 国家代码
        private string _fCountryCode;

        /// <summary>
        /// 国家代码
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

        #region District
        private string _fDistrict;

        /// <summary>
        /// District
        /// </summary>
        public  string  District
        {
            get
            {
                return  _fDistrict;
            }
            set
            {
                  _fDistrict = value;
            }
         }
        #endregion

        #region 主键
        private int _fPopulation;

        /// <summary>
        /// 主键
        /// </summary>
        public  int  Population
        {
            get
            {
                return  _fPopulation;
            }
            set
            {
                  _fPopulation = value;
            }
         }
        #endregion

     }
}

