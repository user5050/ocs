using System;

/*
* 由自动生成工具完成
* 描述:停车场合作公司配置信息
* 作者:lee
* 创建时间:2016/10/25
*/
namespace OneCoin.Service.Model.Db.Partnerpay
{
    /// <summary>
    /// 停车场合作公司配置信息
    /// </summary>
    [Serializable]
    public partial class PartnerpayInfoDb
    {
        #region 编号
        private string _fId;

        /// <summary>
        /// 编号
        /// </summary>
        public  string  Id
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

        #region 合作商名称
        private string _fName;

        /// <summary>
        /// 合作商名称
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

        #region 说明
        private string _fRemark;

        /// <summary>
        /// 说明
        /// </summary>
        public  string  Remark
        {
            get
            {
                return  _fRemark;
            }
            set
            {
                  _fRemark = value;
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

