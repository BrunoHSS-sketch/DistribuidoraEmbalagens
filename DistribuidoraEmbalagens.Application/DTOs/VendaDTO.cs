using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraEmbalagens.Application.DTOs
{
    public class VendaDTO
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public decimal Total { get; set; }
    }
}
