using System;
using System.Threading;
using System.Threading.Tasks;
using Xtb.Spotify.Api.Client.Providers;
using Xtb.Spotify.Api.Dto;
using Xtb.Spotify.Api.Interfaces.Services;

namespace Xtb.Spotify.Api.Client.Services
{
    public class UserService : SpotifyApiService, IUserService
    {
        public UserService(IHttpService httpService, ITokenReaderService tokenService, EndpointProvider endpointProvider, SerialisationSettingsProvider serialisationSettingsProvider)
            : base(httpService, tokenService, endpointProvider, serialisationSettingsProvider)
        {
        }

        public async Task<PrivateUser> GetCurrentUser(string authToken)
        {
            var builder = new UriBuilder(EndpointProvider.Me);
            var response = await HttpService.GetAsync(builder.Uri, authToken, CancellationToken.None);
            return await ProcessResponseMessage<PrivateUser>(response);
        }

        public async Task<PublicUser> GetUser(string userId, string authToken)
        {
            var builder = new UriBuilder($"{EndpointProvider.Users}/{userId}");
            var response = await HttpService.GetAsync(builder.Uri, authToken, CancellationToken.None);
            return await ProcessResponseMessage<PublicUser>(response);
        }
    }
}
