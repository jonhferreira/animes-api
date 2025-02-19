using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesAPI.Domain.Interfaces.Abstractions
{
    public interface IMessageRequest
    {
        //para especificar diferentes tipos de requisição
        string Message200(string objeto);
        string Message200Mult(string objeto);
    }
}
