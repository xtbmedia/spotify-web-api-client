using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xtb.Spotify.Api.Interfaces.Services;

namespace Xtb.Spotify.Api.MvcClient.Controllers
{
    [Route("users")]
    public class UsersController : Controller
    {
        private IPlaylistService playlistService;

        public UsersController(IPlaylistService playlistService)
        {
            this.playlistService = playlistService;
        }

        [Route("{userId}/playlists")]
        public async Task<IActionResult> PlayLists(string userId)
        {
            var model = await playlistService.GetPlaylistsForUser(userId);
            return View(model);
        }
    }
}