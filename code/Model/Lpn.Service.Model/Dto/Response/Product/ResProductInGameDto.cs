using System.Collections.Generic;

namespace OneCoin.Service.Model.Dto.Response.Product
{
    public class ResProductInGameDto : ResProductDto
    { 
        public List<string> Imgs { get; set; }
        public int Total { get; set; }
        public int Cur { get; set; }
        public string GameNo { get; set; }
        public int BuyTotalCnt { get; set; }
        public string WinNo { get; set; }
    }

    public class ResProductDto
    {
        public string Name { get; set; }
        public string Img { get; set; }  
    }


    public class ResProductWaitForDto
    {
        public ResProductInGameDto Product { get; set; }

        public Winer Winer { get; set; }
    }


    public class ResProductWinDto : ResProductWaitForDto
    {
        public ResExpresDto Exress { get; set; }
    }

    public class ResExpresDto
    {
        public string  Name { get; set; }
        public string Address { get; set; }
        public int State { get; set; } 
    }
}
