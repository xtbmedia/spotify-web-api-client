using System.Collections.Generic;

namespace Xtb.Spotify.Api.Dto
{
    public class TrackLink
    {
        public IEnumerable<ExternalUrl> ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }
}