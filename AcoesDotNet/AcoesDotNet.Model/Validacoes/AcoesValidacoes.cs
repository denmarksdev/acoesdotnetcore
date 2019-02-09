using AcoesDotNet.Model.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcoesDotNet.Model
{
    public partial class Acao : IValidacao
    {
        public  IEnumerable<string> Valida()
        {
            if (string.IsNullOrWhiteSpace(CodigoDaAcao))
            {
                yield return $"{nameof(CodigoDaAcao)} é obrigatório";
            } else if (CodigoDaAcao.Length > 10)
            {
                yield return $"{nameof(CodigoDaAcao)} deve ter no máximo 10 caracteres";
            }

            if (DataCotacao == DateTime.MinValue)
            {
                yield return $"{nameof(DataCotacao)} é obrigatório";
            }

            if (Valor < 0)
            {
                yield return $"{nameof(Valor)} deve ser maior que zero";
            }
        }
    }
}
