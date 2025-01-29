using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfoodPirata
{
    internal class Lanche
    {
        public string nome { get; set; }
        public double preco { get; set; }
        public List<Ingrediente> ingredientes { get; set; }

        public Lanche(string nome, double preco, List<Ingrediente> ingredientes)
        {
            this.nome = nome;
            this.preco = preco;
            this.ingredientes = ingredientes;
        }


       
    }
}
