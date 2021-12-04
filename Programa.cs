using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using senai_cadastro;
using System.Threading;
using senaiCadastro.Enums;

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
                    case"4":
                        //Teste();
                        string fileName = @"./DataBase/Pessoas.txt";
                        ExportarInformacoes(fileName);
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

        public void ExportarInformacoes(string fname)
        {
            string fileName = fname;
            try
            {
                using (FileStream fs = File.Create(fileName))
                foreach (PessoaFisica p in pessoas)
                {
                    Escrever(p.GetDados());
                    byte[] info = new UTF8Encoding(true).GetBytes(p.GetDados());
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            SeguraTela();
        }

        // public void Teste()
        // {
        //     Escrever("Digite um nome");
        //     string nome = Ler();
        //     StreamWriter sw = new StreamWriter($"{nome}.txt");
        //     sw.Write($"{nome}");
        //     sw.Close();
        // }



        //Listas:
        private void Listar()
        {
            Escrever($"1 - Listar Pessoas");
            Escrever($"2 - Listar Endereços");
            string escolhaInserir = Ler();
            if(escolhaInserir == "1")
            {
                ListarPessoas();
                return;
            } else {
                ListarEnderecos();
            }
        }
        private void ListarEnderecos()
        {
            if(enderecos.Count == 0)
            {
                Escrever("--Nenhum endereço cadastrado!--");
                AdicionarDot("-----[1]Adicionar----[2]Voltar------");

                string escolha1 = Ler().ToUpper();
                switch(escolha1)
                {
                    case"1":
                        InserirEndereco();
                        break;
                    case"2":
                        Executar();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            MostrarEnderecos();
        }
        public void ListarPessoas()
        {
            if(pessoas.Count == 0)
            {
                AdicionarDot("----Nenhuma pessoa cadastrada!------");
                AdicionarDot("-----[1]Adicionar----[2]Voltar------");
                string opcoes1 = Ler().ToUpper();
                switch(opcoes1)
                {
                    case"1":
                        InserirPessoa();
                        break;
                    case"2":
                        Executar();
                        break;
                
                    default:
                        throw new ArgumentOutOfRangeException();
                }    
            }

            AdicionarDot("---Lista de pessoas cadastrados---");
            AdicionarDot("-----[1]Excluir----[2]Voltar------");

            MostrarPessoas();
        }
        public void MostrarPessoas()
        {
            MostrarListaPessoas();
            
            string escolhaMenu = Ler();
            MenuMostrarPessoas(escolhaMenu);
        }

        public void MostrarListaPessoas()
        {
            int i = 0;
            foreach(Pessoa pessoa in pessoas)
            {
                Console.WriteLine($"|Id: {i} | " + pessoa);
                i++;
            }
        }

        public void MostrarEnderecos()
        {
            int i = 0;
            AdicionarDot("---Lista de enderecos cadastrados---");
            Console.WriteLine();
            foreach(Endereco endereco in enderecos)
            {
                Escrever($"|Id: {i} | " + endereco);
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
            Limpar();
            Escrever($"1 - Inserir Pessoa");
            Escrever($"2 - Inserir Endereço");
            string escolhaInserir = Ler();
            if(escolhaInserir == "1")
            {
                InserirPessoa();
                return;
            } else {
                InserirEndereco();
            }
        }
        public void InserirPessoa()
        {
            Limpar();
            Escrever("Qual tipo de registro: [1:Pessoa Fisica | 2:Pessoa Juridica]");
            string tipoRegistro = Ler();
            
            if(tipoRegistro == "1"){
                AdicionarDot("Pessoa Fisica Selecionada!");
                InserirPessoaFisica();
            } else {
                AdicionarDot("Pessoa Juridica Selecionada!");
                InserirPessoaJuridica();
                return;
            }
        }
        private void InserirPessoaJuridica()
        {
            Limpar();
            var pessoaJuridica = new PessoaJuridica();

            Escrever("Informe o CNPJ: ");
            pessoaJuridica.Cnpj = Ler();
            ValidarCNPJ(pessoaJuridica.Cnpj);

            Escrever("Informe a Razão Social: ");
            pessoaJuridica.RazaoSocial = Ler();

            pessoas.Add(pessoaJuridica);
            AdicionarDot("Pessoa registrada com sucesso!");
            Limpar();

            MenuInserirPessoa();
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


            Escrever("Informe o CPF: ");
            pessoaFisica.Cpf = Ler();
            ValidarCPF(pessoaFisica.Cpf);
            
            pessoas.Add(pessoaFisica);
            AdicionarDot("Pessoa registrada com sucesso!");
            Limpar();

            MenuInserirPessoa();
            
            /* To tentando mais né...
            Console.Write("Informe a data de nascimento: ");
            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
            */
        }
        public void InserirEnderecoPessoa(string escolha)
        {
            if(escolha == "s")
            {
                InserirEndereco();
            }            
        }
        private void InserirEndereco()
        {
            Limpar();
            var endereco = new Endereco();

            Escrever("Qual tipo de residência: [1:Residencial | 2:Comercial]");
            TipoEndereco tipoEndereco = Enum.Parse<TipoEndereco>(Console.ReadLine()); 

            Escrever("Informe o logradouro: ");
            endereco.Logradouro = Ler();

            Escrever("Informe o numero: ");
            endereco.Numero = int.Parse(Ler());

            Escrever("Informe o complemento: ");
            endereco.Complemento = Ler();

            enderecos.Add(endereco);
            AdicionarDot("Endereço registrado com sucesso!");
            Limpar();

            MenuInserirEndereco();
        }
        private void MenuInserirEndereco()
        {
            Limpar();
            AdicionarDot("-[1]Cadastrar outro endereço-");
            AdicionarDot("---[2]Ver lista de endereço--");
            AdicionarDot("-----------[3]Voltar---------");
            string opcaoMenu = Ler();

            EscolhaMenuEndereco(opcaoMenu);
        }

        private void MenuInserirPessoa()
        {
            Limpar();
            AdicionarDot("--[1]Cadastrar outra pessoa--");
            AdicionarDot("---[2]Ver lista de pessoas---");
            AdicionarDot("-----------[3]Voltar---------");
            string opcaoMenu = Ler();

            EscolhaMenuPessoa(opcaoMenu);
        }

        public void MenuMostrarPessoas(string escolhaMenu)
        {
            string i = escolhaMenu;
            switch(escolhaMenu)
            {
                case"1":
                    ExcluirPessoa();
                    break;
                case"2":
                    Executar();
                    break;
        
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void MenuMostrarEnderecos(string escolhaMenu)
        {
            string i = escolhaMenu;
            switch(i)
            {
                case"1":
                    ExcluirPessoa();
                    break;
                case"2":
                    Executar();
                    break;
        
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public void EscolhaMenuEndereco(string escolhaMenu)
        {
            string i = escolhaMenu;
            switch(i)
            {
                case"1":
                    InserirEndereco();
                    break;
                case"2":
                    ListarEnderecos();
                    break;
                case"3":
                    Executar();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public void EscolhaMenuPessoa(string escolhaMenu)
        {
            string i = escolhaMenu;
            switch(i)
            {
                case"1":
                    InserirPessoa();
                    break;
                case"2":
                    ListarPessoas();
                    break;
                case"3":
                    Executar();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }      
        //Deletar
        public void ExcluirPessoa()
        {
            Limpar(); 
            Pessoa pessoa = new Pessoa();
            MostrarListaPessoas();
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

        public void ValidarCNPJ(string cnpj){
            if(cnpj.Length == 14){
                return;
            }
            AdicionarDot("CNPJ INVALIDO");
            InserirPessoaJuridica();
        }
        //FUNÇÕES
        private string ObterOpcaoUsuario()
        {
            Limpar();
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