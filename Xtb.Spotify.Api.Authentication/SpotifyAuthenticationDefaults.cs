using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Xtb.Spotify.Api.Authentication
{
    public static class SpotifyAuthenticationDefaults
    {
        private static AuthorizationPolicy authorizationPolicy;
        
        public static string AuthenticationScheme = "Spotify";
        public static AuthorizationPolicy AuthorizationPolicy => authorizationPolicy;

        static SpotifyAuthenticationDefaults()
        {
            authorizationPolicy = CreateAuthorizationPolicy();
        }

        private static AuthorizationPolicy CreateAuthorizationPolicy() => new AuthorizationPolicy(
            new List<IAuthorizationRequirement> { new ClaimsAuthorizationRequirement(ClaimTypes.NameIdentifier, null) },
            new List<string> { SpotifyAuthenticationDefaults.AuthenticationScheme }
        );
    }
}

