using System;
using senaiCadastro;

namespace senai_cadastro
{
    public class PessoaFisica : Pessoa
    {
        public string Cpf { get; set; }
        private DateTime DataNascimento { get; set; }
        public PessoaFisica(){}
        public bool ValidarDataNascimento(DateTime dataNasc){
            
            DateTime dataAtual = DateTime.Today;

            double anos = (dataAtual - dataNasc).TotalDays / 365;

            if ( anos >= 18 ){
                return true;
            } else {
                return false;
            }
        }

        public void PagarImposto(double rendimento)
        {
            double resultado;

            if(rendimento <= 1500)
            {
            resultado = 0;
            } else if (rendimento > 1500 && rendimento <= 5000)
            {
                resultado =  rendimento * .03;
            }else{
                resultado =  (rendimento/100) * 5;
            }
        }

        /*
        public static void AddPessoa()
        {
            string addPessoaQuery = "Insira os dados da Pessoa Fisica (Nome | Idade | CPF ) "               
                                    ;
        }
        */

        public override string ToString()
        {
            return $"Nome: {Nome} " +
                   $"|CPF: {Cpf} " +
                   $"|Data de Nascimento: {DataNascimento} " +
                   $"|Pessoa Fisica";
                
        }
    }
}