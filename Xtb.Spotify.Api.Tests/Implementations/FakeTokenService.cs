using System;
using System.Collections.Generic;
using System.Text;
using Xtb.Spotify.Api.Interfaces.Services;

namespace Xtb.Spotify.Api.Tests.Implementations
{
    public class FakeTokenService : ITokenReaderService, ITokenWriterService
    {
        public string ApiToken { get; set; }

        public FakeTokenService(string apiToken)
        {
            ApiToken = apiToken;
        }
    }
}
