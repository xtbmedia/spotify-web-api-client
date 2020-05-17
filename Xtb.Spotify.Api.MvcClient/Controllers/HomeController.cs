using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using Xtb.Spotify.Api.Interfaces.Services;
using Xtb.Spotify.Api.MvcClient.Models;
using Xtb.Spotify.Api.Client.Services;

namespace Xtb.Spotify.Api.MvcClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IAlbumsService albumsService;
        private readonly ITokenService tokenService;

        public HomeController(ILogger<HomeController> logger, IAlbumsService albumsService, ITokenService tokenService)
        {
            this.logger = logger;
            this.albumsService = albumsService;
            this.tokenService = tokenService;
        }

        public IActionResult Index()
        {
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
