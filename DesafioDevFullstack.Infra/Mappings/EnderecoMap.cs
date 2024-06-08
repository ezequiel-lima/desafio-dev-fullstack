using DesafioDevFullstack.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioDevFullstack.Infra.Mappings
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("TEndereco");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Cep)
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(x => x.Estado)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Cidade)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Bairro)
                .HasMaxLength(200);

            builder.Property(x => x.Rua)
                .HasMaxLength(200);

            builder.Property(x => x.Numero)
                .HasMaxLength(50);
        }
    }
}
