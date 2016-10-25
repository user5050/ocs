using System;

/*
* 由自动生成工具完成
* 描述:
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Model.Db.User
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class UserContractDb
    {
        #region id
        private int _fId;

        /// <summary>
        /// id
        /// </summary>
        public  int  Id
        {
            get
            {
                return  _fId;
            }
            set
            {
                  _fId = value;
            }
         }
        #endregion

        #region 用户id
        private string _fUid;

        /// <summary>
        /// 用户id
        /// </summary>
        public  string  Uid
        {
            get
            {
                return  _fUid;
            }
            set
            {
                  _fUid = value;
            }
         }
        #endregion

        #region 收货人
        private string _fName;

        /// <summary>
        /// 收货人
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

        #region 联系方式
        private string _fContract;

        /// <summary>
        /// 联系方式
        /// </summary>
        public  string  Contract
        {
            get
            {
                return  _fContract;
            }
            set
            {
                  _fContract = value;
            }
         }
        #endregion

        #region 详细地址
        private string _fAddress;

        /// <summary>
        /// 详细地址
        /// </summary>
        public  string  Address
        {
            get
            {
                return  _fAddress;
            }
            set
            {
                  _fAddress = value;
            }
         }
        #endregion

        #region 是否默认地址
        private int _fIsDefault;

        /// <summary>
        /// 是否默认地址
        /// </summary>
        public  int  IsDefault
        {
            get
            {
                return  _fIsDefault;
            }
            set
            {
                  _fIsDefault = value;
            }
         }
        #endregion

        #region 时间
        private DateTime _fRowTime;

        /// <summary>
        /// 时间
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

