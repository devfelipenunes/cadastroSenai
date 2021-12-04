using System.IO;
using System.Collections.Generic;

namespace senai_cadastro
{
    public class PessoaJuridica : Pessoa
    {
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public PessoaJuridica(){}

        public string caminho { get; private set; } = "DataBase/PessoaJuridica.csv";
    
        /*
        public override double PagarImposto(float rendimento)
        {
            double resultado;

            if(rendimento <= 5000)
            {
                resultado = 0;
            } else if (rendimento > 5000 && rendimento <= 10000)
            {
                resultado =  rendimento * .08;
            }else{
                resultado =  (rendimento/100) * 10;
            }

            return resultado;
        }


        public bool ValidarCNPJ(string cnpj){
            if(cnpj.Length == 14 && cnpj.Substring(cnpj.Length - 4) == "0001"){
                return true;
            }
            return false;
        }
        */
        public string PrepararLinhasCsv(PessoaJuridica pj)
        {
            return $"{pj.Cnpj};{pj.Nome};{pj.RazaoSocial}";
        }

        public void Inserir(PessoaJuridica pj)
        {
            string[] linhas = {PrepararLinhasCsv(pj)};
            File.AppendAllLines(caminho, linhas);
        }

        public List<PessoaJuridica> Ler()
        {
            List<PessoaJuridica> listaPj = new List<PessoaJuridica>();
            string[] linhas = File.ReadAllLines(caminho);
            foreach(var cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(";");
                PessoaJuridica cadaPj = new PessoaJuridica();
                cadaPj.Cnpj = atributos[0];
                cadaPj.Nome = atributos[1];
                cadaPj.RazaoSocial = atributos[2];
                listaPj.Add(cadaPj);
            }
            return listaPj;
        }
    }
}