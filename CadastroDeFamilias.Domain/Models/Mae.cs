using System;
using System.Collections.Generic;

namespace CadastroDeFamilias.Domain.Models
{
    public class Mae : BaseEntity
    {
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string FotoPath { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string TelefoneCelular { get; set; }
        public double? Altura { get; set; }
        public double? Peso { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public PapelUsuario PapelUsuario { get; set; }
        public Pai Pai { get; set; }
        public List<Filho> Filhos { get; set; }
    }
}
