using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xtb.Spotify.Api.Dto
{
    [JsonObject("error")]
    public class ApiError
    {
        [JsonProperty("error")]
        public string Error { get; set; }
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }
}
