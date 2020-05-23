using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xtb.Spotify.Api.Interfaces.Services;

namespace Xtb.Spotify.Api.MvcClient.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumService albumService;

        public AlbumsController(IAlbumService albumService)
        {
            this.albumService = albumService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Item(string id)
        {
            var model = await albumService.GetAlbum("6019qvnF1CbqBi32pAiV35");
            return View(model);
        }
    }
}