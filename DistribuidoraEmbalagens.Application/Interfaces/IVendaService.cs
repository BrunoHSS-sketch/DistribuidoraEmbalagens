using DistribuidoraEmbalagens.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraEmbalagens.Application.Interfaces
{
    public interface IVendaService
    {
        Task<IEnumerable<VendaDTO>> GetAllAsync();
        Task<VendaDTO?> GetByIdAsync(int id);
        Task<VendaDTO> RegistrarVendaAsync(VendaCreateDTO dto);
    }
}
