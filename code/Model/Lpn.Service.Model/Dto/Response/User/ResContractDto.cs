namespace OneCoin.Service.Model.Dto.Response.User
{
    public class ResContractDto
    {

        public int Id { get; set; }


        /// <summary>
        /// 收货人
        /// </summary>
        public string Name{ get; set; }
        
       
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Contract{ get; set; }
         
       
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address{ get; set; }
        

        /// <summary>
        /// 是否默认地址
        /// </summary>
        public int IsDefault{ get; set; } 
    }
}
