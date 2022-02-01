namespace CadastroDeFamilias.Domain.Models
{
    public class Usuario : BaseEntity
    {
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string NomeLogin { get; set; }
        public string Senha { get; set; }
        public PapelUsuario PapelUsuario { get; set; }
        public bool Ativo { get; set; }
    }
}
