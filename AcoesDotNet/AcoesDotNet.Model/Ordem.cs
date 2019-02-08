using System;
using System.Linq;

namespace AcoesDotNet.Model
{
    public  class Ordem : BaseModel
    {
        
        public const char TIPO_COMPRA = 'C',
                          TIPO_VENDA = 'V';

        private readonly char[] _tiposValidos = new[] { TIPO_COMPRA, TIPO_VENDA };


        #region Propriedades

        private char _tipo;
        public char TipoOrdem
        {
            get => _tipo;
            set {
                if (_tiposValidos.Contains(value))
                    throw new ArgumentException($"Tipo '{TipoOrdem}' inválido");

                _tipo = value;
            }
        }

        public DateTime  DataOrdem { get; set; }
        public string CodigoAcao { get; set; }
        public int QuantidadeAcoes  { get; set; }
        public DateTime DataCompra { get; set; }
        public decimal ValorOrdem { get; set; }
        public decimal TaxaCorretagem { get; set; }
        public decimal ImpostoRenda { get; set; }

        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }

        #endregion
    }
}
