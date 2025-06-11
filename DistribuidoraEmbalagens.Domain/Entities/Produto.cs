using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraEmbalagens.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; } 
        public string Nome { get; set; } = string.Empty;
        public string Unidade { get; set; } = string.Empty;
        public decimal PrecoCompra { get; set; }
        public decimal PrecoVenda { get; set; }
        public int QuantidadeEstoque { get; set; }
        
        public void AdicionarEstoque(int quantidade)
        {
            if (quantidade < 0)
            {
                throw new ArgumentException("A quantidade a ser adicionada não pode ser negativa.", nameof(quantidade));
                QuantidadeEstoque += quantidade;
            }
        }

        public void RemoverEstoque(int quantidade)
        {
            if (quantidade < 0)
            {
                throw new ArgumentException("A quantidade a ser removida não pode ser negativa.", nameof(quantidade));
            }
            if (QuantidadeEstoque < quantidade)
            {
                throw new InvalidOperationException("Não há estoque suficiente para remover a quantidade solicitada.");
            }
            QuantidadeEstoque -= quantidade;
        }

    }
}
