using Newtonsoft.Json;

namespace Xtb.Spotify.Api.Dto
{
    public class ExternalUrl
    {
        /// <summary>
        /// The type of the URL, for example:
        /// - "spotify" - The Spotify URL for the object.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// An external, public URL to the object.
        /// </summary>
        public string Value { get; set; }
    }
}