using System;
using System.Collections.Generic;
using System.Text;

namespace AcoesDotNet.Model.Validacoes
{
    public interface IValidacao
    {
        IEnumerable<string> Valida();
    }
}
