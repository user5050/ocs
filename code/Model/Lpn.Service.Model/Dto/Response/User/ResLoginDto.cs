using Newtonsoft.Json;

namespace OneCoin.Service.Model.Dto.Response.User
{
    public class ResLoginDto
    {
        [JsonProperty("token")]
        public string Token { get; set; } 
        
        [JsonProperty("tel")]
        public string Tel { get; set; }

        [JsonProperty("mobile")]
        public string Mobile { get; set; }
        
        [JsonProperty("nickname")]
        public string NickName { get; set; }

       
        [JsonProperty("img")]
        public string Img { get; set; }

      
    }
}
