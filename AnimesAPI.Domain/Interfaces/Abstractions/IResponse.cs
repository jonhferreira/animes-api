using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AnimesAPI.Domain.Interfaces.Abstractions
{
    public interface IResponse
    {
        HttpStatusCode StatusCode { get; set; }

        string Message { get; set; }
    }
}
