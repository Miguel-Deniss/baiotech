using System;

namespace BaioTech.Classes
{
    public class Servico
    {
        public string Nome { get; set; }
        public double Valor { get; set; }

        public Servico(string nome, double valor)
        {
            this.Nome = nome;
            this.Valor = valor;
        }

        public void MostrarDados()
        {
            Console.WriteLine("Servico: " + Nome);
            Console.WriteLine("Valor: R$ " + Valor.ToString("F2"));
        }
    }
}