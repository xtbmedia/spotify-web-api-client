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
        private readonly IUserService userService;
        private readonly ITokenService tokenService;

        public HomeController(ILogger<HomeController> logger, IUserService userService, ITokenService tokenService)
        {
            this.logger = logger;
            this.userService = userService;
            this.tokenService = tokenService;
        }

        public async Task<IActionResult> Index()
        {
            var token = tokenService.GetToken();
            if (token == null)
                return RedirectToAction("Auth", "Token");

            var user = await userService.GetCurrentUser(tokenService.GetToken());
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
