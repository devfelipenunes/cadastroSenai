namespace senai_cadastro
{
    public class PessoaJuridica : Pessoa
    {
        public string cnpj { get; set; }

        public string RazaoSocial { get; set; }

        public override void pagarImposto(float salario){}
    }
}