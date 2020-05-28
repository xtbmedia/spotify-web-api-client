using Newtonsoft.Json;
using System;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Xtb.Spotify.Api.Client.Providers;
using Xtb.Spotify.Api.Interfaces.Services;

namespace Xtb.Spotify.Api.Client.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient client;
        private readonly SerialisationSettingsProvider serialisationSettingsProvider;

        public HttpService(SerialisationSettingsProvider serialisationSettingsProvider)
        {
            client = new HttpClient();
            this.serialisationSettingsProvider = serialisationSettingsProvider;
        }

        public async Task<HttpResponseMessage> GetAsync(Uri requestUri, string authToken, CancellationToken cancellationToken)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            var response = await client.GetAsync(requestUri, cancellationToken);
            return response;
        }

        public Task<HttpResponseMessage> PostAsync<T>(Uri requestUri, string authToken, T body, CancellationToken cancellationToken)
        {
            var json = JsonConvert.SerializeObject(body, serialisationSettingsProvider.Settings);
            var content = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(json));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            return client.PostAsync(requestUri, content, cancellationToken);
        }

        public Task<HttpResponseMessage> PutAsync<T>(Uri requestUri, string authToken, T body, CancellationToken cancellationToken)
        {
            var json = JsonConvert.SerializeObject(body, serialisationSettingsProvider.Settings);
            var content = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(json));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            return client.PutAsync(requestUri, content, cancellationToken);
        }

        public Task<HttpResponseMessage> DeleteAsync<T>(Uri requestUri, string authToken, CancellationToken cancellationToken)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            return client.DeleteAsync(requestUri, cancellationToken);
        }
    }
}
