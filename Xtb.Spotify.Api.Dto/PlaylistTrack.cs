using Newtonsoft.Json;
using System;
using Xtb.Spotify.Api.Dto.Interfaces;

namespace Xtb.Spotify.Api.Dto
{
    public class PlaylistTrack : IPageable
    {
        /// <summary>
        /// 	The date and time the track or episode was added.
        /// 	Note that some very old playlists may return null in this field.
        ///</summary>
        [JsonProperty("added_at")]
        public DateTime AddedAt { get; set; }

        /// <summary>
        /// The Spotify user who added the track or episode.
        /// Note that some very old playlists may return null in this field.
        /// </summary>
        [JsonProperty("added_by")]
        public PublicUser AddedBy { get; set; }

        /// <summary>
        /// Whether this track or episode is a local file or not.
        /// </summary>
        [JsonProperty("is_local")]
        public bool IsLocal { get; set; }

        /// <summary>
        /// Information about the track or episode.
        /// </summary>
        [JsonProperty("track")]
        // TODO: Support Episodes
        public Track Track { get; set; }
    }
}
