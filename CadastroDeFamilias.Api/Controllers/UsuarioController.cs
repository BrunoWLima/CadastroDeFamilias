using AutoMapper;
using CadastroDeFamilias.Domain.Models;
using CadastroDeFamilias.Infra;
using CadastroDeFamilias.Infra.Repository;
using CadastroDeFamilias.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeFamilias.Api.Controllers
{
    public class UsuarioController : CadastroDeFamiliasApiController<Usuario, UsuarioViewModel>
    {
        public MaeRepository MaeRepository => (MaeRepository)base.Repo;
        public UsuarioController(IUnitOfWork uow, IMapper mapper) : base(uow, uow.GetRepository<UsuarioRepository>(), mapper)
        {
        }

        protected override void AntesDeCriar(Usuario model, UsuarioViewModel viewModel)
        {
            base.AntesDeCriar(model, viewModel);
        }

        public override ActionResult Criar(UsuarioViewModel viewModel)
        {
            return base.Criar(viewModel);
        }

        protected override void DepoisDeCriar(UsuarioViewModel viewModel, Usuario model)
        {
            base.DepoisDeCriar(viewModel, model);
        }

        protected override void AntesDeAtualizar(Usuario model, UsuarioViewModel viewModel)
        {
            base.AntesDeAtualizar(model, viewModel);
        }

        public override ActionResult Atualizar(UsuarioViewModel viewModel)
        {
            return base.Atualizar(viewModel);
        }

        protected override void DepoisDeAtualizar(UsuarioViewModel viewModel, Usuario model)
        {
            base.DepoisDeAtualizar(viewModel, model);
        }

        protected override void AntesDeRemover(Usuario model)
        {
            base.AntesDeRemover(model);
        }

        public override ActionResult Remover(UsuarioViewModel viewModel)
        {
            return base.Remover(viewModel);
        }

        protected override void DepoisDeRemover(UsuarioViewModel viewModel)
        {
            base.DepoisDeRemover(viewModel);
        }
    }
}
