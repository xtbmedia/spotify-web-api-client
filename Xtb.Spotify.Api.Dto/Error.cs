using Newtonsoft.Json;

namespace Xtb.Spotify.Api.Dto
{
    [JsonObject("error")]
    public class ApiError
    {
        public string Error { get; set; }

        public string ErrorDescription { get; set; }
    }
}
