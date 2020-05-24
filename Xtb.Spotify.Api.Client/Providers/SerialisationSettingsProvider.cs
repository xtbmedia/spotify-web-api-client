using Newtonsoft.Json;

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
                NullValueHandling = NullValueHandling.Ignore
            };
        }
    }
}
