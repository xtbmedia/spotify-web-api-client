﻿using Newtonsoft.Json;

namespace Xtb.Spotify.Api.Dto
{
    public class ExternalId
    {
        /// <summary>
        /// The identifier type, for example:
        /// - "isrc" - International Standard Recording Code
        /// - "ean" - International Article Number
        /// - "upc" - Universal Product Code
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// An external identifier for the object.
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}