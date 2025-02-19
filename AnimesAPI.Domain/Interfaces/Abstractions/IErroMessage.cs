using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesAPI.Domain.Interfaces.Abstractions
{
    public interface IErrorMessage
    {
        string ErrorMessage401();
        string ErrorMessage404(string objeto, string identificacao, string id);
        string ErrorMessageGeneric404(string objeto);
        string ErrorMessage400(string tipoDeObjeto);
        string ErrorMessage400();
        string ErrorMessage409(string objeto, string identificacao, string id);
        string ErrorMessageGeneric409(string objeto);
        string ErrorMessage500();
        string ErrorMessage502();
    }
}
