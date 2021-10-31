using System;

namespace senaiCadastro
{
    public class Menu
    {
        public string Ler()
        {
            return Console.ReadLine();
        }

        public void Escrever(string msg)
        {
            Console.WriteLine(msg);
        }
    
        public void Limpar()
        {
            Console.Clear();
        }

        public void SegurarTela()
        {
            Console.ReadKey();
        }
    }
}