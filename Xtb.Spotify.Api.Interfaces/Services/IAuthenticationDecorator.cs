using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Xtb.Spotify.Api.Interfaces.Services
{
    public interface IAuthenticationDecorator
    {
        public void Decorate(HttpRequestMessage requestMessage, string authToken);
    }
}
