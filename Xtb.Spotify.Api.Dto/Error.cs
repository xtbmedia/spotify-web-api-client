using Newtonsoft.Json;

namespace Xtb.Spotify.Api.Dto
{
    [JsonObject("error")]
    public class ApiError
    {
        [JsonProperty("error")]
        public string Error { get; set; }
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }
}
