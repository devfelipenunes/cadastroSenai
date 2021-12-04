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
            Console.Write(msg);
        }

        public void Limpar()
        {
            Console.Clear();
        }

        public void SeguraTela()
        {
            Console.ReadKey();
        }
    }
}