using System;
using System.Net;

namespace Application.Errors
{
    public class RestException : Exception
    {
        public RestException(HttpStatusCode code, object errors = null)
        {
            this.Errors = errors;
            this.Code = code;
        }

        public object Errors { get; set; }
        public HttpStatusCode Code { get; set; }
    }
}