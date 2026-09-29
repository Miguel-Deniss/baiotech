using System;

namespace BaioTech.Classes
{
    public class Tecnico : Funcionario
    {
        public string Especialidade { get; set; }

        public Tecnico(string nome, string telefone, string especialidade)
            : base(nome, telefone, "Tecnico")
        {
            this.Especialidade = especialidade;
        }

        public override void MostrarDados()
        {
            Console.WriteLine("Nome: " + Nome);
            Console.WriteLine("Telefone: " + Telefone);
            Console.WriteLine("Cargo: " + Cargo);
            Console.WriteLine("Especialidade: " + Especialidade);
        }
    }
}