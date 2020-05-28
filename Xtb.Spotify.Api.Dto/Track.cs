using Newtonsoft.Json;
using System.Collections.Generic;
using Xtb.Spotify.Api.Dto.Interfaces;

namespace Xtb.Spotify.Api.Dto
{
    public class Track : IPageable
    {
        /// <summary>
        /// The album on which the track appears. The album object includes a
        /// link in href to full information about the album.
        /// </summary>
        public SimpleAlbum Album { get; set; }

        /// <summary>
        /// The artists who performed the track. Each artist object
        /// includes a link in href to more detailed information about the artist.
        /// </summary>
        public IEnumerable<SimpleArtist> Artists { get; set; }

        /// <summary>
        /// A list of the countries in which the track can be
        /// played, identified by their ISO 3166-1 alpha-2 code.
        /// </summary>
        public IEnumerable<string> AvailableMarkets { get; set; }

        /// <summary>
        /// The disc number (usually 1 unless the album
        /// consists of more than one disc).
        /// </summary>
        public int DiscNumber { get; set; }

        /// <summary>
        /// The track length in milliseconds.
        /// </summary>
        public int DurationMs { get; set; }

        /// <summary>
        /// Whether or not the track has explicit lyrics
        /// (true = yes it does; false = no it does not OR unknown).
        /// </summary>
        public bool Explicit { get; set; }

        /// <summary>
        /// Known external IDs for the track.
        /// </summary>
        public ExternalId ExternalIds { get; set; }

        /// <summary>
        /// External URLs for this track.
        /// </summary>
        public ExternalUrl ExternalUrls { get; set; }

        /// <summary>
        /// A link to the Web API endpoint providing full
        /// details of the track.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// The Spotify ID for the track.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Part of the response when Track Relinking is applied.
        /// If true , the track is playable in the given market.
        /// Otherwise false.
        /// </summary>
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
        public Restrictions Restrictions { get; set; }

        /// <summary>
        /// The name of the track.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The popularity of the track. The value will be between 0 and 100, 
        /// with 100 being the most popular.
        /// 
        /// The popularity of a track is a value between 0 and 100, with 100 
        /// being the most popular.The popularity is calculated by algorithm and 
        /// is based, in the most part, on the total number of plays the 
        /// track has had and how recent those plays are.
        /// 
        /// Generally speaking, songs that are being played a lot now will 
        /// have a higher popularity than songs that were played a lot in 
        /// the past. Duplicate tracks (e.g.the same track from a 
        /// single and an album) are rated independently.Artist and 
        /// album popularity is derived mathematically from track popularity.
        /// 	
        /// Note that the popularity value may lag actual 
        /// popularity by a few days: the value is not updated in real time.
        /// </summary>
        public int Popularity { get; set; }

        /// <summary>
        /// A URL to a 30 second preview (MP3 format) of the track.
        /// </summary>
        public string PreviewUrl { get; set; }

        /// <summary>
        /// The number of the track. If an album has several discs, the track number is the number on the specified disc.
        /// </summary>
        public int TrackNumber { get; set; }

        /// <summary>
        /// The object type: “track”.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The Spotify URI for the track.
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// Whether or not the track is from a local file.
        /// </summary>
        public bool IsLocal { get; set; }
    }
}