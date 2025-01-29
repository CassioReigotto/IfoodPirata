using System.Reflection.Metadata.Ecma335;

namespace IfoodPirata
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Lanche> lanches = new();
            List<Ingrediente> ingredientes = new();
            



            Console.WriteLine("Deseja adicionar um lanche?");
            string resposta = Console.ReadLine();
            if (resposta == "sim")
            {
                lanches.Add(new Lanche("Guilherme assado", 1.50, ingredientes));

                Console.WriteLine($"deseja adicionar ingredientes ao lanche {lanches.First().nome}?");
                bool adicionarIngrediente = Console.ReadLine() == "sim";

                while (adicionarIngrediente)
                {


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
                    lanches.First().ingredientes.Add(ingrediente);

                    Console.WriteLine($"deseja adicionar um novo ingrediente ao lanche {lanches.First().nome}?");
                    adicionarIngrediente = Console.ReadLine() == "sim";


                }

            }
            else
            {
                Console.Clear();
                Console.WriteLine("falou gay.");
                Thread.Sleep(1000);

            }
            Console.WriteLine($"O lanche {lanches.First().nome} foi adicionado, com o valor de {lanches.First().preco} com os ingredientes a baixo:");
            foreach (Ingrediente ingrediente in lanches.First().ingredientes)
            {
                Console.Write($"Nome: {ingrediente.Nome}, ");
                Console.Write($"Preco: {ingrediente.Preco}, ");
                Console.Write($"Quantidade: {ingrediente.Quantidade} ");
                Console.WriteLine($"{ingrediente.Medida}");
            }


        }
    }
}
