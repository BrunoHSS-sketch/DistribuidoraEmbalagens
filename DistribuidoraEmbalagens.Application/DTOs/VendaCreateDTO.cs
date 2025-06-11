using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraEmbalagens.Application.DTOs
{
    public class VendaCreateDTO
    {
        public string Cliente { get; set; } = string.Empty;
        public List<ItemVendaDTO> Itens { get; set; } = new();
    }
}
