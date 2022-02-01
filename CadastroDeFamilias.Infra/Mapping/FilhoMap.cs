using CadastroDeFamilias.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroDeFamilias.Infra.Mapping
{
    public class FilhoMap : IEntityTypeConfiguration<Filho>
    {
        public void Configure(EntityTypeBuilder<Filho> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeCompleto).IsRequired().HasMaxLength(200);
            builder.Property(x => x.DataNascimento).IsRequired();
            builder.Property(x => x.Altura).HasMaxLength(6);
            builder.Property(x => x.Peso).HasMaxLength(6);
        }
    }
}
