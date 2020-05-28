﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Xtb.Spotify.Api.Dto.Request
{
    public class AddPlaylistItem
    {
        /// <summary>
        /// Optional. A JSON array of the Spotify URIs to add, can be track or episode URIs.
        /// For example: {"uris": ["spotify:track:4iV5W9uYEdYUVa79Axb7Rh",
        /// "spotify:track:1301WleyT98MSxVHPZCA6M", "spotify:episode:512ojhOuo1ktJprKbVcKyQ"]}
        /// A maximum of 100 items can be added in one request.
        /// Note: if the uris parameter is present in the query string, any URIs listed
        /// here in the body will be ignored.
        /// </summary>
        public IEnumerable<string> Uris { get; set; }

        /// <summary>
        /// Optional. The position to insert the items, a zero-based index.
        /// For example, to insert the items in the first position:
        /// position=0 ; to insert the items in the third position: position=2.
        /// 
        /// If omitted, the items will be appended to the playlist. Items are added in the order
        /// they appear in the uris array. For example: {"uris": ["spotify:track:4iV5W9uYEdYUVa79Axb7Rh",
        /// "spotify:track:1301WleyT98MSxVHPZCA6M", 
        /// "spotify:episode:512ojhOuo1ktJprKbVcKyQ"], "position": 3}
        /// </summary>
        public int? Position { get; set; }
    }
}
