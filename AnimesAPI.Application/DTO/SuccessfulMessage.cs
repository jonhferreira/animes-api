using AnimesAPI.Domain.Interfaces.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesAPI.Application.DTO
{
    public class SuccessfulMessage : ISuccessMessage
    {
        //código 201: criação de um recurso, é retornado apenas um link ou id do recurso
        //criação de um único item
        public string Message201(string objeto)
        {
            return $"{objeto} criado(a) com sucesso";
        }
        //criação de múltiplos itens
        public string Message201Mult(string objeto)
        {
            return $"{objeto} criados(as) com sucesso";
        }

        //ex: Processos recebidos com sucesso; mensagem de .OK geral
        public string Message200(string acao)
        {
            return $"{acao} com sucesso";
        }
    }
}
