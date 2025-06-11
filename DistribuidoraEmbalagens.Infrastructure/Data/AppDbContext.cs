using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DistribuidoraEmbalagens.Domain.Entities;


namespace DistribuidoraEmbalagens.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Produto> Produtos => Set<Produto>();
        public DbSet<Venda> Vendas => Set<Venda>();
        public DbSet<ItemVenda> ItensVenda => Set<ItemVenda>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("Produtos");

            modelBuilder.Entity<Produto>()
                .Property(p => p.PrecoCompra)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Produto>()
                .Property(p => p.PrecoVenda)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ItemVenda>()
                .Property(i => i.PrecoUnitario)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ItemVenda>()
                .HasOne(i => i.Produto)
                .WithMany() 
                .HasForeignKey(i => i.ProdutoId);

            modelBuilder.Entity<ItemVenda>()
                .HasOne(i => i.Venda)
                .WithMany(v => v.Itens)
                .HasForeignKey(i => i.VendaId);
        }
    }
}
