using System;
using System.Collections.Generic;
using System.Text;

namespace Xtb.Spotify.Api.Dto.Request
{
    public class CreatePlaylist
    {
        public string Name { get; set; }
        public bool? Collaborative { get; set; }
        public string Description { get; set; }

    }
}
