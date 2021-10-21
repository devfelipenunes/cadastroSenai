namespace senai_cadastro
{
    public class PessoaJuridica : Pessoa
    {
        public string cnpj { get; set; }

        public string RazaoSocial { get; set; }

        public override void pagarImposto(float salario){}
    
        public bool ValidarCNPJ(string cnpj){
            if(cnpj.Length == 14 && cnpj.Substring(cnpj.Length - 4) == "0001"){
                return true;
            }
            return false;
        }
    }
}