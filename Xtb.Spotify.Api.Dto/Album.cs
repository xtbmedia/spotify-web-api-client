using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Xtb.Spotify.Api.Dto
{
    /// <summary>
    /// album object as returned by Spotify web api v1
    /// </summary>
    public class Album
    {
        public string AlbumType { get; set; }
        public IEnumerable<SimpleArtist> Artists { get; set; }
        public IEnumerable<string> AvailableMarkets { get; set; }
        public IEnumerable<Copyright> Copyrights { get; set; }
        public IEnumerable<ExternalId> ExternalIds { get; set; }
        public IEnumerable<ExternalUrl> ExternalUrls { get; set; }
        public IEnumerable<String> Genres { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public IEnumerable<Image> Images { get; set; }
        public string Label { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ReleaseDatePreceision { get; set; }
        public Restrictions Restrictions { get; set; }
        public IEnumerable<Page<SimpleTrack>> Tracks { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }
}
