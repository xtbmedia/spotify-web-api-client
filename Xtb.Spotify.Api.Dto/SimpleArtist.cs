using System;
using System.Collections.Generic;
using System.Text;

namespace Xtb.Spotify.Api.Dto
{
    public class SimpleArtist
    {
        public IEnumerable<string> ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }
}
