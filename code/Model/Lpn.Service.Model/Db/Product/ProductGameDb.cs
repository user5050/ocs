using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Model.Db.Product
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class ProductGameDb
    {
        #region 活动期号
        private string _fGameNo;

        /// <summary>
        /// 活动期号
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

        #region 商品id
        private string _fPid;

        /// <summary>
        /// 商品id
        /// </summary>
        public  string  Pid
        {
            get
            {
                return  _fPid;
            }
            set
            {
                  _fPid = value;
            }
         }
        #endregion

        #region 售价
        private int _fTotalMoney;

        /// <summary>
        /// 售价
        /// </summary>
        public  int  TotalMoney
        {
            get
            {
                return  _fTotalMoney;
            }
            set
            {
                  _fTotalMoney = value;
            }
         }
        #endregion

        #region 当前参与数
        private int _fUserCnt;

        /// <summary>
        /// 当前参与数
        /// </summary>
        public  int  UserCnt
        {
            get
            {
                return  _fUserCnt;
            }
            set
            {
                  _fUserCnt = value;
            }
         }
        #endregion

        #region 开始时间
        private DateTime _fRowTime;

        /// <summary>
        /// 开始时间
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

        #region 结束时间
        private DateTime _fEndTime;

        /// <summary>
        /// 结束时间
        /// </summary>
        public  DateTime  EndTime
        {
            get
            {
                return  _fEndTime;
            }
            set
            {
                  _fEndTime = value;
            }
         }
        #endregion

        #region 状态(0无效1进行中2揭晓中3公示中4已发货5待评价6结束
        private int _fState;

        /// <summary>
        /// 状态(0无效1进行中2揭晓中3公示中4已发货5待评价6结束
        /// </summary>
        public  int  State
        {
            get
            {
                return  _fState;
            }
            set
            {
                  _fState = value;
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

        #region 股票名称1
        private string _fStockName1;

        /// <summary>
        /// 股票名称1
        /// </summary>
        public  string  StockName1
        {
            get
            {
                return  _fStockName1;
            }
            set
            {
                  _fStockName1 = value;
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

        #region 股票名称2
        private string _fStockName2;

        /// <summary>
        /// 股票名称2
        /// </summary>
        public  string  StockName2
        {
            get
            {
                return  _fStockName2;
            }
            set
            {
                  _fStockName2 = value;
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

        #region 股票名称3
        private string _fStockName3;

        /// <summary>
        /// 股票名称3
        /// </summary>
        public  string  StockName3
        {
            get
            {
                return  _fStockName3;
            }
            set
            {
                  _fStockName3 = value;
            }
         }
        #endregion

     }
}

