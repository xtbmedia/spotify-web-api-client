using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using Xtb.Spotify.Api.Interfaces.Services;
using Xtb.Spotify.Api.MvcClient.Models;
using Xtb.Spotify.Api.Client.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Xtb.Spotify.Api.MvcClient.Controllers
{
    [Authorize(AuthenticationSchemes = "Spotify")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IAlbumService albumService;
        private readonly IUserService userService;
        private readonly ITokenService tokenService;

        public HomeController(ILogger<HomeController> logger,
                              IAlbumService albumService,
                              IUserService userService,
                              ITokenService tokenService, IServiceProvider sp)
        {
            this.logger = logger;
            this.albumService = albumService;
            this.userService = userService;
            this.tokenService = tokenService;
            sp.GetService<IAlbumService>();
        }

        public async Task<IActionResult> Index()
        {
            var album = await albumService.GetAlbum("6019qvnF1CbqBi32pAiV35");
            var user = await userService.GetCurrentUser(tokenService.ApiToken);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
