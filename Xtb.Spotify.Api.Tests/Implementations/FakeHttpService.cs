using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xtb.Spotify.Api.Client.Providers;
using Xtb.Spotify.Api.Interfaces.Services;

namespace Xtb.Spotify.Api.Tests.Implementations
{
    internal class FakeHttpService : IHttpService
    {
        public string Uri { get; private set; }
        public string Body { get; private set; }
        public string Token { get; private set; }

        private SerialisationSettingsProvider serialisationSettingsProvider;

        public FakeHttpService(SerialisationSettingsProvider serialisationSettingsProvider)
        {
            this.serialisationSettingsProvider = serialisationSettingsProvider;
        }

        public Task<HttpResponseMessage> DeleteAsync<T>(Uri requestUri, string authToken, T body, CancellationToken cancellationToken)
        {
            this.Uri = requestUri.ToString();
            this.Body = JsonConvert.SerializeObject(body, serialisationSettingsProvider.Settings);
            this.Token = authToken;
            return FakeResponse(requestUri);
        }

        public Task<HttpResponseMessage> GetAsync(Uri requestUri, string authToken, CancellationToken cancellationToken)
        {
            this.Uri = requestUri.ToString();
            this.Token = authToken;
            return FakeResponse(requestUri);
        }

        public Task<HttpResponseMessage> PostAsync<T>(Uri requestUri, string authToken, T body, CancellationToken cancellationToken)
        {
            this.Uri = requestUri.ToString();
            this.Body = JsonConvert.SerializeObject(body, serialisationSettingsProvider.Settings);
            this.Token = authToken;
            return FakeResponse(requestUri);
        }

        public Task<HttpResponseMessage> PutAsync<T>(Uri requestUri, string authToken, T body, CancellationToken cancellationToken)
        {
            this.Uri = requestUri.ToString();
            this.Body = JsonConvert.SerializeObject(body, serialisationSettingsProvider.Settings);
            this.Token = authToken;
            return FakeResponse(requestUri);
        }

        private Task<HttpResponseMessage> FakeResponse(Uri requestUri)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(IsArrayEndpoint(requestUri) ? "[]" : "{}");
            return Task.FromResult(response);
        }

        private bool IsArrayEndpoint(Uri requestUri)
        {
            if (requestUri.AbsolutePath.EndsWith("/images"))
                return true;

            return false;
        }
    }
}
