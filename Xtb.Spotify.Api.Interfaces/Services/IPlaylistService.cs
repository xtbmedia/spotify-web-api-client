using System.Collections.Generic;
using System.Threading.Tasks;
using Xtb.Spotify.Api.Dto;

namespace Xtb.Spotify.Api.Interfaces.Services
{
    public interface IPlaylistService
    {
        /// <summary>
        /// https://developer.spotify.com/documentation/web-api/reference/playlists/add-tracks-to-playlist/
        /// </summary>
        /// <param name="playlistId">The Spotify ID for the playlist.</param>
        /// <param name="uris">list of Spotify URIs</param>
        /// <param name="position">The position to insert the items, a zero-based index.</param>
        /// <returns>snapshot_id</returns>
        Task<PlaylistSnapshot> AddItems(string playlistId, IEnumerable<string> uris, int? position = null);
        
        Task<bool> UpdatePlaylist(string playlistId, string playlistName);
        Task<Playlist> CreatePlaylist(string userId, string name, bool? collaborative = false, string description = null);
        Task<Page<SimplePlaylist>> GetPlaylistsForCurrentUser();
        Task<Page<SimplePlaylist>> GetPlaylistsForUser(string userId);
        Task<IEnumerable<Image>> GetCoverImages(string playlistId);
        Task<Playlist> GetPlaylist(string playlistId);
        Task<Page<Track>> GetPlaylistItems(string playlistId);
        Task<bool> RemoveItems(string playlistId, IEnumerable<string> uris);
        Task<bool> RemoveItems(string playlistId, IDictionary<string, int?> trackRefs);
        Task<bool> RemoveItems(string playlistId, string snapshotId, IEnumerable<string> uris);
        Task<bool> RemoveItems(string playlistId, string snapshotId, IDictionary<string, int?> trackRefs);
        Task<bool> ReorderItems(string playlistId, int rangeStart, int insertBefore, string snapshotId = null, int? rangeLength = null);
        Task<bool> ReplaceItems(string playlistId, IEnumerable<string> uris);
        Task<bool> SetCoverImage(string playlistId, byte[] image);
    }
}
