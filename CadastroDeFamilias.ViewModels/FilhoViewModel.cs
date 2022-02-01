using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroDeFamilias.ViewModels
{
    public class FilhoViewModel
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

        [Display(Name = "Altura")]
        [MaxLength(6, ErrorMessage = "MaximumStringLength")]
        public double? Altura { get; set; }

        [Display(Name = "Peso")]
        [MaxLength(6, ErrorMessage = "MaximumStringLength")]
        public double? Peso { get; set; }

        public int IdMae { get; set; }

        public MaeViewModel MaeModel { get; set; }
    }
}
