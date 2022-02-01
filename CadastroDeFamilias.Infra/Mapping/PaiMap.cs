using CadastroDeFamilias.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroDeFamilias.Infra.Mapping
{
    class PaiMap : IEntityTypeConfiguration<Pai>
    {
        public void Configure(EntityTypeBuilder<Pai> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeCompleto).IsRequired().HasMaxLength(200);
            builder.Property(x => x.DataNascimento).IsRequired();
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.TelefoneCelular).IsRequired();
            builder.Property(x => x.Altura).HasMaxLength(6);
            builder.Property(x => x.Peso).HasMaxLength(6);
            builder.Property(x => x.Senha).HasMaxLength(20);
            builder.Property(x => x.PapelUsuario);
        }
    }
}
