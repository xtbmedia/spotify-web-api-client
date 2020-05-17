using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xtb.Spotify.Api.Dto;

namespace Xtb.Sporify.Api.Interfaces.Services
{
    public interface IAlbumsService
    {
        Task<Album> GetAlbum(string albumId);
        Task<IEnumerable<SimpleTrack>> GetAlbumTracks(string albumId);
        Task<IEnumerable<SimpleAlbum>> GetAlbums(IEnumerable<string> albumsIds);
        Task<IEnumerable<SimpleTrack>> GetAlbumTracks(string albumId, int offset, int limit);
    }
}
