using System;

namespace BaioTech.Classes
{
    public class Cliente : Pessoa
    {
        public string Email { get; set; }

        public Cliente(string nome, string telefone, string email)
            : base(nome, telefone)
        {
            this.Email = email;
        }

        public override void MostrarDados()
        {
            Console.WriteLine("Nome: " + Nome);
            Console.WriteLine("Telefone: " + Telefone);
            Console.WriteLine("Email: " + Email);
        }
    }
}