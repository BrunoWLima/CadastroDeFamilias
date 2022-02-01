using AutoMapper;
using CadastroDeFamilias.Domain.Models;
using CadastroDeFamilias.Infra;
using CadastroDeFamilias.Infra.Repository;
using CadastroDeFamilias.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeFamilias.Api.Controllers
{
    public class PaiController : CadastroDeFamiliasApiController<Pai, PaiViewModel>
    {
        public PaiRepository PaiRepository => (PaiRepository)base.Repo;
        public PaiController(IUnitOfWork uow, IMapper mapper) : base(uow, uow.GetRepository<PaiRepository>(), mapper)
        {
        }

        protected override void AntesDeCriar(Pai model, PaiViewModel viewModel)
        {
            base.AntesDeCriar(model, viewModel);
        }

        public override ActionResult Criar(PaiViewModel viewModel)
        {
            return base.Criar(viewModel);
        }

        protected override void DepoisDeCriar(PaiViewModel viewModel, Pai model)
        {
            base.DepoisDeCriar(viewModel, model);
        }

        protected override void AntesDeAtualizar(Pai model, PaiViewModel viewModel)
        {
            base.AntesDeAtualizar(model, viewModel);
        }

        public override ActionResult Atualizar(PaiViewModel viewModel)
        {
            return base.Atualizar(viewModel);
        }

        protected override void DepoisDeAtualizar(PaiViewModel viewModel, Pai model)
        {
            base.DepoisDeAtualizar(viewModel, model);
        }

        protected override void AntesDeRemover(Pai model)
        {
            base.AntesDeRemover(model);
        }

        public override ActionResult Remover(PaiViewModel viewModel)
        {
            return base.Remover(viewModel);
        }

        protected override void DepoisDeRemover(PaiViewModel viewModel)
        {
            base.DepoisDeRemover(viewModel);
        }
    }
}
