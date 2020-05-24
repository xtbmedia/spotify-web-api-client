using System;
using System.Collections.Generic;

namespace Xtb.Spotify.Api.Dto
{
    public class SimpleAlbum
    {
        public string AlbumGroup { get; set; }
        public string AlbumType { get; set; }
        public IEnumerable<SimpleArtist> Artists { get; set; }
        public IEnumerable<string> AvailableMarkets { get; set; }
        public ExternalUrl ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public IEnumerable<Image> Images { get; set; }
        public string Label { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ReleaseDatePreceision { get; set; }
        public Restrictions Restrictions { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }
}
