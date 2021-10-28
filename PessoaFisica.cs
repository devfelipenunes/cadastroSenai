using System;

namespace senai_cadastro
{
    public class PessoaFisica : Pessoa
    {
        
        private string Nome { get; set; }
        private string Cpf { get; set; }

        private DateTime DataNascimento { get; set; }

        public PessoaFisica(string nome, string cpf, DateTime dataNascimento)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
        }
        public override void pagarImposto(float salario){}

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