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
    public partial class GameComputeFactorDb
    {
        #region 期号
        private string _fGameNo;

        /// <summary>
        /// 期号
        /// </summary>
        public  string  GameNo
        {
            get
            {
                return  _fGameNo;
            }
            set
            {
                  _fGameNo = value;
            }
         }
        #endregion

        #region 上证指数
        private double _fSSEPrice;

        /// <summary>
        /// 上证指数
        /// </summary>
        public  double  SSEPrice
        {
            get
            {
                return  _fSSEPrice;
            }
            set
            {
                  _fSSEPrice = value;
            }
         }
        #endregion

        #region 股票代码1
        private string _fStockNo1;

        /// <summary>
        /// 股票代码1
        /// </summary>
        public  string  StockNo1
        {
            get
            {
                return  _fStockNo1;
            }
            set
            {
                  _fStockNo1 = value;
            }
         }
        #endregion

        #region 股票代码2
        private string _fStockNo2;

        /// <summary>
        /// 股票代码2
        /// </summary>
        public  string  StockNo2
        {
            get
            {
                return  _fStockNo2;
            }
            set
            {
                  _fStockNo2 = value;
            }
         }
        #endregion

        #region 股票代码3
        private string _fStockNo3;

        /// <summary>
        /// 股票代码3
        /// </summary>
        public  string  StockNo3
        {
            get
            {
                return  _fStockNo3;
            }
            set
            {
                  _fStockNo3 = value;
            }
         }
        #endregion

        #region 收盘价格1
        private double _fStockPrice1;

        /// <summary>
        /// 收盘价格1
        /// </summary>
        public  double  StockPrice1
        {
            get
            {
                return  _fStockPrice1;
            }
            set
            {
                  _fStockPrice1 = value;
            }
         }
        #endregion

        #region 收盘价格2
        private double _fStockPrice2;

        /// <summary>
        /// 收盘价格2
        /// </summary>
        public  double  StockPrice2
        {
            get
            {
                return  _fStockPrice2;
            }
            set
            {
                  _fStockPrice2 = value;
            }
         }
        #endregion

        #region 收盘价格3
        private double _fStockPrice3;

        /// <summary>
        /// 收盘价格3
        /// </summary>
        public  double  StockPrice3
        {
            get
            {
                return  _fStockPrice3;
            }
            set
            {
                  _fStockPrice3 = value;
            }
         }
        #endregion

        #region 结果
        private int _fResult;

        /// <summary>
        /// 结果
        /// </summary>
        public  int  Result
        {
            get
            {
                return  _fResult;
            }
            set
            {
                  _fResult = value;
            }
         }
        #endregion

     }
}

