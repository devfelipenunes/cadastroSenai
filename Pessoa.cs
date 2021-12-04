using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace senai_cadastro
{
    public class Pessoa
    {
        public Pessoa(string nome, int idade, Endereco endereco, float rendimento)
        {
            this.Nome = nome;
            this.Idade = idade;
            this.Endereco = endereco;
            this.rendimento = rendimento;
        }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public Endereco Endereco { get; set; }
        private List<Endereco> Enderecos { get; set; }
        public float rendimento { get; set; }
        public Pessoa()
        {
            Enderecos = new List<Endereco>();
        }
        public void SetEndereco(List<Endereco> enderecos)
        {
            //Endereco = enderecos;
        }
        public List<Endereco> GetEndereco()
        {
            return Enderecos;
        }
        //public abstract double PagarImposto(float salario){}
        public void VerificarArquivo(string caminho)
        {
            string pasta = caminho.Split("/")[0];
            if (Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }
            if (!File.Exists(caminho))
            {
                File.Create(caminho);
            }
            Directory.CreateDirectory(pasta);
        }
    }
}