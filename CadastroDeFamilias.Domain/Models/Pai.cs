using System;

namespace CadastroDeFamilias.Domain.Models
{
    public class Pai : BaseEntity
    {
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string TelefoneCelular { get; set; }
        public double? Altura { get; set; }
        public double? Peso { get; set; }
        public string Senha { get; set; }
        public PapelUsuario PapelUsuario { get; set; }
        public int IdMae { get; set; }
        public Mae MaeModel { get; set; }
    }
}
