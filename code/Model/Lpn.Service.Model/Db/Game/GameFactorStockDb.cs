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
    public partial class GameFactorStockDb
    {
        #region StockNo
        private string _fStockNo;

        /// <summary>
        /// StockNo
        /// </summary>
        public  string  StockNo
        {
            get
            {
                return  _fStockNo;
            }
            set
            {
                  _fStockNo = value;
            }
         }
        #endregion

        #region StockName
        private string _fStockName;

        /// <summary>
        /// StockName
        /// </summary>
        public  string  StockName
        {
            get
            {
                return  _fStockName;
            }
            set
            {
                  _fStockName = value;
            }
         }
        #endregion

        #region RowTime
        private DateTime _fRowTime;

        /// <summary>
        /// RowTime
        /// </summary>
        public  DateTime  RowTime
        {
            get
            {
                return  _fRowTime;
            }
            set
            {
                  _fRowTime = value;
            }
         }
        #endregion

     }
}

