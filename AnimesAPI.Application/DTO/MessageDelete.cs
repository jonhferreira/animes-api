using AnimesAPI.Domain.Interfaces.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesAPI.Application.DTO
{
    public class MessageDelete : IMessageRequest
    {
        public string Message200(string acao)
        {
            return $"{acao} deletado(a) com sucesso";
        }
        //criação de múltiplos itens
        public string Message200Mult(string acao)
        {
            return $"{acao} deletados(as) com sucesso";
        }
    }
}
