namespace senai_cadastro
{
    public class PessoaJuridica : Pessoa
    {
        private string Cnpj { get; set; }

        private string RazaoSocial { get; set; }

        public PessoaJuridica(string cnpj, string razaoSocial)
        {
            Cnpj = cnpj;
            RazaoSocial = razaoSocial;
        }

        public override void pagarImposto(float salario){}
    
        public bool ValidarCNPJ(string cnpj){
            if(cnpj.Length == 14 && cnpj.Substring(cnpj.Length - 4) == "0001"){
                return true;
            }
            return false;
        }
    }
}