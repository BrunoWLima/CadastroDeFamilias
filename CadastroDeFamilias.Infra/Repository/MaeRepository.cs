using CadastroDeFamilias.Domain.Models;

namespace CadastroDeFamilias.Infra.Repository
{
    public class MaeRepository : Repository<Mae>
    {
        public MaeRepository(CadastroDeFamiliasContext context) : base(context)
        {
        }
    }
}
