using AcoesDotNet.Model.Validacoes;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AcoesDotNet.Web.Controllers
{
    public class BaseController : ControllerBase
    {
        protected string ValidaEntidade(IValidacao validacao)
        {
            var erros = validacao.Valida();
            if (erros.Count() == 0) return null;

                return "Erros:\n" + string.Join('\n', erros);
        }
    }
}
