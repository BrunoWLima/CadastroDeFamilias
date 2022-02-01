using AutoMapper;
using CadastroDeFamilias.Infra;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace CadastroDeFamilias.Api.Controllers
{
    public abstract class BaseController<TModel, TViewModel> : BaseApiController where TModel : class
    {
        public ClaimsPrincipal CurrentUser { get; set; }

        public int IdUsuario { get; set; }

        protected IMapper Mapeador { get; set; }

        protected virtual IUnitOfWork UOW { get; set; }

        public BaseController(IUnitOfWork uow, IMapper mapper)
        {
            var httpContext = new HttpContextAccessor().HttpContext;
            UOW = uow;
            Mapeador = mapper;
            CurrentUser = httpContext?.User;
            string idUsuario = CurrentUser?.FindFirstValue("IdUsuario");
            IdUsuario = string.IsNullOrEmpty(idUsuario) ? 0 : int.Parse(idUsuario);
        }

        protected virtual TViewModel MapearParaViewModel(TModel model) => Mapeador.Map<TModel, TViewModel>(model);

        protected List<TViewModel> MapearParaViewModel(IEnumerable<TModel> model) => model.Select(x => MapearParaViewModel(x)).ToList();

        protected virtual TModel MapearParaModel(TViewModel model) => Mapeador.Map<TViewModel, TModel>(model);

        protected List<TModel> MapearParaModel(IEnumerable<TViewModel> model) => model.Select(x => MapearParaModel(x)).ToList();

        protected virtual IQueryable<TModel> AntesDeEnumerar(IQueryable<TModel> query) => query;

        protected virtual void AntesDeCriar(TModel model, TViewModel viewModel) { }

        protected virtual void DepoisDeCriar(TViewModel viewModel, TModel model) { }

        protected virtual void AntesDeAtualizar(TModel model, TViewModel viewModel) { }

        protected virtual void DepoisDeAtualizar(TViewModel viewModel, TModel model) { }

        protected virtual void AntesDeRemover(TModel model) { }

        protected virtual void DepoisDeRemover(TViewModel viewModel) { }
    }
}
