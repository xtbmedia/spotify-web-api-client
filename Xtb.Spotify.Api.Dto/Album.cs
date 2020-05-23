using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Xtb.Spotify.Api.Dto
{
    /// <summary>
    /// Album object as returned by Spotify web api v1
    /// </summary>
    public class Album
    {
        /// <summary>
        /// The type of the album: one of "album", "single", or "compilation".
        /// </summary>
        [JsonProperty("album_type")]
        public string AlbumType { get; set; }

        /// <summary>
        /// The artists of the album. Each artist object includes a link in 
        /// <see cref="Href"/> to more detailed information about the artist.
        /// </summary>
        [JsonProperty("artists")]
        public IEnumerable<SimpleArtist> Artists { get; set; }

        /// <summary>
        /// The markets in which the album is available: ISO 
        /// 3166-1 alpha-2 country codes. 
        /// 
        /// Note that an album is considered available in a market 
        /// when at least 1 of its tracks is available in that market.
        /// </summary>
        [JsonProperty("available_markets")]
        public IEnumerable<string> AvailableMarkets { get; set; }

        /// <summary>
        /// The copyright statements of the album.
        /// </summary>
        [JsonProperty("copyrights")]
        public IEnumerable<Copyright> Copyrights { get; set; }

        /// <summary>
        /// Known external IDs for the album.
        /// </summary>
        [JsonProperty("external_ids")]
        public ExternalId ExternalIds { get; set; }

        /// <summary>
        /// Known external URLs for this album.
        /// </summary>
        [JsonProperty("external_urls")]
        public ExternalUrl ExternalUrls { get; set; }

        /// <summary>
        /// A list of the genres used to classify the album. For 
        /// example: "Prog Rock", "Post-Grunge". (If not yet classified, 
        /// the array is empty.)
        /// </summary>
        [JsonProperty("genres")]
        public IEnumerable<string> Genres { get; set; }

        /// <summary>
        /// A link to the Web API endpoint providing full details of the album.
        /// </summary>
        [JsonProperty("href")]
        public string Href { get; set; }

        /// <summary>
        /// The Spotify ID for the album.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The cover art for the album in various sizes, widest first.
        /// </summary>
        [JsonProperty("images")]
        public IEnumerable<Image> Images { get; set; }

        /// <summary>
        /// The label for the album.
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        /// The name of the album. In case of an album 
        /// takedown, the value may be an empty string.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The popularity of the album. The value will be between 0 and 100,
        /// with 100 being the most popular. The popularity is calculated 
        /// from the popularity of the album’s individual tracks.
        /// </summary>
        [JsonProperty("popularity")]
        public int Popularity { get; set; }

        /// <summary>
        /// The date the album was first released, for example "1981-12-15".
        /// Depending on the precision, 
        /// it might be shown as "1981" or "1981-12".
        /// </summary>
        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// The precision with which release_date value is known: 
        /// "year" , "month" , or "day".
        /// </summary>
        [JsonProperty("release_date_precision")]
        public string ReleaseDatePreceision { get; set; }

        /// <summary>
        /// The tracks of the album.
        /// </summary>
        [JsonProperty("tracks")]
        public Page<SimpleTrack> Tracks { get; set; }

        /// <summary>
        /// The object type: “album”
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The Spotify URI for the album.
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}
