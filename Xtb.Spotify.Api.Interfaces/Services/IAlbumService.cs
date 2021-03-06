﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Xtb.Spotify.Api.Dto;

namespace Xtb.Spotify.Api.Interfaces.Services
{
    public interface IAlbumService
    {
        Task<Album> GetAlbum(string albumId);
        Task<IEnumerable<SimpleTrack>> GetAlbumTracks(string albumId);
        Task<IEnumerable<SimpleAlbum>> GetAlbums(IEnumerable<string> albumsIds);
        Task<IEnumerable<SimpleTrack>> GetAlbumTracks(string albumId, int offset, int limit);
    }
}
