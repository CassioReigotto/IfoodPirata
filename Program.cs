/*MEU PROGRAMA*/

using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using IfoodPirata.entity;
using IfoodPirata.entity.@enum;

namespace IfoodPirata
{
    internal class Program
    {

        static Dictionary<Lanche, List<Ingrediente>> lanchesDicionario = new();
        
        
         public static void Main()
        {
            

            while (true)
            {
                Logo();
                Console.WriteLine("\n1 - Criar lanche");
                Console.WriteLine("2 - Mostrar lanches");
                Console.WriteLine("0 - Sair");
                Console.Write("Digite a opcao desejada: ");
                Opcoes opcaoescolhida = (Opcoes)int.Parse(Console.ReadLine());

                switch (opcaoescolhida)
                {
                    case Opcoes.CriarLanche:
                        AdicionarLanche();
                        break;
                    case Opcoes.MostrarLanches:
                        MostrarLanches();
                        break;
                    case Opcoes.Sair:
                        Console.Clear();
                        Console.WriteLine("Saindo...");
                        Thread.Sleep(1000);
                        return;
                        break;
                    default:
                        Console.WriteLine("Opcao invalida");
                        break;
                }
            }
           



        }


        public static void Logo()
        {
            Console.WriteLine(@"
██╗███████╗░█████╗░░█████╗░██████╗░██████╗░██╗██████╗░░█████╗░████████╗░█████╗░
██║██╔════╝██╔══██╗██╔══██╗██╔══██╗██╔══██╗██║██╔══██╗██╔══██╗╚══██╔══╝██╔══██╗
██║█████╗░░██║░░██║██║░░██║██║░░██║██████╔╝██║██████╔╝███████║░░░██║░░░███████║
██║██╔══╝░░██║░░██║██║░░██║██║░░██║██╔═══╝░██║██╔══██╗██╔══██║░░░██║░░░██╔══██║
██║██║░░░░░╚█████╔╝╚█████╔╝██████╔╝██║░░░░░██║██║░░██║██║░░██║░░░██║░░░██║░░██║
╚═╝╚═╝░░░░░░╚════╝░░╚════╝░╚═════╝░╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝░░░╚═╝░░░╚═╝░░╚═╝");

        }

        public  static void AdicionarLanche()
        {
           
            Console.WriteLine("Deseja adicionar um lanche?");
            string resposta = Console.ReadLine();
            if (resposta == "sim")
            {
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("Qual vai ser o nome do lanche?");
                string lancheAdicionado = Console.ReadLine();

                Console.WriteLine("Qual vai ser o preco do lanche?");
                double precoDoLanche = double.Parse(Console.ReadLine());

                Lanche novoLanche = new(lancheAdicionado, precoDoLanche, new List<Ingrediente>());
                lanchesDicionario[novoLanche] = new List<Ingrediente>();
                Console.WriteLine($"O lanche {novoLanche.nome} foi adicionado, com o valor de R${novoLanche.preco:F2} ");

                Console.WriteLine($"deseja adicionar ingredientes ao lanche {novoLanche.nome}?");
                bool adicionarIngrediente = Console.ReadLine() == "sim";

                while (adicionarIngrediente)
                {

                    Thread.Sleep(1000);
                    Console.Clear();
                    Ingrediente ingrediente = new();

                    Console.WriteLine("Qual o nome do ingrediente?");
                    ingrediente.Nome = Console.ReadLine();



                    Console.WriteLine("Qual o preco do ingrediente?");
                    ingrediente.Preco = double.Parse(Console.ReadLine());

                    Console.WriteLine("Qual a quantidade do ingrediente?");
                    ingrediente.Quantidade = int.Parse(Console.ReadLine());


                    Console.WriteLine("Qual o tipo medida do ingrediente?\n(unidade = 1, gramas = 2, mililitros = 3)");

                    ingrediente.Medida = (TipoMedida)int.Parse(Console.ReadLine());
                    Console.WriteLine($"O ingrediente {ingrediente.Nome} foi adicionado");
                    lanchesDicionario[novoLanche].Add(ingrediente);

                    

                    Console.WriteLine($"deseja adicionar um novo ingrediente ao lanche {novoLanche.nome}?");
                    
                    adicionarIngrediente = Console.ReadLine() == "sim";
                    Console.Clear();
                    Thread.Sleep(1000);
                    

                }Console.Clear();

            }
            else
            {
                Console.Clear();
                Console.WriteLine("falou.");
                Thread.Sleep(1000);

            }




        }

        public static void MostrarLanches()
        {
            Console.Clear();
            Console.WriteLine("Lanches adicionados:");
            foreach (var item in lanchesDicionario.Keys)
            {
                Console.WriteLine($"Nome: {item.nome}  ->  Preco: R${item.preco}");

            }
            Console.WriteLine("Deseja ver os ingredientes de algum lanche??");
            bool mostrarIngredientes = Console.ReadLine() == "sim";

            if (mostrarIngredientes)
            {
                Console.WriteLine("Digite o nome do lanche:");
                string lancheEscolhido = Console.ReadLine();

                Lanche lancheEncontrado = lanchesDicionario.Keys.FirstOrDefault(l => l.nome == lancheEscolhido);
                if (lanchesDicionario[lancheEncontrado].Count == 0)
                {
                    Console.WriteLine("Nenhum ingrediente encontrado");
                }
                else
                {
                    Console.WriteLine($"Ingredientes do lanche {lancheEncontrado.nome}:");
                    foreach (var ingrediente in lanchesDicionario[lancheEncontrado])
                    {

                        Console.Write($"Nome do Ingrediente: {ingrediente.Nome} ");
                        Console.Write($"Preco: {ingrediente.Preco}, ");
                        Console.Write($"Quantidade: {ingrediente.Quantidade} ");
                        Console.WriteLine($"{ingrediente.Medida}");

                    }
                }
                
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Voltando...");
                Thread.Sleep(1500);
                Console.Clear();
            }

        }



    }
}
