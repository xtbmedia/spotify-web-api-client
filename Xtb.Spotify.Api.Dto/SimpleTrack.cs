using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using Xtb.Spotify.Api.Dto.Interfaces;

namespace Xtb.Spotify.Api.Dto
{
    public class SimpleTrack : IPageable
    {
        /// <summary>
        /// The artists who performed the track. Each artist object
        /// includes a link in href to more detailed information about the artist.
        /// </summary>
        [JsonProperty("artists")]
        public IEnumerable<SimpleArtist> Artists { get; set; }

        /// <summary>
        /// A list of the countries in which the track can be
        /// played, identified by their ISO 3166-1 alpha-2 code.
        /// </summary>
        [JsonProperty("available_markets")]
        public IEnumerable<string> AvailableMarkets { get; set; }

        /// <summary>
        /// The disc number (usually 1 unless the album
        /// consists of more than one disc).
        /// </summary>
        [JsonProperty("disc_number")]
        public int DiscNumber { get; set; }

        /// <summary>
        /// The track length in milliseconds.
        /// </summary>
        [JsonProperty("duration_ms")]
        public int DurationMs { get; set; }

        /// <summary>
        /// Whether or not the track has explicit lyrics
        /// (true = yes it does; false = no it does not OR unknown).
        /// </summary>
        [JsonProperty("explicit")]
        public bool Explicit { get; set; }

        /// <summary>
        /// External URLs for this track.
        /// </summary>
        [JsonProperty("external_urls")]
        public ExternalUrl ExternalUrls {get;set;}

        /// <summary>
        /// A link to the Web API endpoint providing full
        /// details of the track.
        /// </summary>
        [JsonProperty("href")]
        public string Href { get; set; }

        /// <summary>
        /// The Spotify ID for the track.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Part of the response when Track Relinking is applied.
        /// If true , the track is playable in the given market.
        /// Otherwise false.
        /// </summary>
        [JsonProperty("is_playable")]
        public bool IsPlayable { get; set; }

        /// <summary>
        /// Part of the response when Track Relinking is applied
        /// and is only part of the response if the track linking,
        /// in fact, exists. The requested track has been replaced
        /// with a different track.
        /// 
        /// The track in the linked_from object contains
        /// information about the originally requested track.
        /// </summary>
        [JsonProperty("linked_from")]
        public TrackLink LinkedFrom { get; set; }

        /// <summary>
        /// Part of the response when Track Relinking is applied,
        /// the original track is not available in the given market,
        /// and Spotify did not have any tracks to relink it with.
        /// 
        /// The track response will still contain metadata for the 
        /// original track, and a restrictions object containing
        /// the reason why the track is not available:
        /// "restrictions" : {"reason" : "market"}
        /// </summary>
        [JsonProperty("restrictions")]
        public Restrictions Restrictions { get; set; }

        /// <summary>
        /// The name of the track.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// A URL to a 30 second preview (MP3 format) of the track.
        /// </summary>
        [JsonProperty("preview_url")]
        public string PreviewUrl { get; set; }

        /// <summary>
        /// The number of the track. If an album has several discs, the track number is the number on the specified disc.
        /// </summary>
        [JsonProperty("track_number")]
        public int TrackNumber { get; set; }

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

        /// <summary>
        /// Whether or not the track is from a local file.
        /// </summary>
        [JsonProperty("is_local")]
        public bool IsLocal { get; set; }
    }
}