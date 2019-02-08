using System;
using System.Linq;

namespace AcoesDotNet.Model
{
    public  class Ordem
    {
        private const int VALOR_BASE_LIMITE = 20000;
        public const int ISENTO = 0;
        public const char TIPO_COMPRA = 'C',
                          TIPO_VENDA = 'V';

        private readonly char[] _tiposValidos = new[] { TIPO_COMPRA, TIPO_VENDA };


        #region Propriedades

        private char _tipo;
        public char Tipo
        {
            get => _tipo;
            set {
                if (_tiposValidos.Contains(value))
                    throw new ArgumentException($"Tipo '{Tipo}' inválido");

                _tipo = value;
            }
        }
        public DateTime  DataOrdem { get; set; }
        public string CodigoAcao { get; set; }
        public int QuantidadeAcoes  { get; set; }
        public DateTime DataCompra { get; set; }
        public decimal Valorordem { get; set; }
        public decimal TaxaCorretagem { get; set; }
        public decimal ImpostoRenda { get; set; }


        #endregion
    }
}
