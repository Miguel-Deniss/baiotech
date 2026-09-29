using System;

namespace BaioTech.Classes
{
    public class Aparelho
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string NumeroSerie { get; set; }
        public string Problema { get; set; }

        public Aparelho(int id, string tipo, string marca, string modelo, string numeroSerie, string problema)
        {
            this.Id = id;
            this.Tipo = tipo;
            this.Marca = marca;
            this.Modelo = modelo;
            this.NumeroSerie = numeroSerie;
            this.Problema = problema;
        }

        public void MostrarDados()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Tipo: " + Tipo);
            Console.WriteLine("Marca: " + Marca);
            Console.WriteLine("Modelo: " + Modelo);
            Console.WriteLine("Numero de serie: " + NumeroSerie);
            Console.WriteLine("Problema: " + Problema);
        }
    }
}