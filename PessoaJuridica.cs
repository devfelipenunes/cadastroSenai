namespace senai_cadastro
{
    public class PessoaJuridica : Pessoa
    {
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public PessoaJuridica(){}
    
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
    }
}