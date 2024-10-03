using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgf.Controle
{
    internal class ProdutoLote
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public float Valor { get; set; }
        public int Quantidade { get; set; }
        public string Lote { get; set; }

        public void ProdutoLoteID(int id, string nomeProduto, float valor, int quantidade, string lote)
        {
            Id = id;
            NomeProduto = nomeProduto;
            Valor = valor;
            Quantidade = quantidade;
            Lote = lote;
        }

        public ProdutoLote(string nomeProduto, float valor, int quantidade, string lote)
        {
            NomeProduto = nomeProduto;
            Valor = valor;
            Quantidade = quantidade;
            Lote = lote;
        }

    }
}
