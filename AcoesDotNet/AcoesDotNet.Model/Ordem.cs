using Newtonsoft.Json;
using System;
using System.Linq;

namespace AcoesDotNet.Model
{
    public partial  class Ordem : BaseModel
    {
        private const int VALOR_BASE_LIMITE = 20000;
        public const int ISENTO = 0;
        public const char TIPO_COMPRA = 'C',
                          TIPO_VENDA = 'V';

        private readonly char[] _tiposValidos = new[] { TIPO_COMPRA, TIPO_VENDA };

        #region Propriedades

        private char _tipo;
        public char TipoOrdem
        {
            get => _tipo;
            set {
                if (!TipoEhValido(value))
                    throw new ArgumentException($"Tipo '{TipoOrdem}' inválido");

                _tipo = value;
            }
        }

        public DateTime  DataOrdem { get; set; }
        
        public int QuantidadeAcoes  { get; set; }
        public DateTime? DataCompra { get; set; }
        public decimal ValorOrdem { get; set; }
        public decimal TaxaCorretagem { get; set; }
        public decimal ImpostoRenda { get; set; }

        public int IdCliente { get; set; }

        [JsonIgnore]
        public Cliente Cliente { get; set; }

        public string CodigoAcao { get; set; }

        private bool EhUmaCompra() => TipoOrdem == TIPO_COMPRA;
        private bool TipoEhValido(char tipo) => _tiposValidos.Contains(tipo);

        #endregion

        #region Métodos

        public void EfetuaCalculos(Acao acaoPorDataOrdem, Acao acaoPorDataCompra, Cliente cliente)
        {
            CalculaValorOrdem(acaoPorDataOrdem);
            CalculaTaxaCorretagem(cliente);
            CalculaImpostoRenda(acaoPorDataOrdem, acaoPorDataCompra);
        }

        public void CalculaValorOrdem(Acao acao)
        {
            ValorOrdem = QuantidadeAcoes * acao.Valor;
        }

        public void CalculaTaxaCorretagem(Cliente cliente)
        {
            if (!TipoEhValido(TipoOrdem)) throw new ArgumentException($"Tipo de ordem '{TipoOrdem}' invalido");

            if (EhUmaCompra())
            {
                DefineTaxaNaCompra(cliente);
            }
            else
            {
                DefineTaxaNaVenda(cliente);
            }
        }

        public void CalculaImpostoRenda(Acao acaoPorDataOrdem, Acao acaoPorDataCompra)
        {
            if (EhUmaCompra())
            {
                ImpostoRenda = ISENTO;
            }
            else
            {
                var variacaoCotacao = (acaoPorDataOrdem.Valor - acaoPorDataCompra.Valor);
                if (variacaoCotacao > 0)
                {
                    ImpostoRenda = (QuantidadeAcoes * variacaoCotacao) * 0.15m;
                }
                else
                {
                    ImpostoRenda = ISENTO;
                }
            }
        }

        private void DefineTaxaNaVenda(Cliente cliente)
        {
            if (cliente.EhUmaPessoaFisica())
            {
                TaxaCorretagem = 0.70m;
            }
            else
            {
                TaxaCorretagem = 0.60m;
            }
        }

        private void DefineTaxaNaCompra(Cliente cliente)
        {
            if (cliente.EhUmaPessoaFisica())
            {
                if (ValorOrdem < VALOR_BASE_LIMITE)
                    TaxaCorretagem = ISENTO;
                else if (ValorOrdem >= VALOR_BASE_LIMITE)
                {
                    TaxaCorretagem = 0.75m;
                }
            }
            else
            {
                if (ValorOrdem < VALOR_BASE_LIMITE)
                {
                    TaxaCorretagem = 0.25m;
                }
                else if (ValorOrdem >= VALOR_BASE_LIMITE)
                {
                    TaxaCorretagem = 0.45m;
                }
            }
        }
    }

    #endregion

}

