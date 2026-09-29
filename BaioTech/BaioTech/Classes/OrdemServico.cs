using System;
using System.Collections.Generic;

namespace BaioTech.Classes
{
    public class OrdemServico
    {
        private static int proximoId = 1;

        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Aparelho Aparelho { get; set; }
        public Tecnico Tecnico { get; set; }
        public string Diagnostico { get; set; }
        public string Status { get; set; }
        public double MaoDeObra { get; set; }
        public double Desconto { get; set; }

        public List<Servico> Servicos { get; set; }
        public List<Peca> Pecas { get; set; }

        public OrdemServico(Cliente cliente, Aparelho aparelho)
        {
            this.Id = proximoId++;
            this.Cliente = cliente;
            this.Aparelho = aparelho;
            this.Status = "Aberta";
            this.Servicos = new List<Servico>();
            this.Pecas = new List<Peca>();
        }

        public void AdicionarServico(Servico servico)
        {
            Servicos.Add(servico);
        }

        public void AdicionarPeca(Peca peca)
        {
            Pecas.Add(peca);
        }

        public double CalcularTotal()
        {
            double total = MaoDeObra;

            foreach (Servico servico in Servicos)
            {
                total += servico.Valor;
            }

            foreach (Peca peca in Pecas)
            {
                total += peca.Valor;
            }

            total -= Desconto;

            if (total < 0)
            {
                total = 0;
            }

            return total;
        }

        public void Finalizar()
        {
            Status = "Finalizada";
        }

        public void MostrarDados()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("ORDEM DE SERVICO: " + Id);
            Console.WriteLine("Cliente: " + Cliente.Nome);
            Console.WriteLine("Aparelho: " + Aparelho.Marca + " " + Aparelho.Modelo);
            Console.WriteLine("Problema: " + Aparelho.Problema);
            Console.WriteLine("Diagnostico: " + Diagnostico);
            Console.WriteLine("Status: " + Status);
            Console.WriteLine("Mao de obra: R$ " + MaoDeObra.ToString("F2"));
            Console.WriteLine("Desconto: R$ " + Desconto.ToString("F2"));
            Console.WriteLine("Total: R$ " + CalcularTotal().ToString("F2"));
            Console.WriteLine("--------------------------------");
        }
    }
}