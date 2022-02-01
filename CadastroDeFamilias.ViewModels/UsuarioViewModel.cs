using CadastroDeFamilias.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace CadastroDeFamilias.ViewModels
{
    public class UsuarioViewModel
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome Completo")]
        [StringLength(200, ErrorMessageResourceName = "MaximumStringLength")]
        public string NomeCompleto { get; set; }

        [Required]
        [Display(Name = "Email")]
        [MaxLength(150, ErrorMessageResourceName = "MaximumStringLength")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Nome Login")]
        [StringLength(20, ErrorMessageResourceName = "MaximumStringLength")]
        public string NomeLogin { get; set; }

        [Required]
        [Display(Name = "Senha")]
        [MaxLength(20, ErrorMessage = "MaximumStringLength")]
        public string Senha { get; set; }

        [Required]
        [Display(Name = "Confirmar Senha")]
        [MaxLength(20, ErrorMessage = "MaximumStringLength")]
        public string ConfirmarSenha { get; set; }

        public PapelUsuario PapelUsuario { get; set; }

        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }
    }
}
