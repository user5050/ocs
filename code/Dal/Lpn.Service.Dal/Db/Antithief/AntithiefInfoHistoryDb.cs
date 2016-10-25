using System;

/*
* 由自动生成工具完成
* 描述:[Antithief_info_history]布撤防历史
* 作者:lee
* 创建时间:2016/7/6
*/
namespace Lpn.Service.Dal.Db.Antithief
{
    /// <summary>
    /// [Antithief_info_history]布撤防历史
    /// </summary>
    [Serializable]
    public partial class AntithiefInfoHistoryDb
    {
        #region 用户手机号
        private string _fUserName;

        /// <summary>
        /// 用户手机号
        /// </summary>
        public  string  UserName
        {
            get
            {
                return  _fUserName;
            }
            set
            {
                  _fUserName = value;
            }
         }
        #endregion

        #region 绑定车牌号
        private string _fBindCarNo;

        /// <summary>
        /// 绑定车牌号
        /// </summary>
        public  string  BindCarNo
        {
            get
            {
                return  _fBindCarNo;
            }
            set
            {
                  _fBindCarNo = value;
            }
         }
        #endregion

        #region 随机码
        private string _fVerifyingCode;

        /// <summary>
        /// 随机码
        /// </summary>
        public  string  VerifyingCode
        {
            get
            {
                return  _fVerifyingCode;
            }
            set
            {
                  _fVerifyingCode = value;
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

        #region 车辆入场时间
        private DateTime _fEntranceTime;

        /// <summary>
        /// 车辆入场时间
        /// </summary>
        public  DateTime  EntranceTime
        {
            get
            {
                return  _fEntranceTime;
            }
            set
            {
                  _fEntranceTime = value;
            }
         }
        #endregion

        #region 布防状态(已布防：True　已撤防：False)
        private int _fAntiThiefStatus;

        /// <summary>
        /// 布防状态(已布防：True　已撤防：False)
        /// </summary>
        public  int  AntiThiefStatus
        {
            get
            {
                return  _fAntiThiefStatus;
            }
            set
            {
                  _fAntiThiefStatus = value;
            }
         }
        #endregion

        #region 操作时间
        private DateTime _fOperationTime;

        /// <summary>
        /// 操作时间
        /// </summary>
        public  DateTime  OperationTime
        {
            get
            {
                return  _fOperationTime;
            }
            set
            {
                  _fOperationTime = value;
            }
         }
        #endregion

     }
}

