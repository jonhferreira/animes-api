using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesAPI.Domain.Interfaces.Abstractions
{
    public interface ISuccessMessage
    {
        string Message201(string objeto);
        string Message200(string acao);
        string Message201Mult(string objeto);
    }
}
