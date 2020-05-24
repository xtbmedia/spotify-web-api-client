using System;
using System.Collections.Generic;
using System.Text;
using Xtb.Spotify.Api.Interfaces.Services;
using Xtb.Spotify.Api.Client.Services;
using Xtb.Spotify.Api.Client.Providers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddSpotifyApiClient(this IServiceCollection services)
        {
            // Transient Services
            services.AddTransient<IHttpService, HttpService>();
            services.AddTransient<IAlbumService, AlbumService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPlaylistService, PlaylistService>();

            // Singleton Services
            var tokenService = new TokenService();
            services.AddSingleton<ITokenReaderService>(tokenService); // Hack: Persistence
            services.AddSingleton<ITokenWriterService>(tokenService); // Hack: Persistence
            services.AddSingleton<EndpointProvider>(); // Unlikely to change without a restart
            services.AddSingleton<SerialisationSettingsProvider>(); // Unlikely to change without a restart
        }
    }
}
