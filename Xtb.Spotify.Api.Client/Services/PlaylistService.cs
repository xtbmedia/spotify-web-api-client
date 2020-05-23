using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xtb.Spotify.Api.Client.Exceptions;
using Xtb.Spotify.Api.Dto;
using Xtb.Spotify.Api.Interfaces;
using Xtb.Spotify.Api.Interfaces.Services;

namespace Xtb.Spotify.Api.Client.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IHttpService httpService;
        private readonly ITokenService tokenService;
        private readonly string UserEndpoint = "https://api.spotify.com/v1/me";
        private readonly string PlaylistEndpoint = "https://api.spotify.com/v1/playlists";

        public PlaylistService(IHttpService httpService, ITokenService tokenService)
        {
            this.httpService = httpService;
            this.tokenService = tokenService;
        }

        public async Task<Page<SimplePlaylist>> GetPlaylistsForCurrentUser()
        {
            var builder = new UriBuilder($"{UserEndpoint}/playlists");
            var response = await httpService.GetAsync(builder.Uri, tokenService.ApiToken, CancellationToken.None);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var error = JsonConvert.DeserializeObject<ApiError>(content);
                throw new ApiException(response.StatusCode, error);
            }

            return JsonConvert.DeserializeObject<Page<SimplePlaylist>>(content);
        }

        public async Task<Playlist> GetPlaylist(string playlistId)
        {
            var builder = new UriBuilder($"{PlaylistEndpoint}/{playlistId}");
            var response = await httpService.GetAsync(builder.Uri, tokenService.ApiToken, CancellationToken.None);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var error = JsonConvert.DeserializeObject<ApiError>(content);
                throw new ApiException(response.StatusCode, error);
            }

            return JsonConvert.DeserializeObject<Playlist>(content);
        }
    }
}
