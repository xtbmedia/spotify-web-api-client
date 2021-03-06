﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using Xtb.Spotify.Api.Dto.Interfaces;

namespace Xtb.Spotify.Api.Dto
{
    public class Playlist : IPageable
    {
        /// <summary>
        /// true if the owner allows other users to modify the playlist.
        /// </summary>
        public bool Collaborative { get; set; }

        /// <summary>
        /// The playlist description. Only returned for modified, verified playlists, otherwise null .
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Information about the followers of the playlist.
        /// </summary>
        public Followers Followers { get; set; }

        /// <summary>
        /// A link to the Web API endpoint providing full details of the playlist.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// The Spotify ID for the playlist.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Images for the playlist. The array may be empty or contain up to three 
        /// images. The images are returned by size in descending order. 
        /// See Working with Playlists.
        /// 
        /// Note: If returned, the source URL for the image(url)
        /// is temporary and will expire in less than a day.
        /// </summary>
        public IEnumerable<Image> Images { get; set; }

        /// <summary>
        /// The name of the playlist.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The user who owns the playlist
        /// </summary>
        public PublicUser Owner { get; set; }

        /// <summary>
        /// The playlist’s public/private status: true the playlist is public, 
        /// false the playlist is private, null the playlist status is not relevant. 
        /// 
        /// For more about public/private status, see Working with Playlists.
        /// </summary>
        public bool Public { get; set; }

        /// <summary>
        /// The version identifier for the current playlist.
        /// Can be supplied in other requests to target a specific playlist version
        /// </summary>
        public string SnapshotId { get; set; }

        /// <summary>
        /// A collection containing a link ( href ) to 
        /// the Web API endpoint where full details of the playlist’s tracks can be 
        /// retrieved, along with the total number of tracks 
        /// in the playlist. 
        /// 
        /// Note, a track object may be null. This can happen if a track 
        /// is no longer available.
        /// </summary>
        public Page<PlaylistTrack> Tracks { get; set; }

        /// <summary>
        /// The object type: “playlist”
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The Spotify URI for the playlist.
        /// </summary>
        public string Uri { get; set; }

    }
}
