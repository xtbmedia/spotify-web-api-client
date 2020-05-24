using System;
using System.Collections.Generic;
using System.Text;

namespace Xtb.Spotify.Api.Client.Providers
{
    public class EndpointProvider
    {
        public string Root => "https://api.spotify.com/v1";
        public string Me => $"{Root}/me";
        public string Playlists => $"{Root}/playlists";
        public string Albums => $"{Root}/albums";
        public string Users => $"{Root}/users";
    }
}
