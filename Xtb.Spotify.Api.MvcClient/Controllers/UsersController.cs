using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xtb.Spotify.Api.Interfaces.Services;

namespace Xtb.Spotify.Api.MvcClient.Controllers
{
    [Route("users")]
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IPlaylistService playlistService;

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