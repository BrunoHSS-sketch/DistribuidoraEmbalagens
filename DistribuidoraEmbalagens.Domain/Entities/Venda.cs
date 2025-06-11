using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraEmbalagens.Domain.Entities
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public string Cliente { get; set; } = string.Empty;
        public ICollection<ItemVenda> Itens { get; set; } = new List<ItemVenda>();
        public decimal Total => Itens.Sum(i => i.Quantidade * i.PrecoUnitario);
    }
}
