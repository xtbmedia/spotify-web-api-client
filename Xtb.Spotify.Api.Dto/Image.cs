﻿using Newtonsoft.Json;

namespace Xtb.Spotify.Api.Dto
{
    public class Image
    {
        /// <summary>
        /// The image height in pixels. If unknown: null or not returned.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// The source URL of the image.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The image width in pixels. If unknown: null or not returned.
        /// </summary>
        public int Width { get; set; }
    }
}