using AcoesDotNet.Model.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcoesDotNet.Model
{
    public partial class Cliente : IValidacao
    {
        public  IEnumerable<string> Valida()
        {
            if  (string.IsNullOrWhiteSpace(Nome))
            {
                yield return $"{nameof(Nome)} é obrigatório";
            }

            if (!TipoPessoaValida(TipoPessoa))
            {
                yield return $"{nameof(TipoPessoa)} '{TipoPessoa}' é inválido";
            }

            if (DataNascimento == DateTime.MinValue)
            {
                yield return $"{nameof(DataNascimento)} é obrigatório";
            }
        }

        private bool TipoPessoaValida(char tipo)
        {
            return new[] { TIPO_PESSOA_FISICA, TIPO_PESSOA_JURIDICA }.Contains(tipo);
        }
    }
}
