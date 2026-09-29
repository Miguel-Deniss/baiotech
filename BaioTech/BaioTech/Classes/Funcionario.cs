using System;

namespace BaioTech.Classes
{
    public class Funcionario : Pessoa
    {
        public string Cargo { get; set; }

        public Funcionario(string nome, string telefone, string cargo)
            : base(nome, telefone)
        {
            this.Cargo = cargo;
        }

        public override void MostrarDados()
        {
            Console.WriteLine("Nome: " + Nome);
            Console.WriteLine("Telefone: " + Telefone);
            Console.WriteLine("Cargo: " + Cargo);
        }
    }
}