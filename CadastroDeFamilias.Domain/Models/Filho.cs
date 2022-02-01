using System;

namespace CadastroDeFamilias.Domain.Models
{
    public class Filho : BaseEntity
    {
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public int IdMae { get; set; }
        public Mae MaeModel { get; set; }
    }
}
