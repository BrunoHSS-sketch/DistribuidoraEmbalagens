using AutoMapper;
using DistribuidoraEmbalagens.Domain.Entities;
using DistribuidoraEmbalagens.Application.DTOs;

namespace DistribuidoraEmbalagens.Infrastructure.Mappings
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
            CreateMap<ProdutoCreateDTO, Produto>().ReverseMap();
        }
    }
}