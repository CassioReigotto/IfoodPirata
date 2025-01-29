using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfoodPirata
{
    internal class Ingrediente
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public TipoMedida Medida { get; set; }

        public Ingrediente()
        {
          
        }
        public Ingrediente(string nome, double preco, int quantidade,  TipoMedida medida )
        {
            this.Nome = nome;
            this.Preco = preco;
            this.Quantidade = quantidade;
            this.Medida = medida;
        }






    }
}
