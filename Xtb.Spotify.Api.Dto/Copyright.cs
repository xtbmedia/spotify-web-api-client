using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xtb.Spotify.Api.Dto
{
    public class Copyright
    {
        /// <summary>
        /// The copyright text for this album.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// The type of copyright: C = the copyright, P = the sound recording (performance) copyright.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
