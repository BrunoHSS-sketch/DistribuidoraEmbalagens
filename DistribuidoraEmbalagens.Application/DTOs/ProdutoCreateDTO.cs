using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraEmbalagens.Application.DTOs
{
    public class ProdutoCreateDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string Unidade { get; set; } = string.Empty;
        public decimal PrecoCompra { get; set; }
        public decimal PrecoVenda { get; set; }
        public int QuantidadeEstoque { get; set; }
    }
}
