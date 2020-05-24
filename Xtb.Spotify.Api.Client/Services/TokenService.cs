using Xtb.Spotify.Api.Interfaces.Services;

namespace Xtb.Spotify.Api.Client.Services
{
    public class TokenService : ITokenReaderService, ITokenWriterService
    {
        public string ApiToken { get; set; }
    }
}
