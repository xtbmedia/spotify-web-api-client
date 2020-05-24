using System;
using System.Threading;
using System.Threading.Tasks;
using Xtb.Spotify.Api.Client.Providers;
using Xtb.Spotify.Api.Dto;
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
    }
}
