using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Security.Claims;
using Xtb.Spotify.Api.Interfaces.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SpotifyAuthenticationConfiguration
    {
        public static void AddSpotifyAuthentiation(this IServiceCollection services)
        {
            // TODO: Move the code back from startup.cs
        }
    }
}