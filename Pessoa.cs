using System;
using System.Collections.Generic;
using System.Text;

namespace senai_cadastro
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public Endereco Endereco{ get; set; }
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

    }
}