using AutoMapper;
using DistribuidoraEmbalagens.Application.DTOs;
using DistribuidoraEmbalagens.Application.Interfaces;
using DistribuidoraEmbalagens.Domain.Entities;
using DistribuidoraEmbalagens.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DistribuidoraEmbalagens.Infrastructure.Services
{
    public class VendaService : IVendaService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public VendaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VendaDTO>> GetAllAsync()
        {
            var vendas = await _context.Vendas
                .Include(v => v.Itens)
                .ToListAsync();
            return vendas.Select(v => new VendaDTO
            {
                Id = v.Id,
                Cliente = v.Cliente,
                Data = v.Data,
                Total = v.Total
            });
        }

        public async Task<VendaDTO?> GetByIdAsync(int id)
        {
            var venda = await _context.Vendas
                .Include(v => v.Itens)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (venda == null) return null;

            return new VendaDTO
            {
                Id = venda.Id,
                Cliente = venda.Cliente,
                Data = venda.Data,
                Total = venda.Total
            };
        }

        public async Task<VendaDTO> RegistrarVendaAsync(VendaCreateDTO dto)
        {
            var venda = new Venda
            {
                Cliente = dto.Cliente,
                Itens = new List<ItemVenda>()
            };

            foreach (var itemDto in dto.Itens)
            {
                var produto = await _context.Produtos.FindAsync(itemDto.ProdutoId);
                if (produto == null)
                    throw new Exception($"Produto com ID {itemDto.ProdutoId} não encontrado.");

                if (produto.QuantidadeEstoque < itemDto.Quantidade)
                    throw new Exception($"Estoque insuficiente para o produto '{produto.Nome}'.");

                produto.RemoverEstoque(itemDto.Quantidade);

                var item = new ItemVenda
                {
                    ProdutoId = produto.Id,
                    Quantidade = itemDto.Quantidade,
                    PrecoUnitario = produto.PrecoVenda
                };

                venda.Itens.Add(item);
            }

            _context.Vendas.Add(venda);
            await _context.SaveChangesAsync();

            return new VendaDTO
            {
                Id = venda.Id,
                Cliente = venda.Cliente,
                Data = venda.Data,
                Total = venda.Total
            };
        }
    }
}
