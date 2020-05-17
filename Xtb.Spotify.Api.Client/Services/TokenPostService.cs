using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xtb.Sporify.Api.Interfaces.Services;

namespace Xtb.Spotify.Api.Client.Services
{
    public class TokenPostService : ITokenPostService
    {
        public Task<HttpResponseMessage> PostTokenRequestAsync(string code, string redirectUri, string clientId, string clientSecret)
        {
            var uri = "https://accounts.spotify.com/api/token";
            var content = new FormUrlEncodedContent(new Dictionary<string, string> {
                {"grant_type", "authorization_code"},
                {"code", code},
                {"redirect_uri", redirectUri.ToLowerInvariant()}
            });

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("basic", System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}")));
            return httpClient.PostAsync(uri, content, CancellationToken.None);
        }

    }
}
