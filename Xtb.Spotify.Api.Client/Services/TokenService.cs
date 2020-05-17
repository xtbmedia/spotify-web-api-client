using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xtb.Sporify.Api.Interfaces;
using Xtb.Sporify.Api.Interfaces.Services;
using Xtb.Spotify.Api.Client.Exceptions;
using Xtb.Spotify.Api.Dto;

namespace Xtb.Spotify.Api.Client.Services
{
    public class TokenService : ITokenService
    {
        private readonly ITokenPostService tokenPostService;
        private readonly string clientId = "0b361c2fdde54ae5ba312d12019f1e10";
        private readonly string clientSecret = "9b796b357790441e8e724fa60fadc6a7";
        private readonly string state;

        private readonly string scopes = "";
        private readonly string authCallbackUrl = "https://localhost:44397/token/grant";

        private TokenGrant token;

        public TokenService(ITokenPostService tokenPostService)
        {
            this.tokenPostService = tokenPostService;
            state = Guid.NewGuid().ToString();
        }

        public string GetTokenRequestRedirectUri()
        {
            var scopes = "";
            var uri = $"https://accounts.spotify.com/authorize"
                + $"?response_type=code"
                + $"&client_id={clientId}"
                + (string.IsNullOrWhiteSpace(scopes) ? "" : $"&scopes={scopes}")
                + $"&redirect_uri={ authCallbackUrl.ToLowerInvariant() }";
            return uri;
        }

        public async Task RequestToken(string code)
        {
            var response = await tokenPostService.PostTokenRequestAsync(code, authCallbackUrl, clientId, clientSecret);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var error = JsonConvert.DeserializeObject<ApiError>(content);
                throw new ApiException(response.StatusCode, error);
            }

            token = JsonConvert.DeserializeObject<TokenGrant>(content);
        }

        public string GetToken()
        {
            return token?.AccessToken;
        }
    }
}
