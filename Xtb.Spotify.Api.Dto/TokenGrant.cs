using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xtb.Spotify.Api.Dto
{
    public class TokenGrant
    {
        /// <summary>
        /// An access token that can be provided in subsequent calls, for example to Spotify Web API services.
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// How the access token may be used: always “Bearer”.
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// A space-separated list of scopes which have been granted for this <see cref="AccessToken"/>
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// The time period (in seconds) for which the access token is valid.
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// A token that can be sent to the Spotify Accounts service in place of an authorization code.
        /// (When the access code expires, send a POST request to the Accounts service /api/token 
        /// endpoint, but use this code in place of an authorization code.
        /// A new <see cref="AccessToken"/> will be returned. A new refresh token might be 
        /// returned too.)
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

    }
}
