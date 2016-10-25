using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Monthly
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class MonthlyTimecarinfoDb
    {
        #region 停车场编码
        private string _fParkCode;

        /// <summary>
        /// 停车场编码
        /// </summary>
        public  string  ParkCode
        {
            get
            {
                return  _fParkCode;
            }
            set
            {
                  _fParkCode = value;
            }
         }
        #endregion

        #region 时段模式
        private int _fMonthlySort;

        /// <summary>
        /// 时段模式
        /// </summary>
        public  int  MonthlySort
        {
            get
            {
                return  _fMonthlySort;
            }
            set
            {
                  _fMonthlySort = value;
            }
         }
        #endregion

        #region 起始时间
        private string _fStarttime;

        /// <summary>
        /// 起始时间
        /// </summary>
        public  string  Starttime
        {
            get
            {
                return  _fStarttime;
            }
            set
            {
                  _fStarttime = value;
            }
         }
        #endregion

        #region 结束时间
        private string _fEndtime;

        /// <summary>
        /// 结束时间
        /// </summary>
        public  string  Endtime
        {
            get
            {
                return  _fEndtime;
            }
            set
            {
                  _fEndtime = value;
            }
         }
        #endregion

        #region 是否包含节假日。0-不包含,1-包含
        private int _fIsholiday;

        /// <summary>
        /// 是否包含节假日。0-不包含,1-包含
        /// </summary>
        public  int  Isholiday
        {
            get
            {
                return  _fIsholiday;
            }
            set
            {
                  _fIsholiday = value;
            }
         }
        #endregion

        #region 月租费用
        private double _fMonthFee;

        /// <summary>
        /// 月租费用
        /// </summary>
        public  double  MonthFee
        {
            get
            {
                return  _fMonthFee;
            }
            set
            {
                  _fMonthFee = value;
            }
         }
        #endregion

        #region 超时费率
        private string _fOverFee;

        /// <summary>
        /// 超时费率
        /// </summary>
        public  string  OverFee
        {
            get
            {
                return  _fOverFee;
            }
            set
            {
                  _fOverFee = value;
            }
         }
        #endregion

        #region 总车位
        private int _fParktotalLot;

        /// <summary>
        /// 总车位
        /// </summary>
        public  int  ParktotalLot
        {
            get
            {
                return  _fParktotalLot;
            }
            set
            {
                  _fParktotalLot = value;
            }
         }
        #endregion

        #region 可售车位
        private int _fParkLot;

        /// <summary>
        /// 可售车位
        /// </summary>
        public  int  ParkLot
        {
            get
            {
                return  _fParkLot;
            }
            set
            {
                  _fParkLot = value;
            }
         }
        #endregion

        #region 更新时间
        private DateTime _fUpdateTime;

        /// <summary>
        /// 更新时间
        /// </summary>
        public  DateTime  UpdateTime
        {
            get
            {
                return  _fUpdateTime;
            }
            set
            {
                  _fUpdateTime = value;
            }
         }
        #endregion

        #region 是否启用 0未启用 1启用
        private int _fIsValid;

        /// <summary>
        /// 是否启用 0未启用 1启用
        /// </summary>
        public  int  IsValid
        {
            get
            {
                return  _fIsValid;
            }
            set
            {
                  _fIsValid = value;
            }
         }
        #endregion

     }
}

