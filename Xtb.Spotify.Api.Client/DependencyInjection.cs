using Xtb.Spotify.Api.Client.Decorators;
using Xtb.Spotify.Api.Client.Providers;
using Xtb.Spotify.Api.Client.Services;
using Xtb.Spotify.Api.Interfaces.Services;

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
            services.AddTransient<IAuthenticationDecorator, BearerAuthenticationDecorator>();

            // Singleton Services
            var tokenService = new TokenService();
            services.AddSingleton<ITokenReaderService>(tokenService); // Persistence - need to share implementation with ITokenWriterService
            services.AddSingleton<ITokenWriterService>(tokenService); // Persistence - need to share implementation with ITokenReaderService
            services.AddSingleton<EndpointProvider>(); // Unlikely to change without a restart
            services.AddSingleton<SerialisationSettingsProvider>(); // Unlikely to change without a restart
        }
    }
}
