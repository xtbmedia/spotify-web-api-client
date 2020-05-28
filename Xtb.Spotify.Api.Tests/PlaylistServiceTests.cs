using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xtb.Spotify.Api.Client.Providers;
using Xtb.Spotify.Api.Client.Services;
using Xtb.Spotify.Api.Interfaces.Services;
using Xtb.Spotify.Api.Tests.Implementations;

namespace Xtb.Spotify.Api.Tests
{
    [TestClass]
    public class PlaylistServiceTests
    {
        [TestMethod]
        public async Task GetCoverImagesRequestCorrect()
        {
            // Arrange
            var settingsProvider = new SerialisationSettingsProvider();
            var endpointProvider = new EndpointProvider();
            var httpService = new FakeHttpService(settingsProvider);
            var tokenService = new FakeTokenService(Guid.NewGuid().ToString());
            var subject = new PlaylistService(httpService, tokenService, endpointProvider, settingsProvider);
            var id = Guid.NewGuid().ToString();

            // Act
            var test = await subject.GetCoverImages(id);

            // Assert
            Assert.AreEqual($"{endpointProvider.Playlists}/{id}/images", httpService.Uri);
            Assert.AreEqual(tokenService.ApiToken, httpService.Token);
        }

        [TestMethod]
        public async Task GetPlaylistsForCurrentUserRequestCorrect()
        {
            // Arrange
            var settingsProvider = new SerialisationSettingsProvider();
            var endpointProvider = new EndpointProvider();
            var httpService = new FakeHttpService(settingsProvider);
            var tokenService = new FakeTokenService(Guid.NewGuid().ToString());
            var subject = new PlaylistService(httpService, tokenService, endpointProvider, settingsProvider);

            // Act
            var test = await subject.GetPlaylistsForCurrentUser();

            // Assert
            Assert.AreEqual($"{endpointProvider.Me}/playlists", httpService.Uri);
            Assert.AreEqual(tokenService.ApiToken, httpService.Token);
        }

        [TestMethod]
        public async Task GetPlaylistRequestCorrect()
        {
            // Arrange
            var settingsProvider = new SerialisationSettingsProvider();
            var endpointProvider = new EndpointProvider();
            var httpService = new FakeHttpService(settingsProvider);
            var tokenService = new FakeTokenService(Guid.NewGuid().ToString());
            var subject = new PlaylistService(httpService, tokenService, endpointProvider, settingsProvider);
            var id = Guid.NewGuid().ToString();

            // Act
            var test = await subject.GetPlaylist(id);

            // Assert
            Assert.AreEqual($"{endpointProvider.Playlists}/{id}", httpService.Uri);
            Assert.AreEqual(tokenService.ApiToken, httpService.Token);
        }

        [TestMethod]
        public async Task GetPlaylistsForUserRequestCorrect()
        {
            // Arrange
            var settingsProvider = new SerialisationSettingsProvider();
            var endpointProvider = new EndpointProvider();
            var httpService = new FakeHttpService(settingsProvider);
            var tokenService = new FakeTokenService(Guid.NewGuid().ToString());
            var subject = new PlaylistService(httpService, tokenService, endpointProvider, settingsProvider);
            var id = Guid.NewGuid().ToString();

            // Act
            var test = await subject.GetPlaylistsForUser(id);

            // Assert
            Assert.AreEqual($"{endpointProvider.Users}/{id}/playlists", httpService.Uri);
            Assert.AreEqual(tokenService.ApiToken, httpService.Token);
        }
    }
}
