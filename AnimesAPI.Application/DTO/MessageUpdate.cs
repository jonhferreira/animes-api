using AnimesAPI.Domain.Interfaces.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesAPI.Application.DTO
{
    public class MessageUpdate: IMessageRequest
    {
        //um item; Processo atualizado(a) com sucesso
        public virtual string Message200(string objeto)
        {
            return $"{objeto} atualizado(a) com sucesso";
        }

        //vários itens; Processos listados(as) com sucesso
        public string Message200Mult(string objeto)
        {
            return $"{objeto} atualizados(as) com sucesso";
        }
    }
}
