using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using senai_cadastro;
using System.Threading;

namespace senaiCadastro
{
    public class Programa : Menu
    {
        public static List<Pessoa> pessoas = new List<Pessoa>();
        public static List<Endereco> enderecos = new List<Endereco>();

        public void Executar()
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            
            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case"1":
                        Inserir();
                        break;
                    case"2":
                        Listar();
                        break;
                    case"3":
                        ExcluirPessoa();
                        break;

                    case"C":
                        Console.Clear();
                        break;
                
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            AdicionarDot("Sessão finalizada");
            Console.ReadLine();
        }
          //Listas:
        private static void Listar()
        {
            Console.WriteLine($"1 - Listar pessoas");
            Console.WriteLine($"2 - Listar endereços");
            string escolhaInserir = Console.ReadLine();
            if(escolhaInserir == "1")
            {
                ListarPessoas();
                return;
            } else {
                ListarEnderecos();
            }
        }
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
        public Pessoa PesquisarPessoa(string fname)
        {
            foreach(Pessoa p in pessoas)
            {
                if(fname == p.Nome)
                {
                    return p;
                }
            }
            return null;
        }
        //Inserir:
        public void Inserir()
        {
            Console.WriteLine($"1 - Inserir pessoa");
            Console.WriteLine($"2 - Inserir endereço");
            string escolhaInserir = Console.ReadLine();
            if(escolhaInserir == "1")
            {
                InserirPessoa();
                return;
            } else {
                //InserirEndereco();
            }
        }
        private void InserirPessoa()
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
            ValidarCNPJ(cnpj);

            Console.WriteLine("Informe a Razão Social: ");
            string razaoSocial = Console.ReadLine();

            pessoas.Add(new PessoaJuridica(cnpj, razaoSocial));
            AdicionarDot("Pessoa registrada com sucesso!");
            Console.WriteLine();
        }
        private void InserirPessoaFisica()
        {

            Limpar();
            var pessoaFisica = new PessoaFisica();

            Escrever("Informe o nome: ");
            pessoaFisica.Nome = Ler();

            Escrever("Informe a sua idade: ");
            pessoaFisica.Idade = int.Parse(Ler());
            ValidarIdade(pessoaFisica.Idade);

            pessoas.Add(pessoaFisica);
            AdicionarDot("Pessoa registrada com sucesso!");

            Limpar();
            Escrever("Gostaria de cadastrar outra pessoa? [s/n]");
            var cadastrarNovamente = Ler().ToUpper();
            if(cadastrarNovamente == "s")
            {
                InserirPessoaFisica();
            }
            /*



            Console.Write("Informe a data de nascimento: ");
            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());

            Console.Write("Informe o CPF: ");
            string cpf = Console.ReadLine();
            ValidarCPF(cpf);

            pessoas.Add(new PessoaFisica());
            Console.WriteLine();
            */
        }
       /*
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
        */

        //Deletar
        public void ExcluirPessoa()
        {
            Pessoa pessoa = new Pessoa();
            Escrever("Digite o nome da pessoa: ");
            var nome = Ler();
            pessoa = PesquisarPessoa(nome);
            if(PesquisarPessoa(nome) != null)
            {
                pessoas.Remove(pessoa);
            }
        }

        //Valida
        public void ValidarCPF(string cpf)
        {
            if(cpf.Length != 11)
            {
                AdicionarDot("CPF INVALIDO");
                InserirPessoaFisica();
            }
        }
        public void ValidarIdade(int validarIdade)
        {
            if(validarIdade < 18)
            {
                AdicionarDot("Idade insuficiente");
                InserirPessoaFisica();   
            }
        }

        public static void ValidarCNPJ(string cnpj){
            if(cnpj.Length == 14 && cnpj.Substring(cnpj.Length - 4) == "0001"){
                return;
            }
            AdicionarDot("CNPJ INVALIDO");
            InserirPessoaJuridica();
        }
        //FUNÇÕES
        private static string ObterOpcaoUsuario()
        {
            AdicionarDot("Bem Vindo ao nosso sistema de cadastro.");
            AdicionarDot("Escolha uma das opções abaixo.");
            Console.WriteLine();
            Console.WriteLine($"1 - Inserir");
            Console.WriteLine($"2 - Listar");
            Console.WriteLine($"3 - Deletar");
            Console.WriteLine($"C - Limpar tela");
            Console.WriteLine($"X - Sair");
            Console.WriteLine($"");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        private static void AdicionarDot(string textoCarregamento)
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(textoCarregamento);
            Thread.Sleep(1000);
            Console.ResetColor();
        }
    }
}        