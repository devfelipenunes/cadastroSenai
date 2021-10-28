using senai_cadastro;
using System;
using System.Globalization;
using senaiCadastro.Enums;

namespace senai_cadastro
{
    public class Endereco
    {
        private string Logradouro { get; set; }

        private int Numero { get; set; }

        private string Complemento { get; set; }

        private TipoEndereco TipoEndereco { get; set; }

        public Endereco(string logradouro, int numero, string complemento, TipoEndereco tipoEndereco)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            TipoEndereco = tipoEndereco;
        }

        public override string ToString()
        {
            return $"Logradouro: {Logradouro} " +
                   $"|Numero: {Numero} " +
                   $"|Complemento: {Complemento}" ;
        }
    }
}