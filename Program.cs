using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using senai_cadastro;
using senaiCadastro.Enums;

namespace senai_cadastro
{
    class Program
    {

        static List<Pessoa> pessoas = new List<Pessoa>();
        static List<Endereco> enderecos = new List<Endereco>();
        static void Main(string[] args)
        {

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case"1":
                        InserirEndereco();
                        break;
                    case"2":
                        ListarEnderecos();
                        break;
                    case"3":
                        InserirPessoa();
                        break;
                    case"4":
                        ListarPessoas();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            
            AdicionarDot("Sessão finalizada");
            Console.ReadLine();

            /* PessoaFisica pf = new PessoaFisica();
            Endereco end = new Endereco();

            bool idadeValida = pf.ValidarDataNascimento(pf.dataNascimento);
            
            if (idadeValida == true){
                Console.WriteLine($"Cadastro Aprovado!");
            } else {
                Console.WriteLine($"Cadastro Reprovado!");
            }
            */
            /*
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
            */
        }

        
        //Listas:
        private static void ListarEnderecos()
        {
            if(enderecos.Count == 0)
            {
                Console.WriteLine("Nenhum endereço cadastrado!");
                return;
            }

            int i = 0;
            AdicionarDot("---Lista de enderecos cadastrados---");
            Console.WriteLine();
            foreach(Endereco endereco in enderecos)
            {
                Console.WriteLine($"|Id: {i} | " + endereco);
                i++;
            }
            Console.WriteLine();
        }

        private static void ListarPessoas()
        {
            if(pessoas.Count == 0)
            {
                Console.WriteLine("Nenhuma pessoa cadastrada!");
                return;
            }

            int i = 0;
            AdicionarDot("---Lista de pessoas cadastrados---");
            Console.WriteLine();
            foreach(Pessoa pessoa in pessoas)
            {
                Console.WriteLine($"|Id: {i} | " + pessoa);
                i++;
            }
            Console.WriteLine();            
        }

        //Inserir:
        private static void InserirPessoa()
        {
            
            Console.WriteLine("Qual tipo de registro: [1:Pessoa Fisica | 2:Pessoa Juridica]");
            string tipoRegistro = Console.ReadLine();
            
            if(tipoRegistro == "1"){
                AdicionarDot("Pessoa Fisica Selecionada!");
                InserirPessoaFisica();
                return;
            } else {
                AdicionarDot("Pessoa Juridica Selecionada!");
                InserirPessoaJuridica();
                return;
            }

        }

        private static void InserirPessoaJuridica()
        {
            Console.Write("Informe o CNPJ: ");
            string cnpj = Console.ReadLine();

            Console.WriteLine("Informe a Razão Social: ");
            string razaoSocial = Console.ReadLine();

            pessoas.Add(new PessoaJuridica(cnpj, razaoSocial));
            AdicionarDot("Pessoa registrada com sucesso!");
            Console.WriteLine();

        }

        private static void InserirPessoaFisica()
        {
            Console.Write("Informe o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Informe a sua idade: ");
            int idade = int.Parse(Console.ReadLine());
            ValidarIdade(idade);

            Console.Write("Informe a data de nascimento: ");
            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());

            Console.Write("Informe o CPF: ");
            string cpf = Console.ReadLine();

            pessoas.Add(new PessoaFisica(nome, cpf, dataNascimento));
            AdicionarDot("Pessoa registrada com sucesso!");
            Console.WriteLine();

        }
        private static void InserirEndereco()
        {
            Console.WriteLine("Qual tipo de residência: [1:Residencial | 2:Comercial]");
            TipoEndereco tipoEndereco = Enum.Parse<TipoEndereco>(Console.ReadLine()); 

            Console.Write("Informe o logradouro: ");
            string logradouro = Console.ReadLine();

            Console.Write("Informe o numero: ");
            int numero = int.Parse(Console.ReadLine());

            Console.Write("Informe o complemento: ");
            string complemento = Console.ReadLine();

            enderecos.Add(new Endereco(logradouro, numero, complemento, tipoEndereco));
            AdicionarDot("Endereço registrado com sucesso!");
            Console.WriteLine();
        }

        private static string ObterOpcaoUsuario()
        {
            AdicionarDot("Bem Vindo ao nosso sistema de cadastro.");
            AdicionarDot("Escolha uma das opções abaixo.");
            Console.WriteLine();
            Console.WriteLine($"1 - Inserir novo endereço");
            Console.WriteLine($"2 - Listar endereços");
            Console.WriteLine($"3 - Inserir nova pessoa");
            Console.WriteLine($"4 - Listar pessoas");
            Console.WriteLine($"C - Limpar tela");
            Console.WriteLine($"X - Sair");
            Console.WriteLine($"");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
            
        }

        public static void ValidarIdade(int validarIdade)
        {

            if(validarIdade < 18)
            {
                AdicionarDot("Idade insuficiente");
                InserirPessoa();   
            }

        }        private static void AdicionarDot(string textoCarregamento)
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(textoCarregamento);
            Thread.Sleep(1000);
            /*
            for (var i =0; i < 10; i++)
            {
                Console.Write($".");
                Thread.Sleep(100);
            }
            */
            Console.ResetColor();
        }

    }
}
