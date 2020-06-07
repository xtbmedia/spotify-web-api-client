using Newtonsoft.Json;
using System;
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
        private readonly string jsonContentType = "application/json";
        private readonly string byteArrayContentType = "image/jpeg";
        private readonly HttpClient client;
        private readonly SerialisationSettingsProvider serialisationSettingsProvider;
        private readonly IAuthenticationDecorator authenticationDecorator;

        public HttpService(SerialisationSettingsProvider serialisationSettingsProvider, IAuthenticationDecorator authenticationDecorator)
        {
            client = new HttpClient();
            this.serialisationSettingsProvider = serialisationSettingsProvider;
            this.authenticationDecorator = authenticationDecorator;
        }

        public Task<HttpResponseMessage> GetAsync(Uri requestUri, string authToken, CancellationToken cancellationToken)
        {
            var request = CreateRequest(HttpMethod.Get, requestUri, authToken);
            return client.SendAsync(request, HttpCompletionOption.ResponseContentRead, cancellationToken);
        }

        public Task<HttpResponseMessage> PostAsync<T>(Uri requestUri, string authToken, T body, CancellationToken cancellationToken)
        {
            var request = CreateRequest(HttpMethod.Post, requestUri, authToken, body);
            return client.SendAsync(request, HttpCompletionOption.ResponseContentRead, cancellationToken);
        }

        public Task<HttpResponseMessage> PutAsync<T>(Uri requestUri, string authToken, T body, CancellationToken cancellationToken)
        {
            var request = CreateRequest(HttpMethod.Put, requestUri, authToken, body);
            return client.SendAsync(request, HttpCompletionOption.ResponseContentRead, cancellationToken);
        }

        public Task<HttpResponseMessage> DeleteAsync<T>(Uri requestUri, string authToken, T body, CancellationToken cancellationToken)
        {
            var request = CreateRequest(HttpMethod.Delete, requestUri, authToken, body);
            return client.SendAsync(request, HttpCompletionOption.ResponseContentRead, cancellationToken);            
        }

        private HttpRequestMessage CreateRequest(HttpMethod method, Uri requestUri, string authToken)
        {
            var request = new HttpRequestMessage(method, requestUri);
            authenticationDecorator.Decorate(request, authToken);
            return request;
        }

        private HttpRequestMessage CreateRequest<T>(HttpMethod method, Uri requestUri, string authToken, T body)
        {
            var request = CreateRequest(method, requestUri, authToken);
            request.Content = CreatePayload(body);
            return request;
        }

        private ByteArrayContent CreatePayload<T>(T body)
        {
            // Do not initialise these variables, that way
            // the compilter will moan if we forget to
            // initialise them in one of the switch blocks
            // -----
            string payload;
            string contentType;
            // -----

            switch (body)
            {
                case Byte[] byteArray:
                    payload = Convert.ToBase64String(byteArray);
                    contentType = byteArrayContentType;
                    break;
                default:
                    payload = JsonConvert.SerializeObject(body, serialisationSettingsProvider.Settings);
                    contentType = jsonContentType;
                    break;
            }

            var content = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(payload));
            content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            return content;
        }
    }
}
