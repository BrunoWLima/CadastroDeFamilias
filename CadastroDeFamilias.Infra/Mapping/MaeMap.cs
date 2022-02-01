using CadastroDeFamilias.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroDeFamilias.Infra.Mapping
{
    class MaeMap : IEntityTypeConfiguration<Mae>
    {
        public void Configure(EntityTypeBuilder<Mae> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeCompleto).IsRequired().HasMaxLength(200);
            builder.Property(x => x.DataNascimento).IsRequired();
            builder.Property(x => x.FotoPath);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Endereco).IsRequired().HasMaxLength(200);
            builder.Property(x => x.TelefoneCelular).IsRequired();
            builder.Property(x => x.Altura).HasMaxLength(6);
            builder.Property(x => x.Peso).HasMaxLength(6);
            builder.Property(x => x.Senha).HasMaxLength(20);
            builder.Property(x => x.Ativo);
            builder.Property(x => x.PapelUsuario);
            builder.HasOne(x => x.Pai).WithOne(y => y.MaeModel).HasForeignKey<Pai>(z => z.IdMae);
            builder.HasMany(x => x.Filhos).WithOne(y => y.MaeModel).HasForeignKey(z => z.IdMae);
        }
    }
}
