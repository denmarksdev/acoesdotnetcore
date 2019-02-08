using AcoesDotNet.Model;
using System;
using Xunit;

namespace AcoesDotNet.Testes
{
    public class OrdemTeste
    {
        private Acao _acao;
        private Ordem _ordem;
        private Cliente _cliente;

        public OrdemTeste()
        {
            _cliente = new Cliente
            {
                Nome = "João",
                CnpjCpf = "111.111.111-11",
                DataNascimento = new DateTime(1983, 10, 01)
            };
            _acao = new Acao
            {
                CodigoDaAcao = "AC01",
                DataCotacao = DateTime.UtcNow,
            };
            _ordem = new Ordem
            {
                DataCompra = DateTime.UtcNow,
                DataOrdem = DateTime.UtcNow,
                CodigoAcao = _acao.CodigoDaAcao,
            };
        }

        [Fact]
        public void CalculaValorDaOrdemTeste()
        {
            _acao.Valor = 5.000m;
            _ordem.QuantidadeAcoes = 5;

            _ordem.CalculaValorOrdem(_acao);

            Assert.Equal(25.000m, _ordem.ValorOrdem);
        }

        [Fact]
        void CalculaTaxaCorretagemPessoaFisicaTeste()
        {
            _01CalculaIsentoPessoaFisicaCompraTeste();
            _02Calcula75PorcentoPessoaFisicaCompraTeste();
            _03Calcula60PorcentoVendaPessoaFisica();
        }

        [Fact]
        void CalculaTaxaCorretagemPessoaJuridicaTeste()
        {
            _01CalculaTaxaPessoaJuridica25PorcentoCompraTeste();
            _02CalculaTaxaPessoaJuridica45PorcentoCompraTeste();
            _03CalculaTaxaPessoaJuridica60PorcentoVendaTeste();
        }

        [Fact]
        void CalculaImpostoRendaTeste()
        {
            var acaoDataCompra = new Acao
            {
                CodigoDaAcao = "A02",
                DataCotacao = DateTime.Now.Date,
                Valor = 1000
            };
            var acaoDaDataOrdem = new Acao
            {
                CodigoDaAcao = acaoDataCompra.CodigoDaAcao,
                DataCotacao = DateTime.Now.Date.AddMinutes(30),
                Valor = 2000
            };
            var ordem = new Ordem
            {
                CodigoAcao = acaoDaDataOrdem.CodigoDaAcao,
                DataCompra = acaoDaDataOrdem.DataCotacao,
                QuantidadeAcoes = 2,
            };

            ordem.CalculaImpostoRenda(acaoDaDataOrdem, acaoDataCompra);

            Assert.Equal(300m, ordem.ImpostoRenda);

            CalculaIsencaoImpostoTeste(acaoDataCompra, acaoDaDataOrdem, ordem);
        }

        #region Métodos Auxiliares

        private void CalculaIsencaoImpostoTeste(Acao acaoDataCompra, Acao acaoDaDataOrdem, Ordem ordem)
        {
            acaoDataCompra.Valor = 4000;

            ordem.CalculaImpostoRenda(acaoDaDataOrdem, acaoDataCompra);

            Assert.Equal(Ordem.ISENTO, ordem.ImpostoRenda);
        }

        private void _03CalculaTaxaPessoaJuridica60PorcentoVendaTeste()
        {
            _ordem.TipoOrdem = Ordem.TIPO_VENDA;

            _ordem.CalculaValorOrdem(_acao);
            _ordem.CalculaTaxaCorretagem(_cliente);

            Assert.Equal(0.60m, _ordem.TaxaCorretagem);
        }

        private void _02CalculaTaxaPessoaJuridica45PorcentoCompraTeste()
        {
            _ordem.QuantidadeAcoes = 2;

            _ordem.CalculaValorOrdem(_acao);
            _ordem.CalculaTaxaCorretagem(_cliente);

            Assert.Equal(0.45m, _ordem.TaxaCorretagem);
        }

        private void _01CalculaTaxaPessoaJuridica25PorcentoCompraTeste()
        {
            _cliente.TipoPessoa = Cliente.TIPO_PESSOA_JURIDICA;
            _acao.Valor = 15000m;
            _ordem.TipoOrdem = Ordem.TIPO_COMPRA;
            _ordem.QuantidadeAcoes = 1;

            _ordem.CalculaValorOrdem(_acao);
            _ordem.CalculaTaxaCorretagem(_cliente);

            Assert.Equal(0.25m, _ordem.TaxaCorretagem);
        }

        private void _03Calcula60PorcentoVendaPessoaFisica()
        {
            _cliente.TipoPessoa = Cliente.TIPO_PESSOA_FISICA;
            _ordem.TipoOrdem = Ordem.TIPO_VENDA;

            _ordem.CalculaValorOrdem(_acao);
            _ordem.CalculaTaxaCorretagem(_cliente);
            Assert.Equal(0.70m, _ordem.TaxaCorretagem);
        }

        private void _02Calcula75PorcentoPessoaFisicaCompraTeste()
        {
            _ordem.QuantidadeAcoes = 2;

            _ordem.CalculaValorOrdem(_acao);
            _ordem.CalculaTaxaCorretagem(_cliente);

            Assert.Equal(0.75m, _ordem.TaxaCorretagem);
        }

        private void _01CalculaIsentoPessoaFisicaCompraTeste()
        {
            _cliente.TipoPessoa = Cliente.TIPO_PESSOA_FISICA;
            _acao.Valor = 15000m;
            _ordem.TipoOrdem = Ordem.TIPO_COMPRA;
            _ordem.QuantidadeAcoes = 1;

            _ordem.CalculaValorOrdem(_acao);
            _ordem.CalculaTaxaCorretagem(_cliente);

            Assert.Equal(Ordem.ISENTO, _ordem.TaxaCorretagem);
        }

        #endregion
    }
}
