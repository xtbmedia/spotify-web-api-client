using System;
using System.Collections.Generic;
using System.Text;

namespace Xtb.Spotify.Api.Dto.Request
{
    public class ReplacePlaylistItems
    {
        public IEnumerable<string> Uris { get; set; }
    }
}
