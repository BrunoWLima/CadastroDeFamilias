using CadastroDeFamilias.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroDeFamilias.ViewModels
{
    public class PaiViewModel
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome Completo")]
        [StringLength(200, ErrorMessageResourceName = "MaximumStringLength")]
        public string NomeCompleto { get; set; }

        [Required]
        [Display(Name = "Data de Nascimento")]
        [MaxLength(10, ErrorMessageResourceName = "MaximumStringLength")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required]
        [Display(Name = "Email")]
        [MaxLength(150, ErrorMessageResourceName = "MaximumStringLength")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Telefone/Celular")]
        [MaxLength(16, ErrorMessageResourceName = "MaximumStringLength")]
        public string TelefoneCelular { get; set; }

        [Display(Name = "Altura")]
        [MaxLength(6, ErrorMessage = "MaximumStringLength")]
        public double? Altura { get; set; }

        [Display(Name = "Peso")]
        [MaxLength(6, ErrorMessage = "MaximumStringLength")]
        public double? Peso { get; set; }

        [Required]
        [Display(Name = "Senha")]
        [MaxLength(20, ErrorMessage = "MaximumStringLength")]
        public string Senha { get; set; }

        [Required]
        [Display(Name = "Confirmar Senha")]
        [MaxLength(20, ErrorMessage = "MaximumStringLength")]
        public string ConfirmarSenha { get; set; }

        public PapelUsuario PapelUsuario { get; set; }

        public int IdMae { get; set; }

        public MaeViewModel MaeModel { get; set; }
    }
}
