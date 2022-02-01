using System.ComponentModel.DataAnnotations;

namespace CadastroDeFamilias.Domain.Models
{
    public enum PapelUsuario
    {
        [Display(Name = "Master")] Master,
        [Display(Name = "Administrador")] Admin,
        [Display(Name = "Acesso Nível 1")] AcessoNivelUm,
        [Display(Name = "Acesso Nível 2")] AcessoNivelDois,
    };
}
