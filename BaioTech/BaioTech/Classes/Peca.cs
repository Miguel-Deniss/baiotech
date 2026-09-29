using System;

namespace BaioTech.Classes
{
    public class Peca
    {
        public string Nome { get; set; }
        public double Valor { get; set; }

        public Peca(string nome, double valor)
        {
            this.Nome = nome;
            this.Valor = valor;
        }

        public void MostrarDados()
        {
            Console.WriteLine("Peca: " + Nome);
            Console.WriteLine("Valor: R$ " + Valor.ToString("F2"));
        }
    }
}