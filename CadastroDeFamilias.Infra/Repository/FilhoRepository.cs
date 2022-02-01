using CadastroDeFamilias.Domain.Models;

namespace CadastroDeFamilias.Infra.Repository
{
    public class FilhoRepository : Repository<Filho>
    {
        public FilhoRepository(CadastroDeFamiliasContext context) : base(context)
        {
        }
    }
}
