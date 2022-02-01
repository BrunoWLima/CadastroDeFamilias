using CadastroDeFamilias.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroDeFamilias.Infra.Mapping
{
    class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeCompleto).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.NomeLogin).HasMaxLength(20);
            builder.Property(x => x.Senha).HasMaxLength(20);
            builder.Property(x => x.PapelUsuario);
            builder.Property(x => x.Ativo);
        }
    }
}
