using Newtonsoft.Json;

namespace Xtb.Spotify.Api.Dto
{
    public class TrackLink
    {
        /// <summary>
        /// Known external URLs for this track.
        /// </summary>
        [JsonProperty("external_urls")]
        public ExternalUrl ExternalUrls { get; set; }

        /// <summary>
        /// A link to the Web API endpoint providing full details of the track.
        /// </summary>
        [JsonProperty("href")]
        public string Href { get; set; }

        /// <summary>
        /// The Spotify ID for the track.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The object type: “track”.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The Spotify URI for the track.
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}