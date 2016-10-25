using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Model.Db.Game
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class GameStockInfoDb
    {
        #region Code
        private string _fCode;

        /// <summary>
        /// Code
        /// </summary>
        public  string  Code
        {
            get
            {
                return  _fCode;
            }
            set
            {
                  _fCode = value;
            }
         }
        #endregion

        #region Name
        private string _fName;

        /// <summary>
        /// Name
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

     }
}

