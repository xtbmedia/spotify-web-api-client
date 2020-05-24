using Newtonsoft.Json;

namespace Xtb.Spotify.Api.Dto
{
    public class SimpleArtist
    {
        /// <summary>
        /// Known external URLs for this artist.
        /// </summary>
        [JsonProperty("external_urls")]
        public ExternalUrl ExternalUrls { get; set; }

        /// <summary>
        /// A link to the Web API endpoint providing full details of the artist.
        /// </summary>
        [JsonProperty("href")]
        public string Href { get; set; }

        /// <summary>
        /// The Spotify ID for the artist.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The name of the artist.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The object type: "artist"
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The Spotify URI for the artist.
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}
