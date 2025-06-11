
using AutoMapper;
using DistribuidoraEmbalagens.Application.DTOs;
using DistribuidoraEmbalagens.Application.Interfaces;
using DistribuidoraEmbalagens.Domain.Entities;
using DistribuidoraEmbalagens.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DistribuidoraEmbalagens.Infrastructure.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProdutoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoDTO>> GetAllAsync()
        {
            var produtos = await _context.Produtos.ToListAsync();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
        }

        public async Task<ProdutoDTO?> GetByIdAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            return produto == null ? null : _mapper.Map<ProdutoDTO>(produto);
        }

        public async Task<ProdutoDTO> CreateAsync(ProdutoCreateDTO dto)
        {
            var produto = _mapper.Map<Produto>(dto);
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProdutoDTO>(produto);
        }

        public async Task<bool> UpdateAsync(int id, ProdutoCreateDTO dto)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null) return false;

            _mapper.Map(dto, produto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null) return false;

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
