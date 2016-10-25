using System;

/*
* 由自动生成工具完成
* 描述:停车场支付功能控制开关
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Model.Db.Partnerpay
{
    /// <summary>
    /// 停车场支付功能控制开关
    /// </summary>
    [Serializable]
    public partial class PartnerpayControlDb
    {
        #region 停车场编号
        private string _fParkCode;

        /// <summary>
        /// 停车场编号
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

        #region 合作商ID
        private string _fPartnerId;

        /// <summary>
        /// 合作商ID
        /// </summary>
        public  string  PartnerId
        {
            get
            {
                return  _fPartnerId;
            }
            set
            {
                  _fPartnerId = value;
            }
         }
        #endregion

        #region 支持的支付方式,逗号分割
        private string _fEnablePlatforms;

        /// <summary>
        /// 支持的支付方式,逗号分割
        /// </summary>
        public  string  EnablePlatforms
        {
            get
            {
                return  _fEnablePlatforms;
            }
            set
            {
                  _fEnablePlatforms = value;
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

     }
}

