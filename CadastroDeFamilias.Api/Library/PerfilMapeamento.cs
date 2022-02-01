using AutoMapper;
using CadastroDeFamilias.Domain.Models;
using CadastroDeFamilias.ViewModels;

namespace CadastroDeFamilias.Api.Library
{
    public class PerfilMapeamento : Profile
    {
        public PerfilMapeamento()
        {
            CreateMap<Mae, MaeViewModel>();
            CreateMap<Pai, PaiViewModel>();
            CreateMap<Filho, FilhoViewModel>();
            CreateMap<Usuario, UsuarioViewModel>();
        }
    }
}
