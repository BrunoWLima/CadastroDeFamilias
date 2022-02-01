using CadastroDeFamilias.Domain.Models;

namespace CadastroDeFamilias.Infra.Repository
{
    public class PaiRepository : Repository<Pai>
    {
        public PaiRepository(CadastroDeFamiliasContext context) : base(context)
        {
        }
    }
}
