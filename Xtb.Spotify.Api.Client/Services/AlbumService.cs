using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xtb.Spotify.Api.Client.Providers;
using Xtb.Spotify.Api.Dto;
using Xtb.Spotify.Api.Interfaces.Services;

namespace Xtb.Spotify.Api.Client.Services
{
    public class AlbumService : SpotifyApiService, IAlbumService
    {
        public AlbumService(IHttpService httpService, ITokenReaderService tokenService, EndpointProvider endpointProvider, SerialisationSettingsProvider serialisationSettingsProvider)
            : base(httpService, tokenService, endpointProvider, serialisationSettingsProvider)
        {
        }

        public async Task<Album> GetAlbum(string albumId)
        {
            var builder = new UriBuilder($"{EndpointProvider.Albums}/{albumId}");
            var response = await HttpService.GetAsync(builder.Uri, TokenService.ApiToken, CancellationToken.None);
            return await ProcessResponseMessage<Album>(response);
        }

        public async Task<IEnumerable<SimpleAlbum>> GetAlbums(IEnumerable<string> albumIds)
        {
            var builder = new UriBuilder($"{EndpointProvider.Albums}/");
            var query = string.Join(',', albumIds);
            builder.Query = query;
            var response = await HttpService.GetAsync(builder.Uri, TokenService.ApiToken, CancellationToken.None);
            return await ProcessResponseMessage<IEnumerable<SimpleAlbum>>(response);
        }

        public Task<IEnumerable<SimpleTrack>> GetAlbumTracks(string albumId)
        {
            return GetAlbumTracks(albumId, 0, 20);
        }

        public async Task<IEnumerable<SimpleTrack>> GetAlbumTracks(string albumId, int offset, int limit)
        {
            var builder = new UriBuilder($"{EndpointProvider.Albums}/{albumId}/tracks/");
            builder.Query = $"offset={offset}&limit={limit}";
            var response = await HttpService.GetAsync(builder.Uri, TokenService.ApiToken, CancellationToken.None);
            return await ProcessResponseMessage<IEnumerable<SimpleTrack>>(response);
        }
    }
}
