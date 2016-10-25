using System;

/*
* 由自动生成工具完成
* 描述:泊位效率
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Rep
{
    /// <summary>
    /// 泊位效率
    /// </summary>
    [Serializable]
    public partial class RepParkefficDb
    {
        #region 泊位效率编号
        private int _fID;

        /// <summary>
        /// 泊位效率编号
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

        #region 泊位总数数
        private int _fLot_All;

        /// <summary>
        /// 泊位总数数
        /// </summary>
        public  int  Lot_All
        {
            get
            {
                return  _fLot_All;
            }
            set
            {
                  _fLot_All = value;
            }
         }
        #endregion

        #region 已使用数
        private int _fLot_Use;

        /// <summary>
        /// 已使用数
        /// </summary>
        public  int  Lot_Use
        {
            get
            {
                return  _fLot_Use;
            }
            set
            {
                  _fLot_Use = value;
            }
         }
        #endregion

        #region 空闲数
        private int _fLot_Free;

        /// <summary>
        /// 空闲数
        /// </summary>
        public  int  Lot_Free
        {
            get
            {
                return  _fLot_Free;
            }
            set
            {
                  _fLot_Free = value;
            }
         }
        #endregion

        #region 占有率
        private double _fLot_Effic;

        /// <summary>
        /// 占有率
        /// </summary>
        public  double  Lot_Effic
        {
            get
            {
                return  _fLot_Effic;
            }
            set
            {
                  _fLot_Effic = value;
            }
         }
        #endregion

        #region 预约泊位数
        private int _fLot_Vip;

        /// <summary>
        /// 预约泊位数
        /// </summary>
        public  int  Lot_Vip
        {
            get
            {
                return  _fLot_Vip;
            }
            set
            {
                  _fLot_Vip = value;
            }
         }
        #endregion

        #region 预约泊位已使用数
        private int _fLot_Vipuse;

        /// <summary>
        /// 预约泊位已使用数
        /// </summary>
        public  int  Lot_Vipuse
        {
            get
            {
                return  _fLot_Vipuse;
            }
            set
            {
                  _fLot_Vipuse = value;
            }
         }
        #endregion

        #region 预约泊位空闲数
        private int _fLot_Vipfree;

        /// <summary>
        /// 预约泊位空闲数
        /// </summary>
        public  int  Lot_Vipfree
        {
            get
            {
                return  _fLot_Vipfree;
            }
            set
            {
                  _fLot_Vipfree = value;
            }
         }
        #endregion

        #region 预约泊位占有率
        private double _fLot_Vipeffic;

        /// <summary>
        /// 预约泊位占有率
        /// </summary>
        public  double  Lot_Vipeffic
        {
            get
            {
                return  _fLot_Vipeffic;
            }
            set
            {
                  _fLot_Vipeffic = value;
            }
         }
        #endregion

        #region 统计时间
        private DateTime _fEventTime;

        /// <summary>
        /// 统计时间
        /// </summary>
        public  DateTime  EventTime
        {
            get
            {
                return  _fEventTime;
            }
            set
            {
                  _fEventTime = value;
            }
         }
        #endregion

     }
}

