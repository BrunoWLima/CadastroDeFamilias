using AutoMapper;
using CadastroDeFamilias.Infra;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeFamilias.Api.Controllers
{
    public abstract class ApiController<TModel, TViewModel> : BaseController<TModel, TViewModel> where TModel : class
    {
        protected IRepository<TModel> Repo { get; set; }

        public ApiController(IUnitOfWork uow, IRepository<TModel> repo, IMapper mapper) : base(uow, mapper)
        {
            Repo = repo;
        }

        [HttpPost]
        [Route("[controller]/Criar")]
        public virtual ActionResult Criar(TViewModel viewModel)
        {
            var model = MapearParaModel(viewModel);

            AntesDeCriar(model, viewModel);

            Repo.Add(model);

            UOW.SaveChanges();

            DepoisDeCriar(viewModel, model);

            viewModel = MapearParaViewModel(model);

            return Ok(viewModel);
        }

        [HttpPut]
        [Route("[controller]/Atualizar")]
        public virtual ActionResult Atualizar(TViewModel viewModel)
        {
            var model = MapearParaModel(viewModel);

            AntesDeAtualizar(model, viewModel);

            Repo.Update(model);

            UOW.SaveChanges();

            DepoisDeAtualizar(viewModel, model);

            viewModel = MapearParaViewModel(model);

            return Ok(viewModel);
        }

        [HttpDelete]
        [Route("[controller]/Remover")]
        public virtual ActionResult Remover(TViewModel viewModel)
        {
            var model = MapearParaModel(viewModel);

            AntesDeRemover(model);

            Repo.Delete(model);

            UOW.SaveChanges();

            DepoisDeRemover(viewModel);

            return Ok(viewModel);
        }

        [HttpDelete]
        [Route("[controller]/RemoverPorId")]
        public virtual ActionResult RemoverPorId(int id)
        {
            var model = Repo.GetById(id);

            var viewModel = MapearParaViewModel(model);

            AntesDeRemover(model);

            Repo.Delete(model);

            UOW.SaveChanges();

            DepoisDeRemover(viewModel);

            return Ok(viewModel);
        }

        [HttpPost]
        [Route("[controller]/Listar")]
        public ActionResult Listar()
        {
            //public ActionResult Listar(List<TModel> model)
            return Ok(Repo.GetAll());
        }
    }
}
