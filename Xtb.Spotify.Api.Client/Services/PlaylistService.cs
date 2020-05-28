using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Cache;
using System.Threading;
using System.Threading.Tasks;
using Xtb.Spotify.Api.Client.Providers;
using Xtb.Spotify.Api.Dto;
using Xtb.Spotify.Api.Dto.Request;
using Xtb.Spotify.Api.Interfaces.Services;

namespace Xtb.Spotify.Api.Client.Services
{
    public class PlaylistService : SpotifyApiService, IPlaylistService
    {
        public PlaylistService(IHttpService httpService, ITokenReaderService tokenService, EndpointProvider endpointProvider, SerialisationSettingsProvider serialisationSettingsProvider)
            : base(httpService, tokenService, endpointProvider, serialisationSettingsProvider)
        {
        }

        public async Task<Page<SimplePlaylist>> GetPlaylistsForCurrentUser()
        {
            var builder = new UriBuilder($"{EndpointProvider.Me}/playlists");
            var response = await HttpService.GetAsync(builder.Uri, TokenService.ApiToken, CancellationToken.None);
            return await ProcessResponseMessage<Page<SimplePlaylist>>(response);
        }

        public async Task<Page<SimplePlaylist>> GetPlaylistsForUser(string userId)
        {
            var builder = new UriBuilder($"{EndpointProvider.Users}/{userId}/playlists");
            var response = await HttpService.GetAsync(builder.Uri, TokenService.ApiToken, CancellationToken.None);
            return await ProcessResponseMessage<Page<SimplePlaylist>>(response);
        }

        public async Task<Playlist> GetPlaylist(string playlistId)
        {
            var builder = new UriBuilder($"{EndpointProvider.Playlists}/{playlistId}");
            var response = await HttpService.GetAsync(builder.Uri, TokenService.ApiToken, CancellationToken.None);
            return await ProcessResponseMessage<Playlist>(response);
        }

        public async Task<Page<Track>> GetPlaylistItems(string playlistId)
        {
            var builder = new UriBuilder($"{EndpointProvider.Playlists}/{playlistId}/tracks");
            var response = await HttpService.GetAsync(builder.Uri, TokenService.ApiToken, CancellationToken.None);
            return await ProcessResponseMessage<Page<Track>>(response);            
        }

        public async Task<PlaylistSnapshot> AddPlaylistItems(string playlistId, IEnumerable<string> trackUris, int? position = null)
        {
            var builder = new UriBuilder($"{EndpointProvider.Playlists}/{playlistId}/tracks");
            var payload = new AddPlaylistItem { 
                Uris = trackUris,
                Position = position
            };
            var response = await HttpService.PostAsync(builder.Uri, TokenService.ApiToken, payload, CancellationToken.None);
            return await ProcessResponseMessage<PlaylistSnapshot>(response);
        }

        public async Task<bool> UpdatePlaylist(string playlistId, string name)
        {
            var builder = new UriBuilder($"{EndpointProvider.Playlists}/{playlistId}");
            var payload = new UpdatePlaylist
            {
                Name = name
            };
            var response = await HttpService.PutAsync(builder.Uri, TokenService.ApiToken, payload, CancellationToken.None);
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<Image>> GetCoverImages(string playlistId)
        {
            var builder = new UriBuilder($"{EndpointProvider.Playlists}/{playlistId}/images");
            var response = await HttpService.GetAsync(builder.Uri, TokenService.ApiToken, CancellationToken.None);
            return await ProcessResponseMessage<IEnumerable<Image>>(response);
        }

        public Task<bool> RemoveItems(string playlistId, IEnumerable<string> uris)
        {
            return RemoveItems(playlistId, null, uris.ToDictionary(k => k, v => (int?)null));
        }

        public Task<bool> RemoveItems(string playlistId, IDictionary<string, int?> trackRefs)
        {
            return RemoveItems(playlistId, null, trackRefs);
        }

        public Task<bool> RemoveItems(string playlistId, string snapshotId, IEnumerable<string> uris)
        {
            return RemoveItems(playlistId, snapshotId, uris.ToDictionary(k => k, v => (int?)null));
        }

        public async Task<bool> RemoveItems(string playlistId, string snapshotId, IDictionary<string, int?> trackRefs)
        {
            var builder = new UriBuilder($"{EndpointProvider.Playlists}/{playlistId}/tracks");
            var payload = new RemovePlaylistItem
            {
                Uris = trackRefs.Select(s => new PlaylistItemReference { Uri = s.Key, Position = s.Value }),
                SnaphotId = snapshotId
            };
            var response = await HttpService.DeleteAsync(builder.Uri, TokenService.ApiToken, payload, CancellationToken.None);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ReorderItems(string playlistId, int rangeStart, int insertBefore, int? rangeLength = null, string snapshotId = null)
        {
            var builder = new UriBuilder($"{EndpointProvider.Playlists}/{playlistId}/tracks");
            var payload = new ReorderPlaylistItems
            {
                SnapshotId = snapshotId,
                RangeStart = rangeStart,
                RangeLength = rangeLength,
                InsertBefore = insertBefore
            };
            var response = await HttpService.PutAsync(builder.Uri, TokenService.ApiToken, payload, CancellationToken.None);
            return response.IsSuccessStatusCode;
        }
    }
}
