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
        Task<bool> UpdatePlaylist(string id, string playlistName);
    }
}
