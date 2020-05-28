using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Xtb.Spotify.Api.Client.Providers
{
    public class SerialisationSettingsProvider
    {
        public JsonSerializerSettings Settings { get; }

        public SerialisationSettingsProvider()
        {
            Settings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            };
        }
    }
}
