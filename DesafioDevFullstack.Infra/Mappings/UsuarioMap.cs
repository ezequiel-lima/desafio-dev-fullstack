using DesafioDevFullstack.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DesafioDevFullstack.Infra.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("TUsuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Senha)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Role)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
