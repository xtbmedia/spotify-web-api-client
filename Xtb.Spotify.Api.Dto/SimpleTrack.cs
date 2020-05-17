using System.Collections;
using System.Collections.Generic;
using Xtb.Spotify.Api.Dto.Interfaces;

namespace Xtb.Spotify.Api.Dto
{
    public class SimpleTrack : IPageable
    {
        public IEnumerable<SimpleArtist> Artists { get; set; }
        public string AvailableMarkets { get; set; }
        public int DiscNumber { get; set; }
        public int DurationMs { get; set; }
        public bool Explicit { get; set; }
        public IEnumerable<ExternalUrl> ExternalUrls {get;set;}
        public string Href { get; set; }
        public string Id { get; set; }
        public bool IsPlayable { get; set; }
        public TrackLink LinkedFrom { get; set; }
        public Restrictions Restrictions { get; set; }
        public string Name { get; set; }
        public string PreviewUrl { get; set; }
        public int TrackNumber { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
        public bool IsLocal { get; set; }
    }
}