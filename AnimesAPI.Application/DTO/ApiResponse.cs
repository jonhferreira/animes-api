using AnimesAPI.Domain.Interfaces.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AnimesAPI.Application.DTO
{
    public class ApiResponse<T> : IApiResponse<T>
    {
        public ApiResponse(bool Sucess, HttpStatusCode StatusCode, T Data, string Message, string MoreDetails)
        {
            this.Success = Sucess;
            this.StatusCode = StatusCode;
            this.Data = Data;
            this.Message = Message;
            this.MoreDetails = MoreDetails;
        }

        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        //se não houver data/objeto de resposta, insere T: string e preenche com ""
        public T Data { get; set; }
        public string Message { get; set; }
        public string MoreDetails { get; set; }
    }
}
