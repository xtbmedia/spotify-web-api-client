using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Xtb.Sporify.Api.Interfaces.Services
{
    public interface ITokenPostService
    {
        Task<HttpResponseMessage> PostTokenRequestAsync(string code, string redirectUri, string clientId, string clientSecret);
    }
}
