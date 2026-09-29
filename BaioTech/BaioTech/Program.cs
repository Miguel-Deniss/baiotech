using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using BaioTech.Classes;

namespace BaioTech
{
    class Program
    {
        static List<Cliente> clientes = new List<Cliente>();
        static List<Aparelho> aparelhos = new List<Aparelho>();
        static List<OrdemServico> ordens = new List<OrdemServico>();

        static int opcao = -1;

        static void Main(string[] args)
        {
            while (opcao != 0)
            {
                Console.Clear();

                Console.WriteLine("====================================");
                Console.WriteLine("              BAIOTECH");
                Console.WriteLine("     SISTEMA DE ASSISTENCIA TECNICA");
                Console.WriteLine("====================================");
                Console.WriteLine("1 - Cadastrar cliente");
                Console.WriteLine("2 - Cadastrar aparelho");
                Console.WriteLine("3 - Criar ordem de servico");
                Console.WriteLine("4 - Listar clientes");
                Console.WriteLine("5 - Listar aparelhos");
                Console.WriteLine("6 - Listar ordens de servico");
                Console.WriteLine("7 - Consultar cliente");
                Console.WriteLine("8 - Consultar aparelho");
                Console.WriteLine("9 - Atualizar ordem de servico");
                Console.WriteLine("10 - Finalizar ordem de servico");
                Console.WriteLine("11 - Salvar dados");
                Console.WriteLine("12 - Carregar dados");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("====================================");
                Console.Write("Digite uma opcao: ");

                try
                {
                    opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            CadastrarCliente();
                            break;

                        case 2:
                            CadastrarAparelho();
                            break;

                        case 3:
                            CriarOrdem();
                            break;

                        case 4:
                            ListarClientes();
                            break;

                        case 5:
                            ListarAparelhos();
                            break;

                        case 6:
                            ListarOrdens();
                            break;

                        case 7:
                            ConsultarCliente();
                            break;

                        case 8:
                            ConsultarAparelho();
                            break;

                        case 9:
                            AtualizarOrdem();
                            break;

                        case 10:
                            FinalizarOrdem();
                            break;

                        case 11:
                            SalvarDados();
                            break;

                        case 12:
                            CarregarDados();
                            break;

                        case 0:
                            Console.WriteLine("Sistema encerrado.");
                            break;

                        default:
                            Console.WriteLine("Opcao invalida.");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Digite uma opcao valida.");
                }

                if (opcao != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadLine();
                }
            }
        }

        static void CadastrarCliente()
        {
            Console.Clear();
            Console.WriteLine("CADASTRO DE CLIENTE");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Cliente cliente = new Cliente(nome, telefone, email);

            clientes.Add(cliente);

            Console.WriteLine("Cliente cadastrado.");
        }

        static void CadastrarAparelho()
        {
            Console.Clear();
            Console.WriteLine("CADASTRO DE APARELHO");

            if (clientes.Count == 0)
            {
                Console.WriteLine("Cadastre um cliente primeiro.");
                return;
            }

            Console.Write("ID do aparelho: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Tipo: ");
            string tipo = Console.ReadLine();

            Console.Write("Marca: ");
            string marca = Console.ReadLine();

            Console.Write("Modelo: ");
            string modelo = Console.ReadLine();

            Console.Write("Numero de serie: ");
            string numeroSerie = Console.ReadLine();

            Console.Write("Problema: ");
            string problema = Console.ReadLine();

            Aparelho aparelho = new Aparelho(
                id,
                tipo,
                marca,
                modelo,
                numeroSerie,
                problema
            );

            aparelhos.Add(aparelho);

            Console.WriteLine("Aparelho cadastrado.");
        }

        static void CriarOrdem()
        {
            Console.Clear();
            Console.WriteLine("NOVA ORDEM DE SERVICO");

            if (clientes.Count == 0 || aparelhos.Count == 0)
            {
                Console.WriteLine("Cadastre cliente e aparelho primeiro.");
                return;
            }

            Console.Write("Nome do cliente: ");
            string nome = Console.ReadLine();

            Cliente cliente = clientes.Find(c =>
                c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

            if (cliente == null)
            {
                Console.WriteLine("Cliente nao encontrado.");
                return;
            }

            Console.Write("ID do aparelho: ");
            int id = int.Parse(Console.ReadLine());

            Aparelho aparelho = aparelhos.Find(a => a.Id == id);

            if (aparelho == null)
            {
                Console.WriteLine("Aparelho nao encontrado.");
                return;
            }

            OrdemServico ordem = new OrdemServico(cliente, aparelho);

            Console.Write("Diagnostico: ");
            ordem.Diagnostico = Console.ReadLine();

            Console.Write("Valor da mao de obra: ");
            ordem.MaoDeObra = double.Parse(Console.ReadLine());

            Console.Write("Nome do servico: ");
            string nomeServico = Console.ReadLine();

            Console.Write("Valor do servico: ");
            double valorServico = double.Parse(Console.ReadLine());

            Servico servico = new Servico(nomeServico, valorServico);

            ordem.AdicionarServico(servico);

            Console.Write("Nome da peca: ");
            string nomePeca = Console.ReadLine();

            Console.Write("Valor da peca: ");
            double valorPeca = double.Parse(Console.ReadLine());

            Peca peca = new Peca(nomePeca, valorPeca);

            ordem.AdicionarPeca(peca);

            Console.Write("Desconto: ");
            ordem.Desconto = double.Parse(Console.ReadLine());

            ordens.Add(ordem);

            Console.WriteLine();
            Console.WriteLine("Ordem criada.");
            Console.WriteLine("Numero da ordem: " + ordem.Id);
            Console.WriteLine("Valor total: R$ " +
                ordem.CalcularTotal().ToString("F2"));
        }

        static void ListarClientes()
        {
            Console.Clear();
            Console.WriteLine("CLIENTES");

            if (clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
                return;
            }

            foreach (Cliente cliente in clientes)
            {
                cliente.MostrarDados();
                Console.WriteLine("--------------------------------");
            }
        }

        static void ListarAparelhos()
        {
            Console.Clear();
            Console.WriteLine("APARELHOS");

            if (aparelhos.Count == 0)
            {
                Console.WriteLine("Nenhum aparelho cadastrado.");
                return;
            }

            foreach (Aparelho aparelho in aparelhos)
            {
                aparelho.MostrarDados();
                Console.WriteLine("--------------------------------");
            }
        }

        static void ListarOrdens()
        {
            Console.Clear();
            Console.WriteLine("ORDENS DE SERVICO");

            if (ordens.Count == 0)
            {
                Console.WriteLine("Nenhuma ordem cadastrada.");
                return;
            }

            foreach (OrdemServico ordem in ordens)
            {
                ordem.MostrarDados();
            }
        }

        static void ConsultarCliente()
        {
            Console.Clear();

            Console.Write("Digite o nome do cliente: ");
            string nome = Console.ReadLine();

            Cliente cliente = clientes.Find(c =>
                c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

            if (cliente == null)
            {
                Console.WriteLine("Cliente nao encontrado.");
                return;
            }

            cliente.MostrarDados();
        }

        static void ConsultarAparelho()
        {
            Console.Clear();

            Console.Write("Digite o ID do aparelho: ");
            int id = int.Parse(Console.ReadLine());

            Aparelho aparelho = aparelhos.Find(a => a.Id == id);

            if (aparelho == null)
            {
                Console.WriteLine("Aparelho nao encontrado.");
                return;
            }

            aparelho.MostrarDados();
        }

        static void AtualizarOrdem()
        {
            Console.Clear();

            Console.Write("Digite o numero da ordem: ");
            int id = int.Parse(Console.ReadLine());

            OrdemServico ordem = ordens.Find(o => o.Id == id);

            if (ordem == null)
            {
                Console.WriteLine("Ordem nao encontrada.");
                return;
            }

            Console.Write("Novo diagnostico: ");
            ordem.Diagnostico = Console.ReadLine();

            Console.Write("Novo valor da mao de obra: ");
            ordem.MaoDeObra = double.Parse(Console.ReadLine());

            Console.Write("Novo desconto: ");
            ordem.Desconto = double.Parse(Console.ReadLine());

            Console.WriteLine("Ordem atualizada.");
        }

        static void FinalizarOrdem()
        {
            Console.Clear();

            Console.Write("Digite o numero da ordem: ");
            int id = int.Parse(Console.ReadLine());

            OrdemServico ordem = ordens.Find(o => o.Id == id);

            if (ordem == null)
            {
                Console.WriteLine("Ordem nao encontrada.");
                return;
            }

            ordem.Finalizar();

            Console.WriteLine("Ordem finalizada.");
        }

        static void SalvarDados()
        {
            try
            {
                string jsonClientes = JsonConvert.SerializeObject(clientes, Formatting.Indented);
                string jsonAparelhos = JsonConvert.SerializeObject(aparelhos, Formatting.Indented);
                string jsonOrdens = JsonConvert.SerializeObject(ordens, Formatting.Indented);

                File.WriteAllText("clientes.json", jsonClientes);
                File.WriteAllText("aparelhos.json", jsonAparelhos);
                File.WriteAllText("ordens.json", jsonOrdens);

                Console.WriteLine("Dados salvos com sucesso.");
            }
            catch
            {
                Console.WriteLine("Erro ao salvar os dados.");
            }
        }

        static void CarregarDados()
        {
            try
            {
                if (File.Exists("clientes.json"))
                {
                    string jsonClientes = File.ReadAllText("clientes.json");

                    List<Cliente> dadosClientes =
                        JsonConvert.DeserializeObject<List<Cliente>>(jsonClientes);

                    if (dadosClientes != null)
                    {
                        clientes = dadosClientes;
                    }
                }

                if (File.Exists("aparelhos.json"))
                {
                    string jsonAparelhos = File.ReadAllText("aparelhos.json");

                    List<Aparelho> dadosAparelhos =
                        JsonConvert.DeserializeObject<List<Aparelho>>(jsonAparelhos);

                    if (dadosAparelhos != null)
                    {
                        aparelhos = dadosAparelhos;
                    }
                }

                if (File.Exists("ordens.json"))
                {
                    string jsonOrdens = File.ReadAllText("ordens.json");

                    List<OrdemServico> dadosOrdens =
                        JsonConvert.DeserializeObject<List<OrdemServico>>(jsonOrdens);

                    if (dadosOrdens != null)
                    {
                        ordens = dadosOrdens;
                    }
                }

                Console.WriteLine("Dados carregados.");
            }
            catch
            {
                Console.WriteLine("Erro ao carregar os dados.");
            }
        }
    }
}