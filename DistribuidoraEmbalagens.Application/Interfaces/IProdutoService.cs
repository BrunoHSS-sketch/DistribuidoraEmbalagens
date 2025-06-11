using DistribuidoraEmbalagens.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraEmbalagens.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> GetAllAsync();
        Task<ProdutoDTO?> GetByIdAsync(int id);
        Task<ProdutoDTO> CreateAsync(ProdutoCreateDTO dto);
        Task<bool> UpdateAsync(int id, ProdutoCreateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
