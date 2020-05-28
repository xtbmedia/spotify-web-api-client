using Newtonsoft.Json;
using System.Collections.Generic;
using Xtb.Spotify.Api.Dto.Interfaces;

namespace Xtb.Spotify.Api.Dto
{
    public class Page<T> where T : IPageable
    {
        /// <summary>
        /// A link to the Web API endpoint returning the full result of the request.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// The requested data.
        /// </summary>
        public IEnumerable<T> Items { get; set; }

        /// <summary>
        /// The maximum number of items in the response (as set in the query or by default).
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// URL to the next page of items. ( null if none)
        /// </summary>
        public string Next { get; set; }

        /// <summary>
        /// The offset of the items returned (as set in the query or by default).
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// URL to the previous page of items. ( null if none)
        /// </summary>
        public string Previous { get; set; }

        /// <summary>
        /// The maximum number of items available to return.
        /// </summary>
        public int Total { get; set; }
    }
}