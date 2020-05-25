using Microsoft.AspNetCore.Authentication;

namespace Xtb.Spotify.Api.Authentication
{
    public class SpotifyAuthenticationOptions : AuthenticationOptions
    {
        public string AuthorizationEndpoint { get; set; }
        public string CallbackPath { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string TokenEndpoint { get; set; }
        public string UserInformationEndpoint { get; set; }

        static SpotifyAuthenticationOptions()
        {
            Default = new SpotifyAuthenticationOptions
            {
                AuthorizationEndpoint = "https://accounts.spotify.com/authorize",
                CallbackPath = "/auth/grant",
                TokenEndpoint = "https://accounts.spotify.com/api/token",
                UserInformationEndpoint = "https://api.spotify.com/v1/me"
            };
        }

        internal static SpotifyAuthenticationOptions Default { get; private set; }
    }
}
