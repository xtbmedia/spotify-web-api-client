using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
    }
}
