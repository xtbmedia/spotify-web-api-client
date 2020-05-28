using Newtonsoft.Json;

namespace Xtb.Spotify.Api.Dto
{
    public class SimpleArtist
    {
        /// <summary>
        /// Known external URLs for this artist.
        /// </summary>
        public ExternalUrl ExternalUrls { get; set; }

        /// <summary>
        /// A link to the Web API endpoint providing full details of the artist.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// The Spotify ID for the artist.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the artist.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The object type: "artist"
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The Spotify URI for the artist.
        /// </summary>
        public string Uri { get; set; }
    }
}
