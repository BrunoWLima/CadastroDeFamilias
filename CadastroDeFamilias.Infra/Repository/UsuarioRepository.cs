using CadastroDeFamilias.Domain.Models;

namespace CadastroDeFamilias.Infra.Repository
{
    public class UsuarioRepository : Repository<Usuario>
    {
        public UsuarioRepository(CadastroDeFamiliasContext context) : base(context)
        {
        }
    }
}
