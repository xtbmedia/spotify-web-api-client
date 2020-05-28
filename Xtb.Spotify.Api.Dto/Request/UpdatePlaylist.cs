using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xtb.Spotify.Api.Dto.Request
{
    public class UpdatePlaylist
    {
        /// <summary>
        /// Optional. The new name for the playlist, for example "My New Playlist Title".
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 	Optional. If true the playlist will be public, if false it will be private.
        /// </summary>
        public bool? Public { get; set; }

        /// <summary>
        /// Optional. If true , the playlist will become collaborative and other 
        /// users will be able to modify the playlist in their Spotify client. 
        /// 
        /// Note: You can only set collaborative to true on non-public playlists.
        /// </summary>
        public bool? Collaborative { get; set; }

        /// <summary>
        /// Optional. Value for playlist description as displayed in Spotify 
        /// Clients and in the Web API.
        /// </summary>
        public string Description { get; set; }
    }
}
