using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xtb.Spotify.Api.Interfaces.Services;

namespace Xtb.Spotify.Api.MvcClient.Controllers
{
    public class PlaylistsController : Controller
    {
        private readonly IPlaylistService playlistService;

        public PlaylistsController(IPlaylistService playlistService)
        {
            this.playlistService = playlistService;
        }

        public async Task<IActionResult> Index()
        {
            var myPlaylists = await playlistService.GetPlaylistsForCurrentUser();
            return View(myPlaylists);
        }

        public async Task<IActionResult> Item(string id)
        {
            var playlist = await playlistService.GetPlaylist(id);
            return View(playlist);
        }
    }
}