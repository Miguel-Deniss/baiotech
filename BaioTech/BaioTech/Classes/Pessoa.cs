using System;

namespace BaioTech.Classes
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public Pessoa(string nome, string telefone)
        {
            this.Nome = nome;
            this.Telefone = telefone;
        }

        public virtual void MostrarDados()
        {
            Console.WriteLine("Nome: " + Nome);
            Console.WriteLine("Telefone: " + Telefone);
        }
    }
}