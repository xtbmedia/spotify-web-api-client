﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xtb.Sporify.Api.Interfaces.Services;
using Xtb.Spotify.Api.Client.Services;
using Xtb.Spotify.Api.Dto;

namespace Xtb.Sporify.Api.MvcClient.Controllers
{
    public class TokenController : Controller
    {
        private readonly ITokenService tokenService;

        public TokenController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        public IActionResult Auth()
        {
            return Redirect(tokenService.GetTokenRequestRedirectUri());
        }

        public async Task<IActionResult> GrantAsync(string code, string state)
        {
            var context = this.ControllerContext;
            var callbackUri = Url.Action(nameof(GrantAsync), context.ActionDescriptor.ControllerName, null, context.HttpContext.Request.Scheme);
            await tokenService.RequestToken(code);
            return RedirectToAction(nameof(Index), "home");
        }
    }
}