using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xtb.Spotify.Api.Interfaces;
using Xtb.Spotify.Api.Interfaces.Services;
using Xtb.Spotify.Api.Client.Exceptions;
using Xtb.Spotify.Api.Dto;

namespace Xtb.Spotify.Api.Client.Services
{
    public class TokenService : ITokenService
    {
        public string ApiToken { get; set; }
    }
}
