using AnimesAPI.Domain.Interfaces.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AnimesAPI.Application.DTO
{
    public class DeletedSuccessfully : IResponse
    {
        public DeletedSuccessfully(HttpStatusCode StatusCode, string Message)
        {
            this.StatusCode = StatusCode;
            this.Message = Message;
        }

        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
