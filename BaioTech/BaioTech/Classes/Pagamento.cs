using BaioTech.Interfaces;
using System;

namespace BaioTech.Classes
{
    public class Pagamento : IPagamento
    {
        public double Valor { get; set; }
        public string FormaPagamento { get; set; }

        public Pagamento(double valor, string formaPagamento)
        {
            this.Valor = valor;
            this.FormaPagamento = formaPagamento;
        }

        public void RealizarPagamento()
        {
            Console.WriteLine("Pagamento realizado.");
            Console.WriteLine("Valor: R$ " + Valor.ToString("F2"));
            Console.WriteLine("Forma: " + FormaPagamento);
        }
    }
}