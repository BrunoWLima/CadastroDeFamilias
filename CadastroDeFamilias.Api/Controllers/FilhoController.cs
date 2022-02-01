using AutoMapper;
using CadastroDeFamilias.Domain.Models;
using CadastroDeFamilias.Infra;
using CadastroDeFamilias.Infra.Repository;
using CadastroDeFamilias.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeFamilias.Api.Controllers
{
    public class FilhoController : CadastroDeFamiliasApiController<Filho, FilhoViewModel>
    {
        public MaeRepository MaeRepository => (MaeRepository)base.Repo;
        public FilhoController(IUnitOfWork uow, IMapper mapper) : base(uow, uow.GetRepository<FilhoRepository>(), mapper)
        {
        }

        protected override void AntesDeCriar(Filho model, FilhoViewModel viewModel)
        {
            base.AntesDeCriar(model, viewModel);
        }

        public override ActionResult Criar(FilhoViewModel viewModel)
        {
            return base.Criar(viewModel);
        }

        protected override void DepoisDeCriar(FilhoViewModel viewModel, Filho model)
        {
            base.DepoisDeCriar(viewModel, model);
        }

        protected override void AntesDeAtualizar(Filho model, FilhoViewModel viewModel)
        {
            base.AntesDeAtualizar(model, viewModel);
        }

        public override ActionResult Atualizar(FilhoViewModel viewModel)
        {
            return base.Atualizar(viewModel);
        }

        protected override void DepoisDeAtualizar(FilhoViewModel viewModel, Filho model)
        {
            base.DepoisDeAtualizar(viewModel, model);
        }

        protected override void AntesDeRemover(Filho model)
        {
            base.AntesDeRemover(model);
        }

        public override ActionResult Remover(FilhoViewModel viewModel)
        {
            return base.Remover(viewModel);
        }

        protected override void DepoisDeRemover(FilhoViewModel viewModel)
        {
            base.DepoisDeRemover(viewModel);
        }
    }
}
