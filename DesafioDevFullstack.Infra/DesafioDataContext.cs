using DesafioDevFullstack.Domain.Entities;
using DesafioDevFullstack.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DesafioDevFullstack.Infra
{
    public class DesafioDataContext : DbContext
    {
        public DesafioDataContext(DbContextOptions<DesafioDataContext> options) : base(options) { }

        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EnderecoMap());
        }
    }
}
