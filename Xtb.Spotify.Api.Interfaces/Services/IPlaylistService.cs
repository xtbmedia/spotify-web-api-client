using System.Collections.Generic;
using System.Threading.Tasks;
using Xtb.Spotify.Api.Dto;

namespace Xtb.Spotify.Api.Interfaces.Services
{
    public interface IPlaylistService
    {
        Task<Page<SimplePlaylist>> GetPlaylistsForCurrentUser();
        Task<Playlist> GetPlaylist(string playlistId);
        Task<Page<SimplePlaylist>> GetPlaylistsForUser(string userId);
        Task<Page<Track>> GetPlaylistItems(string playlistId);
        Task<PlaylistSnapshot> AddPlaylistItems(string playlistId, IEnumerable<string> uris, int? position = null);
        Task<bool> UpdatePlaylist(string playlistI, string playlistName);
        Task<IEnumerable<Image>> GetCoverImages(string playlistId);
        Task<bool> RemoveItems(string playlistId, IEnumerable<string> uris);
        Task<bool> RemoveItems(string playlistId, IDictionary<string, int?> trackRefs);
        Task<bool> RemoveItems(string playlistId, string snapshotId, IEnumerable<string> uris);
        Task<bool> RemoveItems(string playlistId, string snapshotId, IDictionary<string, int?> trackRefs);
    }
}
