using System.Collections.Generic;
using Newtonsoft.Json;

namespace OneCoin.Service.Model.Dto.Response.Product
{
    public class ResProductGameDetailDto
    {
        [JsonProperty("pi")]
        public ResProductInGameDto ProductInfo { get; set; }

        [JsonProperty("mb")]
        public List<GameMember> Members { get; set; }

        [JsonProperty("pw")]
        public Winer PreWiner { get; set; }

        [JsonProperty("sc")]
        public int ShowCnt { get; set; }
    }

    public class GameMember
    {
        [JsonProperty("h")]
        public string Head { get; set; }

        [JsonProperty("n")]
        public string Name { get; set; }

        [JsonProperty("t")]
        public string Time { get; set; }

        [JsonProperty("a")]
        public int Amount { get; set; }
    }

    public class Winer : WinerBase
    {   
        [JsonProperty("a")]
        public int Amount { get; set; }

        [JsonProperty("wn")]
        public string WinNo { get; set; }
    }

    public class WinerBase
    {
        [JsonProperty("h")]
        public string Head { get; set; }

        [JsonProperty("n")]
        public string Name { get; set; }

        [JsonProperty("t")]
        public string Time { get; set; }

        [JsonProperty("gn")]
        public string GameNo { get; set; } 
      
    }
}
