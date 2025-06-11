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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("Produtos");

            modelBuilder.Entity<Produto>()
                .Property(p => p.PrecoCompra)
                .HasPrecision(18, 2); 

            modelBuilder.Entity<Produto>()
                .Property(p => p.PrecoVenda)
                .HasPrecision(18, 2);
        }
    }
}
