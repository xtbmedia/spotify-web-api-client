using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xtb.Spotify.Api.Client.Exceptions;
using Xtb.Spotify.Api.Dto;
using Xtb.Spotify.Api.Interfaces;
using Xtb.Spotify.Api.Interfaces.Services;

namespace Xtb.Spotify.Api.Client.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpService httpService;
        private readonly ITokenService tokenService;
        private readonly string ApiEndpoint = "https://api.spotify.com/v1";

        public UserService(IHttpService httpService, ITokenService tokenService)
        {
            this.httpService = httpService;
            this.tokenService = tokenService;
        }

        public async Task<PrivateUser> GetCurrentUser(string authToken)
        {
            var builder = new UriBuilder($"{ApiEndpoint}/me");
            var response = await httpService.GetAsync(builder.Uri, authToken, CancellationToken.None);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var error = string.IsNullOrEmpty(content) ? new ApiError() : JsonConvert.DeserializeObject<ApiError>(content);
                throw new ApiException(response.StatusCode, error);
            }

            return JsonConvert.DeserializeObject<PrivateUser>(content);
        }

        public async Task<PublicUser> GetUser(string userId, string authToken)
        {
            var builder = new UriBuilder($"{ApiEndpoint}/users/{userId}");
            var response = await httpService.GetAsync(builder.Uri, authToken, CancellationToken.None);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var error = JsonConvert.DeserializeObject<ApiError>(content);
                throw new ApiException(response.StatusCode, error);
            }

            return JsonConvert.DeserializeObject<PublicUser>(content);
        }
    }
}
