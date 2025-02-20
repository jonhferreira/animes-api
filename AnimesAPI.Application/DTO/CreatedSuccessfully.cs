using AnimesAPI.Domain.Interfaces.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AnimesAPI.Application.DTO
{
    public class CreatedSuccessfully : IResponse
    {
        public CreatedSuccessfully(long id)
        {
            this.StatusCode = HttpStatusCode.Created;
            this.Message = "Sucesso ao criar recurso";
            this.ResourceId = id;
        }

        public CreatedSuccessfully(string message, long id)
        {
            this.StatusCode = HttpStatusCode.Created;
            this.Message = message;
            this.ResourceId = id;
        }

        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }

        public long ResourceId { get; set; }
    }
}
