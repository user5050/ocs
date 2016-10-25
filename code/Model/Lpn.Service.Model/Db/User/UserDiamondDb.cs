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
    public partial class UserDiamondDb
    {
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

        #region 数量
        private int _fAmount;

        /// <summary>
        /// 数量
        /// </summary>
        public  int  Amount
        {
            get
            {
                return  _fAmount;
            }
            set
            {
                  _fAmount = value;
            }
         }
        #endregion

        #region 创建时间
        private DateTime _fRowTime;

        /// <summary>
        /// 创建时间
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

        #region 最近更新时间
        private DateTime _fLastUpdateTime;

        /// <summary>
        /// 最近更新时间
        /// </summary>
        public  DateTime  LastUpdateTime
        {
            get
            {
                return  _fLastUpdateTime;
            }
            set
            {
                  _fLastUpdateTime = value;
            }
         }
        #endregion

     }
}

