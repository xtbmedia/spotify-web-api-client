using System;
using System.Collections.Generic;
using System.Text;

namespace Xtb.Spotify.Api.Dto.Request
{
    public class RemovePlaylistItems
    {
        public string SnaphotId { get; set; }
        public IEnumerable<PlaylistItemReference> Uris { get; set; }
    }
}
