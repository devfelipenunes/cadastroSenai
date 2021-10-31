using senai_cadastro;
using System;
using System.Globalization;
using senaiCadastro.Enums;


namespace senai_cadastro
{
    public class Endereco
    {
        public string Logradouro { get; set; }

        public int Numero { get; set; }

        public string Complemento { get; set; }

        public TipoEndereco TipoEndereco { get; set; }

        public Endereco(){}

        public override string ToString()
        {
            return $"Logradouro: {Logradouro} " +
                   $"|Numero: {Numero} " +
                   $"|Complemento: {Complemento}" ;
        }
    }
}