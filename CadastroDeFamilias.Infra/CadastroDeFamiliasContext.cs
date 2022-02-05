using CadastroDeFamilias.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CadastroDeFamilias.Infra
{
    public class CadastroDeFamiliasContext : DbContext
    {
        public CadastroDeFamiliasContext(DbContextOptions<CadastroDeFamiliasContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            #region Usuário
            builder.Entity<Usuario>().HasData(new Usuario()
            {
                Id = 1,
                NomeCompleto = "ADM MASTER",
                Email = "dev.brunolima@hotmail.com",
                NomeLogin = "admin",
                Senha = "admin123",
                PapelUsuario = PapelUsuario.Master,
                Ativo = true,
            });
            #endregion

            base.OnModelCreating(builder);
        }
    }
}
