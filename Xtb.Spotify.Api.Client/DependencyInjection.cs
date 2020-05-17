using System;
using System.Collections.Generic;
using System.Text;
using Xtb.Sporify.Api.Interfaces;
using Xtb.Sporify.Api.Interfaces.Services;
using Xtb.Spotify.Api.Client.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddSpotifyApiClient(this IServiceCollection services)
        {
            services.AddTransient<IHttpService, HttpService>();
            services.AddTransient<IAlbumsService, AlbumsService>();
            services.AddSingleton<ITokenService, TokenService>();
            services.AddTransient<ITokenPostService, TokenPostService>();
        }
    }
}
