using System;
using System.Collections.Generic;
using System.Text;

namespace Xtb.Spotify.Api.Dto.Request
{
    public class RemovePlaylistItem
    {
        public string SnaphotId { get; set; }
        public IEnumerable<PlaylistItemReference> Uris { get; set; }
    }
}
