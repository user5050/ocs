using System;

/*
* 由自动生成工具完成
* 描述:[monthly_car_info]月租车辆信息
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Monthly
{
    /// <summary>
    /// [monthly_car_info]月租车辆信息
    /// </summary>
    [Serializable]
    public partial class MonthlyCarInfoDb
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

        #region 车牌号
        private string _fCarNo;

        /// <summary>
        /// 车牌号
        /// </summary>
        public  string  CarNo
        {
            get
            {
                return  _fCarNo;
            }
            set
            {
                  _fCarNo = value;
            }
         }
        #endregion

        #region 到期日期
        private DateTime _fTillDate;

        /// <summary>
        /// 到期日期
        /// </summary>
        public  DateTime  TillDate
        {
            get
            {
                return  _fTillDate;
            }
            set
            {
                  _fTillDate = value;
            }
         }
        #endregion

        #region 车位描述
        private string _fSpaceDesc;

        /// <summary>
        /// 车位描述
        /// </summary>
        public  string  SpaceDesc
        {
            get
            {
                return  _fSpaceDesc;
            }
            set
            {
                  _fSpaceDesc = value;
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

        #region 是否是由APP添加的车牌
        private int _fCreatedByApp;

        /// <summary>
        /// 是否是由APP添加的车牌
        /// </summary>
        public  int  CreatedByApp
        {
            get
            {
                return  _fCreatedByApp;
            }
            set
            {
                  _fCreatedByApp = value;
            }
         }
        #endregion

        #region 月租类型
        private int _fMonthlySort;

        /// <summary>
        /// 月租类型
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

        #region 储值用户余额
        private decimal _fBalanceMoney;

        /// <summary>
        /// 储值用户余额
        /// </summary>
        public  decimal  BalanceMoney
        {
            get
            {
                return  _fBalanceMoney;
            }
            set
            {
                  _fBalanceMoney = value;
            }
         }
        #endregion

        #region 是否为会员(0否1是)
        private int _fIsVip;

        /// <summary>
        /// 是否为会员(0否1是)
        /// </summary>
        public  int  IsVip
        {
            get
            {
                return  _fIsVip;
            }
            set
            {
                  _fIsVip = value;
            }
         }
        #endregion

     }
}

