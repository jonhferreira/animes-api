using AnimesAPI.Domain.Interfaces.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AnimesAPI.Application.DTO
{
    public class FetchedSuccessfully<T> : IResponse
    {
        public FetchedSuccessfully(T data)
        {
            this.StatusCode = HttpStatusCode.OK;
            this.Message = "";
            this.Data = data;
        }

        public FetchedSuccessfully(string message, T data)
        {
            this.StatusCode = HttpStatusCode.OK;
            this.Message = message;
            this.Data = data;
        }

        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; } = string.Empty;

        public T? Data { get; set; }
    }
}
