using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xtb.Spotify.Api.Client.Providers;
using Xtb.Spotify.Api.Client.Services;
using Xtb.Spotify.Api.Interfaces.Services;
using Xtb.Spotify.Api.Tests.Implementations;

namespace Xtb.Spotify.Api.Tests.Factories
{
    internal static class PlaylistServiceFactory
    {
        internal static SerialisationSettingsProvider SettingsProvider { get; }
        internal static EndpointProvider EndpointProvider { get; }
        internal static FakeHttpService HttpService { get; }
        internal static FakeTokenService TokenService { get; }

        static PlaylistServiceFactory()
        {
            SettingsProvider = new SerialisationSettingsProvider();
            EndpointProvider = new EndpointProvider();
            HttpService = new FakeHttpService(SettingsProvider);
            TokenService = new FakeTokenService(Guid.NewGuid().ToString());
        }

        internal static IPlaylistService CreateForUnitTest()
        {
            var result = new PlaylistService(HttpService, TokenService, EndpointProvider, SettingsProvider);

            return result;
        }
    }
}
