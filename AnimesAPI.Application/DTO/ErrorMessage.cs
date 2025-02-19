
using AnimesAPI.Domain.Interfaces.Abstractions;

namespace AnimesAPI.Application.DTO
{
    public class ErrorMessage : IErrorMessage
    {
        
        public string ErrorMessage401()
        {
            return "Não autorizado. Faça o Login novamente.";
        }

        //ex: processo com numeroUnico 20240000 não encontrado
        //ex: processo com id 5 não encontrado
        public string ErrorMessage404(string objeto, string identificacao, string id)
        {
            return $"{objeto} com {identificacao} {id} não encontrado.";
        }

        public string ErrorMessageGeneric404(string objeto)
        {
            return $"{objeto} não encontrado(a).";
        }

        //ex: Dado inválido. Tipo de modelo requirido: Processo
        public string ErrorMessage400(string tipoDeObjeto)
        {
            return $"Dado inválido. Tipo de modelo requirido: {tipoDeObjeto}.";
        }

        public string ErrorMessage400()
        {
            return $"Dado de requisição inválido.";
        }

        public string ErrorMessage409(string objeto, string identificacao, string id)
        {
            return $"Não foi possível atualizar {objeto} com {identificacao} {id}.";
        }

        public string ErrorMessageGeneric409(string objeto)
        {
            return $"Não foi possível atualizar {objeto}.";
        }

        public string ErrorMessage500()
        {
            return "Erro interno. Tente novamente.";
        }
        public string ErrorMessage502()
        {
            return "Por favor, tente novamente em alguns minutos.";
        }
    }
}
