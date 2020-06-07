using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xtb.Spotify.Api.Dto;
using Xtb.Spotify.Api.Interfaces.Services;
using Xtb.Spotify.Api.Tests.Factories;

namespace Xtb.Spotify.Api.Tests
{
    [TestClass]
    public class PlaylistServiceTests
    {
        [TestMethod]
        public async Task AddItemsRequestCorrect()
        {
            // Arrange
            var subject = PlaylistServiceFactory.CreateForUnitTest();
            var id = Guid.NewGuid().ToString();

            // Act
            var test = await subject.AddItems(id, new string[] { });

            // Assert
            Assert.AreEqual($"{PlaylistServiceFactory.EndpointProvider.Playlists}/{id}/tracks", PlaylistServiceFactory.HttpService.Uri);
            Assert.AreEqual(PlaylistServiceFactory.TokenService.ApiToken, PlaylistServiceFactory.HttpService.Token);
        }

        [TestMethod]
        public async Task UpdatePlaylistRequestCorrect()
        {
            // Arrange
            var subject = PlaylistServiceFactory.CreateForUnitTest();
            var id = Guid.NewGuid().ToString();

            // Act
            var test = await subject.UpdatePlaylist(id, "new name");

            // Assert
            Assert.AreEqual($"{PlaylistServiceFactory.EndpointProvider.Playlists}/{id}", PlaylistServiceFactory.HttpService.Uri);
            Assert.AreEqual(PlaylistServiceFactory.TokenService.ApiToken, PlaylistServiceFactory.HttpService.Token);
        }

        [TestMethod]
        public async Task CreatePlaylistRequestCorrect()
        {
            // Arrange
            var subject = PlaylistServiceFactory.CreateForUnitTest();
            var id = Guid.NewGuid().ToString();

            // Act
            var test = await subject.CreatePlaylist(id, "Test Playlist");

            // Assert
            Assert.AreEqual($"{PlaylistServiceFactory.EndpointProvider.Users}/{id}/playlists", PlaylistServiceFactory.HttpService.Uri);
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
        public async Task GetPlaylistItemsRequestCorrect()
        {
            // Arrange
            var subject = PlaylistServiceFactory.CreateForUnitTest();
            var id = Guid.NewGuid().ToString();

            // Act
            var test = await subject.GetPlaylistItems(id);

            // Assert
            Assert.AreEqual($"{PlaylistServiceFactory.EndpointProvider.Playlists}/{id}/tracks", PlaylistServiceFactory.HttpService.Uri);
            Assert.AreEqual(PlaylistServiceFactory.TokenService.ApiToken, PlaylistServiceFactory.HttpService.Token);
        }

        [TestMethod]
        public async Task RemoveItemsRequestCorrect_1()
        {
            // Arrange
            var subject = PlaylistServiceFactory.CreateForUnitTest();
            var id = Guid.NewGuid().ToString();

            // Act
            var test = await subject.RemoveItems(id, new string[] { });

            // Assert
            Assert.AreEqual($"{PlaylistServiceFactory.EndpointProvider.Playlists}/{id}/tracks", PlaylistServiceFactory.HttpService.Uri);
            Assert.AreEqual(PlaylistServiceFactory.TokenService.ApiToken, PlaylistServiceFactory.HttpService.Token);
        }

        [TestMethod]
        public async Task RemoveItemsRequestCorrect_2()
        {
            // Arrange
            var subject = PlaylistServiceFactory.CreateForUnitTest();
            var id = Guid.NewGuid().ToString();

            // Act
            var test = await subject.RemoveItems(id, new string[] { });

            // Assert
            Assert.AreEqual($"{PlaylistServiceFactory.EndpointProvider.Playlists}/{id}/tracks", PlaylistServiceFactory.HttpService.Uri);
            Assert.AreEqual(PlaylistServiceFactory.TokenService.ApiToken, PlaylistServiceFactory.HttpService.Token);
        }

        [TestMethod]
        public async Task RemoveItemsRequestCorrect_3()
        {
            // Arrange
            var subject = PlaylistServiceFactory.CreateForUnitTest();
            var id = Guid.NewGuid().ToString();

            // Act
            var test = await subject.RemoveItems(id, new string[] { });

            // Assert
            Assert.AreEqual($"{PlaylistServiceFactory.EndpointProvider.Playlists}/{id}/tracks", PlaylistServiceFactory.HttpService.Uri);
            Assert.AreEqual(PlaylistServiceFactory.TokenService.ApiToken, PlaylistServiceFactory.HttpService.Token);
        }

        [TestMethod]
        public async Task RemoveItemsRequestCorrect_4()
        {
            // Arrange
            var subject = PlaylistServiceFactory.CreateForUnitTest();
            var id = Guid.NewGuid().ToString();

            // Act
            var test = await subject.RemoveItems(id, new string[] { });

            // Assert
            Assert.AreEqual($"{PlaylistServiceFactory.EndpointProvider.Playlists}/{id}/tracks", PlaylistServiceFactory.HttpService.Uri);
            Assert.AreEqual(PlaylistServiceFactory.TokenService.ApiToken, PlaylistServiceFactory.HttpService.Token);
        }

        [TestMethod]
        public async Task ReorderItemsRequestCorrect()
        {
            // Arrange
            var subject = PlaylistServiceFactory.CreateForUnitTest();
            var id = Guid.NewGuid().ToString();

            // Act
            var test = await subject.ReorderItems(id, 3, 1);

            // Assert
            Assert.AreEqual($"{PlaylistServiceFactory.EndpointProvider.Playlists}/{id}/tracks", PlaylistServiceFactory.HttpService.Uri);
            Assert.AreEqual(PlaylistServiceFactory.TokenService.ApiToken, PlaylistServiceFactory.HttpService.Token);
        }

        [TestMethod]
        public async Task ReplaceItemsRequestCorrect()
        {
            // Arrange
            var subject = PlaylistServiceFactory.CreateForUnitTest();
            var id = Guid.NewGuid().ToString();

            // Act
            var test = await subject.ReplaceItems(id, new string[] { });

            // Assert
            Assert.AreEqual($"{PlaylistServiceFactory.EndpointProvider.Playlists}/{id}/tracks", PlaylistServiceFactory.HttpService.Uri);
            Assert.AreEqual(PlaylistServiceFactory.TokenService.ApiToken, PlaylistServiceFactory.HttpService.Token);
        }

        [TestMethod]
        public async Task  SetCoverImage()
        {
            // Arrange
            var subject = PlaylistServiceFactory.CreateForUnitTest();
            var id = Guid.NewGuid().ToString();

            // Act
            var test = await subject.SetCoverImage(id, new byte[] { });

            // Assert
            Assert.AreEqual($"{PlaylistServiceFactory.EndpointProvider.Playlists}/{id}/images", PlaylistServiceFactory.HttpService.Uri);
            Assert.AreEqual(PlaylistServiceFactory.TokenService.ApiToken, PlaylistServiceFactory.HttpService.Token);
        }
    }
}
