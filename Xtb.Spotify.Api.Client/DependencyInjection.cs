using System;
using System.Collections.Generic;
using System.Text;
using Xtb.Spotify.Api.Interfaces;
using Xtb.Spotify.Api.Interfaces.Services;
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
