using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xtb.Spotify.Api.Client.Providers;
using Xtb.Spotify.Api.Client.Services;
using Xtb.Spotify.Api.Interfaces.Services;
using Xtb.Spotify.Api.Tests.Factories;
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
            var subject = PlaylistServiceFactory.CreateForUnitTest();
            var id = Guid.NewGuid().ToString();

            // Act
            var test = await subject.GetCoverImages(id);

            // Assert
            Assert.AreEqual($"{PlaylistServiceFactory.EndpointProvider.Playlists}/{id}/images", PlaylistServiceFactory.HttpService.Uri);
            Assert.AreEqual(PlaylistServiceFactory.TokenService.ApiToken, PlaylistServiceFactory.HttpService.Token);
        }

        [TestMethod]
        public async Task GetPlaylistsForCurrentUserRequestCorrect()
        {
            // Arrange
            var subject = PlaylistServiceFactory.CreateForUnitTest();

            // Act
            var test = await subject.GetPlaylistsForCurrentUser();

            // Assert
            Assert.AreEqual($"{PlaylistServiceFactory.EndpointProvider.Me}/playlists", PlaylistServiceFactory.HttpService.Uri);
            Assert.AreEqual(PlaylistServiceFactory.TokenService.ApiToken, PlaylistServiceFactory.HttpService.Token);
        }

        [TestMethod]
        public async Task GetPlaylistRequestCorrect()
        {
            // Arrange
            var subject = PlaylistServiceFactory.CreateForUnitTest();
            var id = Guid.NewGuid().ToString();

            // Act
            var test = await subject.GetPlaylist(id);

            // Assert
            Assert.AreEqual($"{PlaylistServiceFactory.EndpointProvider.Playlists}/{id}", PlaylistServiceFactory.HttpService.Uri);
            Assert.AreEqual(PlaylistServiceFactory.TokenService.ApiToken, PlaylistServiceFactory.HttpService.Token);
        }

        [TestMethod]
        public async Task GetPlaylistsForUserRequestCorrect()
        {
            // Arrange
            var subject = PlaylistServiceFactory.CreateForUnitTest();
            var id = Guid.NewGuid().ToString();

            // Act
            var test = await subject.GetPlaylistsForUser(id);

            // Assert
            Assert.AreEqual($"{PlaylistServiceFactory.EndpointProvider.Users}/{id}/playlists", PlaylistServiceFactory.HttpService.Uri);
            Assert.AreEqual(PlaylistServiceFactory.TokenService.ApiToken, PlaylistServiceFactory.HttpService.Token);
        }
    }
}
