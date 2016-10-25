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
    public partial class GameExpresDb
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

        #region 收件人
        private string _fName;

        /// <summary>
        /// 收件人
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

        #region 快递号
        private string _fExpressNo;

        /// <summary>
        /// 快递号
        /// </summary>
        public  string  ExpressNo
        {
            get
            {
                return  _fExpressNo;
            }
            set
            {
                  _fExpressNo = value;
            }
         }
        #endregion

        #region 快递图片
        private string _fImg;

        /// <summary>
        /// 快递图片
        /// </summary>
        public  string  Img
        {
            get
            {
                return  _fImg;
            }
            set
            {
                  _fImg = value;
            }
         }
        #endregion

        #region 快递商家
        private string _fSpName;

        /// <summary>
        /// 快递商家
        /// </summary>
        public  string  SpName
        {
            get
            {
                return  _fSpName;
            }
            set
            {
                  _fSpName = value;
            }
         }
        #endregion

        #region 发货时间
        private DateTime _fSendTime;

        /// <summary>
        /// 发货时间
        /// </summary>
        public  DateTime  SendTime
        {
            get
            {
                return  _fSendTime;
            }
            set
            {
                  _fSendTime = value;
            }
         }
        #endregion

        #region 1快递中2确认收货
        private int _fState;

        /// <summary>
        /// 1快递中2确认收货
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

     }
}

