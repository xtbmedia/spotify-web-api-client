using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Xtb.Spotify.Api.Client.Exceptions;
using Xtb.Spotify.Api.Client.Providers;
using Xtb.Spotify.Api.Dto;
using Xtb.Spotify.Api.Interfaces.Services;

namespace Xtb.Spotify.Api.Client.Services
{
    public abstract class SpotifyApiService
    {
        protected IHttpService HttpService { get; }
        protected ITokenReaderService TokenService { get; }
        protected EndpointProvider EndpointProvider { get; }
        protected SerialisationSettingsProvider SerialisationSettingsProvider { get; }

        public SpotifyApiService(IHttpService httpService, ITokenReaderService tokenService, EndpointProvider endpointProvider, SerialisationSettingsProvider serialisationSettingsProvider)
        {
            HttpService = httpService;
            TokenService = tokenService;
            EndpointProvider = endpointProvider;
            SerialisationSettingsProvider = serialisationSettingsProvider;
        }

        protected async Task<T> ProcessResponseMessage<T>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var error = JsonConvert.DeserializeObject<ApiError>(content);
                throw new ApiException(response.StatusCode, error);
            }

            return JsonConvert.DeserializeObject<T>(content, SerialisationSettingsProvider.Settings);
        }
    }
}
