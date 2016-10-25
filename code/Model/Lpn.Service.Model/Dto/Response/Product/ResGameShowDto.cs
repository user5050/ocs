using System.Collections.Generic;
using Newtonsoft.Json;

namespace OneCoin.Service.Model.Dto.Response.Product
{
    public class ResGameShowDto
    {
        [JsonProperty("u")]
        public WinerBase User { get; set; }

        [JsonProperty("p")]
        public ResProductDto Product { get; set; }

        [JsonProperty("c")]
        public string Comment { get; set; }

        [JsonProperty("i")]
        public List<string> Imgs { get; set; }

    }
}
