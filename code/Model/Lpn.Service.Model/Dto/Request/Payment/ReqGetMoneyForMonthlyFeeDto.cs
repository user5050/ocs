using System;

namespace OneCoin.Service.Model.Dto.Request.Payment
{
    public class ReqGetMoneyForMonthlyFeeDto : RequestBaseDto
    {
        public string carno { get; set; }
        public string parkcode { get; set; }
        public DateTime tilldate { get; set; }
        public int renewalmonths { get; set; }
        public int renewalmonthsvip { get; set; } 
        public string SaleId { get; set; }
    }
}
