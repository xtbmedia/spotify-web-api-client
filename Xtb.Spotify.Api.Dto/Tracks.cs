using Newtonsoft.Json;

namespace Xtb.Spotify.Api.Dto
{
    public class Tracks
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
