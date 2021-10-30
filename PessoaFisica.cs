using System;
using senaiCadastro;

namespace senai_cadastro
{
    public class PessoaFisica : Pessoa
    {
        public string Cpf { get; set; }
        private DateTime DataNascimento { get; set; }
        public PessoaFisica()
        {
            /*
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            */
        }
        public bool ValidarDataNascimento(DateTime dataNasc){
            
            DateTime dataAtual = DateTime.Today;

            double anos = (dataAtual - dataNasc).TotalDays / 365;

            if ( anos >= 18 ){
                return true;
            } else {
                return false;
            }


        }

        public override string ToString()
        {
            return $"Nome: {Nome} " +
                   $"|CPF: {Cpf} " +
                   $"|Data de Nascimento: {DataNascimento} " +
                   $"|Pessoa Fisica";
                
        }
    }
}