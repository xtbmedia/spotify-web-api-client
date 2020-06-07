using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xtb.Spotify.Api.Interfaces.Services;

namespace Xtb.Spotify.Api.Client.Decorators
{
    public class BearerAuthenticationDecorator : IAuthenticationDecorator
    {
        private readonly string bearerAuthenticationType = "Bearer";

        public void Decorate(HttpRequestMessage requestMessage, string authToken)
        {
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue(bearerAuthenticationType, authToken);
        }
    }
}
