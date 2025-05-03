namespace ProjetoLivros_Home.Models
{
    public class TipoUsuario
    {
        public int TipoUsuarioId { get; set; }

        public string DescricaoTipo { get; set; }

        public List<Usuario> Usuarios { get; set; } = new();
    }
}
