﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xtb.Spotify.Api.Interfaces.Services
{
    public interface ITokenReaderService
    {
        string ApiToken { get; }
    }
}