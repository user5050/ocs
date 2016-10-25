using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2015/10/21
*/
namespace Lpn.Service.Helper.Db
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class MultidescDb
    {
        #region UserID
        private int _fUserID;

        /// <summary>
        /// UserID
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

        #region Type
        private int _fType;

        /// <summary>
        /// Type
        /// </summary>
        public  int  Type
        {
            get
            {
                return  _fType;
            }
            set
            {
                  _fType = value;
            }
         }
        #endregion

        #region Desc
        private string _fDesc;

        /// <summary>
        /// Desc
        /// </summary>
        public  string  Desc
        {
            get
            {
                return  _fDesc;
            }
            set
            {
                  _fDesc = value;
            }
         }
        #endregion

     }
}

