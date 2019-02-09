using System;
using System.Collections.Generic;
using AcoesDotNet.Model.Validacoes;

namespace AcoesDotNet.Model
{
    public partial class Ordem : IValidacao
    {
        public IEnumerable<string> Valida()
        {
            if (IdCliente == 0)
            {
                yield return $"{nameof(IdCliente)}  é obrigatório";
            };

            if (string.IsNullOrEmpty(CodigoAcao))
            {
                yield return $"{nameof(CodigoAcao)} é obrigatório";
            }

            if (QuantidadeAcoes <= 0)
            {
                yield return $"{nameof(QuantidadeAcoes)} é obrigatório";
            }

            if (TipoOrdem == TIPO_VENDA && DataCompra == DateTime.MinValue)
            {
                yield return $"{nameof(DataCompra)} é obrigatório";
            }
            else if (TipoOrdem == TIPO_VENDA && DataCompra > DataOrdem)
            {
                yield return $"{nameof(DataCompra)} deve ser menor ou igual a Data da Ordem";
            }
        }
    }
}
