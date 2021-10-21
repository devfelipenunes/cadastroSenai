using System;

namespace senai_cadastro
{
    class Program
    {
        static void Main(string[] args)
        {

            PessoaFisica pf = new PessoaFisica();
            Endereco end = new Endereco();

            bool idadeValida = pf.ValidarDataNascimento(pf.dataNascimento);
            
            if (idadeValida == true){
                Console.WriteLine($"Cadastro Aprovado!");
            } else {
                Console.WriteLine($"Cadastro Reprovado!");
            }


        }
    }
}
