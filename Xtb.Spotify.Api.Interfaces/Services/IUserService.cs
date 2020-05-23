﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xtb.Spotify.Api.Dto;

namespace Xtb.Spotify.Api.Interfaces.Services
{
    public interface IUserService
    {
        Task<PrivateUser> GetCurrentUser(string authToken);
        Task<PublicUser> GetUser(string userId, string authToken);
    }
}