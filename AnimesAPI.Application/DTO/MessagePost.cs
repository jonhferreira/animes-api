using AnimesAPI.Domain.Interfaces.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesAPI.Application.DTO
{
    public class MessagePost : IMessageRequest
    {
        //código 200: retorna o recurso criado no body

        //criação de um único item
        public string Message200(string acao)
        {
            return $"{acao} criado(a) com sucesso";
        }
        //criação de múltiplos itens
        public string Message200Mult(string acao)
        {
            return $"{acao} criados(as) com sucesso";
        }

    }
}
