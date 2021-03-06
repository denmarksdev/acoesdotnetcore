﻿using System;

namespace AcoesDotNet.Model
{
    public partial class Cliente : BaseModel 
    {
        public const char TIPO_PESSOA_FISICA = 'F',
                          TIPO_PESSOA_JURIDICA = 'J';

        public string  Nome   { get; set; }

        public DateTime DataNascimento { get; set; }

        private char _tipoPessoa;
        public char TipoPessoa
        {
            get => _tipoPessoa;
            set {
                if (!TipoPessoaValida(value))
                        throw new ArgumentException($"Tipo de pessoa '{_tipoPessoa}' é inválida");

                _tipoPessoa = value; 
            }
        }

        public string CnpjCpf { get; set; }

        public bool EhUmaPessoaFisica() => TipoPessoa == TIPO_PESSOA_FISICA;
    }
}
