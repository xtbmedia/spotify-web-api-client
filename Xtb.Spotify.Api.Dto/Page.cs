﻿using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Xtb.Spotify.Api.Dto.Interfaces;

namespace Xtb.Spotify.Api.Dto
{
    public class Page<T> where T : IPageable
    {
        public string Href { get; set; }
        public IEnumerable<T> Items { get; set; }
        public int Limit { get; set; }
        public string Next { get; set; }
        public int Offset { get; set; }
        public string Previous { get; set; }
        public int Total { get; set; }
    }
}