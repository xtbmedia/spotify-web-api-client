using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xtb.Spotify.Api.Interfaces.Services;

namespace Xtb.Spotify.Api.MvcClient.Controllers
{
    [Authorize]
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
            var items = await playlistService.GetPlaylistItems(id);
            var images = await playlistService.GetCoverImages(id);
            return View(playlist);
        }

        public async Task<IActionResult> AddItem(string id, string trackUri)
        {
            await playlistService.AddItems(id, new List<string> { trackUri });
            return RedirectToAction(nameof(Item), new { id = id });
        }

        public async Task<IActionResult> Update(string id, string name)
        {
            await playlistService.UpdatePlaylist(id, name);
            return RedirectToAction(nameof(Item), new { id = id });
        }
    }
}