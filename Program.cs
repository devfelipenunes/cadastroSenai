using System;

namespace senai_cadastro
{
    class Program
    {
        static void Main(string[] args)
        {

            /* PessoaFisica pf = new PessoaFisica();
            Endereco end = new Endereco();

            bool idadeValida = pf.ValidarDataNascimento(pf.dataNascimento);
            
            if (idadeValida == true){
                Console.WriteLine($"Cadastro Aprovado!");
            } else {
                Console.WriteLine($"Cadastro Reprovado!");
            }
            */

            PessoaJuridica pj = new PessoaJuridica();
            PessoaJuridica novaPj = new PessoaJuridica();

            Endereco end = new Endereco();

            end.logradouro = "Rua X";
            end.numero = 100;
            end.complemento = "Proximo ao Senai";
            end.enderecoComercial = true;

            novaPj.endereco = end;
            novaPj.cnpj = "12345678900001";
            novaPj.RazaoSocial = "Pessoa Juridica";


            if(pj.ValidarCNPJ(novaPj.cnpj)){
                Console.WriteLine("CNPJ VÁLIDO");
                
            } else {
                Console.WriteLine($"CNPJ Inválido");
            }

        }
    }
}
