using System;

/*
* 由自动生成工具完成
* 描述:[park_balance]停车场结算信息
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Park
{
    /// <summary>
    /// [park_balance]停车场结算信息
    /// </summary>
    [Serializable]
    public partial class ParkBalanceDb
    {
        #region 标识
        private string _fParkbalance_id;

        /// <summary>
        /// 标识
        /// </summary>
        public  string  Parkbalance_id
        {
            get
            {
                return  _fParkbalance_id;
            }
            set
            {
                  _fParkbalance_id = value;
            }
         }
        #endregion

        #region 结算时间
        private string _fBalancetime;

        /// <summary>
        /// 结算时间
        /// </summary>
        public  string  Balancetime
        {
            get
            {
                return  _fBalancetime;
            }
            set
            {
                  _fBalancetime = value;
            }
         }
        #endregion

        #region 结算金额
        private decimal _fBalancemoney;

        /// <summary>
        /// 结算金额
        /// </summary>
        public  decimal  Balancemoney
        {
            get
            {
                return  _fBalancemoney;
            }
            set
            {
                  _fBalancemoney = value;
            }
         }
        #endregion

        #region 周期
        private string _fCircle;

        /// <summary>
        /// 周期
        /// </summary>
        public  string  Circle
        {
            get
            {
                return  _fCircle;
            }
            set
            {
                  _fCircle = value;
            }
         }
        #endregion

        #region 结算起始时间
        private DateTime _fStarttime;

        /// <summary>
        /// 结算起始时间
        /// </summary>
        public  DateTime  Starttime
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

        #region 结算结束时间
        private DateTime _fEndtime;

        /// <summary>
        /// 结算结束时间
        /// </summary>
        public  DateTime  Endtime
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

        #region 本地对应记录
        private int _fBalance_id;

        /// <summary>
        /// 本地对应记录
        /// </summary>
        public  int  Balance_id
        {
            get
            {
                return  _fBalance_id;
            }
            set
            {
                  _fBalance_id = value;
            }
         }
        #endregion

        #region 停车场编码
        private string _fParkcode;

        /// <summary>
        /// 停车场编码
        /// </summary>
        public  string  Parkcode
        {
            get
            {
                return  _fParkcode;
            }
            set
            {
                  _fParkcode = value;
            }
         }
        #endregion

        #region 支付状态
        private int _fPaymentstatus;

        /// <summary>
        /// 支付状态
        /// </summary>
        public  int  Paymentstatus
        {
            get
            {
                return  _fPaymentstatus;
            }
            set
            {
                  _fPaymentstatus = value;
            }
         }
        #endregion

        #region 操作人员ID
        private int _fOperator;

        /// <summary>
        /// 操作人员ID
        /// </summary>
        public  int  Operator
        {
            get
            {
                return  _fOperator;
            }
            set
            {
                  _fOperator = value;
            }
         }
        #endregion

        #region Operatetime
        private DateTime _fOperatetime;

        /// <summary>
        /// Operatetime
        /// </summary>
        public  DateTime  Operatetime
        {
            get
            {
                return  _fOperatetime;
            }
            set
            {
                  _fOperatetime = value;
            }
         }
        #endregion

     }
}

