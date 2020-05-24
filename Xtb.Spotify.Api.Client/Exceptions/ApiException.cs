using System;
using System.Net;
using Xtb.Spotify.Api.Dto;

namespace Xtb.Spotify.Api.Client.Exceptions
{
    public class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public ApiError ApiError { get; }

        public ApiException(HttpStatusCode statusCode, ApiError apiError) : this(statusCode, apiError, null)
        {
        }

        //public ApiException(HttpStatusCode statusCode, ApiError apiError, Exception innerException) : this(statusCode, apiError, innerException)
        //{
        //}

        public ApiException(HttpStatusCode statusCode, ApiError apiError, Exception innerException) : base(apiError.Error, innerException)
        {
            this.StatusCode = statusCode;
            this.ApiError = apiError;
        }


    }
}
