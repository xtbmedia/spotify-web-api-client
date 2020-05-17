using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xtb.Sporify.Api.Interfaces;
using Xtb.Sporify.Api.Interfaces.Services;

namespace Xtb.Spotify.Api.Client.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient client;
        private readonly ITokenService tokenService;

        public HttpService()
        {
            client = new HttpClient();
        }

        public Task<HttpResponseMessage> GetAsync(Uri requestUri, CancellationToken cancellationToken)
        {
            client.DefaultRequestHeaders.Add("x", tokenService.GetToken());
            return client.GetAsync(requestUri, cancellationToken);
        }

        public Task<HttpResponseMessage> PostAsync<T>(Uri requestUri, T body, CancellationToken cancellationToken)
        {
            var json = JsonConvert.SerializeObject(body);
            var content = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(json));
            return client.PostAsync(requestUri, content, cancellationToken);
        }

        public Task<HttpResponseMessage> PutAsync<T>(Uri requestUri, T body, CancellationToken cancellationToken)
        {
            var json = JsonConvert.SerializeObject(body);
            var content = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(json));
            return client.PutAsync(requestUri, content, cancellationToken);
        }

        public Task<HttpResponseMessage> DeleteAsync<T>(Uri requestUri, CancellationToken cancellationToken)
        {
            return client.DeleteAsync(requestUri, cancellationToken);
        }
    }
}
