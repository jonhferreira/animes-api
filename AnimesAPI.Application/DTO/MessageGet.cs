using AnimesAPI.Domain.Interfaces.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesAPI.Application.DTO
{
    public class MessageGet : IMessageRequest
    {
        public string Message200(string objeto)
        {
            return $"{objeto} listado(a) com sucesso";
        }
        public virtual string Message200Mult(string objeto)
        {
            return $"{objeto} listados(as) com sucesso";
        }
    }
}
