using System;

/*
* 由自动生成工具完成
* 描述:[appconfig_info]用户配置
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Appconfig
{
    /// <summary>
    /// [appconfig_info]用户配置
    /// </summary>
    [Serializable]
    public partial class AppconfigInfoDb
    {
        #region 分类
        private string _fClass;

        /// <summary>
        /// 分类
        /// </summary>
        public  string  Class
        {
            get
            {
                return  _fClass;
            }
            set
            {
                  _fClass = value;
            }
         }
        #endregion

        #region 用户编号
        private int _fUserID;

        /// <summary>
        /// 用户编号
        /// </summary>
        public  int  UserID
        {
            get
            {
                return  _fUserID;
            }
            set
            {
                  _fUserID = value;
            }
         }
        #endregion

        #region 键
        private string _fKey;

        /// <summary>
        /// 键
        /// </summary>
        public  string  Key
        {
            get
            {
                return  _fKey;
            }
            set
            {
                  _fKey = value;
            }
         }
        #endregion

        #region 值
        private string _fValue;

        /// <summary>
        /// 值
        /// </summary>
        public  string  Value
        {
            get
            {
                return  _fValue;
            }
            set
            {
                  _fValue = value;
            }
         }
        #endregion

     }
}

