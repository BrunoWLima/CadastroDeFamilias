using AutoMapper;
using CadastroDeFamilias.Domain.Models;
using CadastroDeFamilias.Infra;
using CadastroDeFamilias.Infra.Repository;
using CadastroDeFamilias.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeFamilias.Api.Controllers
{
    public class MaeController : CadastroDeFamiliasApiController<Mae, MaeViewModel>
    {
        public MaeRepository MaeRepository => (MaeRepository)base.Repo;
        public MaeController(IUnitOfWork uow, IMapper mapper) : base(uow, uow.GetRepository<MaeRepository>(), mapper)
        {
        }

        protected override void AntesDeCriar(Mae model, MaeViewModel viewModel)
        {
            base.AntesDeCriar(model, viewModel);
        }

        public override ActionResult Criar(MaeViewModel viewModel)
        {
            return base.Criar(viewModel);
        }

        protected override void DepoisDeCriar(MaeViewModel viewModel, Mae model)
        {
            base.DepoisDeCriar(viewModel, model);
        }

        protected override void AntesDeAtualizar(Mae model, MaeViewModel viewModel)
        {
            base.AntesDeAtualizar(model, viewModel);
        }

        public override ActionResult Atualizar(MaeViewModel viewModel)
        {
            return base.Atualizar(viewModel);
        }

        protected override void DepoisDeAtualizar(MaeViewModel viewModel, Mae model)
        {
            base.DepoisDeAtualizar(viewModel, model);
        }

        protected override void AntesDeRemover(Mae model)
        {
            base.AntesDeRemover(model);
        }

        public override ActionResult Remover(MaeViewModel viewModel)
        {
            return base.Remover(viewModel);
        }

        protected override void DepoisDeRemover(MaeViewModel viewModel)
        {
            base.DepoisDeRemover(viewModel);
        }
    }
}
