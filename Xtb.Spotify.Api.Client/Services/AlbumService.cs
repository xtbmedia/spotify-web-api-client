using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xtb.Spotify.Api.Interfaces;
using Xtb.Spotify.Api.Interfaces.Services;
using Xtb.Spotify.Api.Client.Exceptions;
using Xtb.Spotify.Api.Dto;

namespace Xtb.Spotify.Api.Client.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IHttpService httpService;
        private readonly ITokenService tokenService;
        private readonly string ApiEndpoint = "https://api.spotify.com/v1/albums";

        public AlbumService(IHttpService httpService, ITokenService tokenService)
        {
            this.httpService = httpService;
            this.tokenService = tokenService;
        }

        public async Task<Album> GetAlbum(string albumId)
        {
            var builder = new UriBuilder($"{ApiEndpoint}/{albumId}");
            var response = await httpService.GetAsync(builder.Uri, tokenService.GetToken(), CancellationToken.None);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var error = JsonConvert.DeserializeObject<ApiError>(content);
                throw new ApiException(response.StatusCode, error);
            }

            return JsonConvert.DeserializeObject<Album>(content);
        }

        public async Task<IEnumerable<SimpleAlbum>> GetAlbums(IEnumerable<string> albumIds)
        {
            var builder = new UriBuilder($"{ApiEndpoint}/");
            var query = string.Join(',', albumIds);
            builder.Query = query;
            var response = await httpService.GetAsync(builder.Uri, tokenService.GetToken(), CancellationToken.None);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var error = JsonConvert.DeserializeObject<ApiError>(content);
                throw new ApiException(response.StatusCode, error);
            }

            return JsonConvert.DeserializeObject<IEnumerable<SimpleAlbum>>(content);
        }

        public Task<IEnumerable<SimpleTrack>> GetAlbumTracks(string albumId)
        {
            return GetAlbumTracks(albumId, 0, 20);
        }

        public async Task<IEnumerable<SimpleTrack>> GetAlbumTracks(string albumId, int offset, int limit)
        {
            var builder = new UriBuilder($"{ApiEndpoint}/{albumId}/tracks/");
            builder.Query = $"offset={offset}&limit={limit}";
            var response = await httpService.GetAsync(builder.Uri,tokenService.GetToken(), CancellationToken.None);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var error = JsonConvert.DeserializeObject<ApiError>(content);
                throw new ApiException(response.StatusCode, error);
            }

            return JsonConvert.DeserializeObject<IEnumerable<SimpleTrack>>(content);
        }
    }
}
