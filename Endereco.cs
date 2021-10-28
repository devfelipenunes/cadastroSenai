namespace senai_cadastro
{
    public class Endereco
    {
        private string Logradouro { get; set; }

        private int Numero { get; set; }

        private string Complemento { get; set; }

        private bool EnderecoComercial { get; set; }

        public Endereco(string logradouro, int numero, string complemento, bool enderecoComercial)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            EnderecoComercial = enderecoComercial;
        }

        public override string ToString()
        {
            return $"Logradouro: {Logradouro} " +
                   $"|Numero: {Numero} " +
                   $"|Complemento: {Complemento}" ;
        }
    }
}