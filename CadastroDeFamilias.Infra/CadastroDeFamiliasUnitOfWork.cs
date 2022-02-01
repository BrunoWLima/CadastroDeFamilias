using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CadastroDeFamilias.Infra
{
    public class CadastroDeFamiliasUnitOfWork : UnitOfWork
    {
        public CadastroDeFamiliasUnitOfWork(CadastroDeFamiliasContext context) : base(context) { }

        public CadastroDeFamiliasUnitOfWork(DbContext context, ClaimsPrincipal principal) : base(context, principal) { }
    }
}
