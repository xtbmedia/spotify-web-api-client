using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Xtb.Spotify.Api.Interfaces.Services
{
    public interface IHttpService
    {
        Task<HttpResponseMessage> DeleteAsync<T>(Uri requestUri, string authToken, CancellationToken cancellationToken);
        Task<HttpResponseMessage> GetAsync(Uri requestUri, string authToken, CancellationToken cancellationToken);
        Task<HttpResponseMessage> PostAsync<T>(Uri requestUri, string authToken, T body, CancellationToken cancellationToken);
        Task<HttpResponseMessage> PutAsync<T>(Uri requestUri, string authToken, T body, CancellationToken cancellationToken);
    }
}
