using AutoMapper;
using CadastroDeFamilias.Infra;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeFamilias.Api.Controllers
{
    [ApiController]
    public abstract class CadastroDeFamiliasApiController<TModel, TViewModel> : ApiController<TModel, TViewModel> where TModel : class
    {
        public int IdContaUsuario { get; set; }

        protected CadastroDeFamiliasUnitOfWork SUOW => (CadastroDeFamiliasUnitOfWork)UOW;

        public CadastroDeFamiliasApiController(IUnitOfWork uow, IRepository<TModel> repo, IMapper mapper) : base(uow, repo, mapper)
        {
            if (CurrentUser != null && CurrentUser.Identity.IsAuthenticated)
            {
                string conta = CurrentUser.FindFirst("IdConta").Value;
                if (!string.IsNullOrEmpty(conta))
                    IdContaUsuario = int.Parse(conta);
            }
        }
    }
}
