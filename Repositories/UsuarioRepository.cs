using ProjetoLivros_Home.Context;
using ProjetoLivros_Home.Interfaces;
using ProjetoLivros_Home.Models;

namespace ProjetoLivros_Home.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly LivrosContext _context;

        public UsuarioRepository(LivrosContext context)
        {
            _context = context;
        }

        public Usuario? Atualizar(int id, Usuario usuario)
        {
            var usuarioEncontrado = _context.Usuarios.Find(id);

            if (usuarioEncontrado == null)
            {
                return null;
            }

            usuarioEncontrado.NomeCompleto = usuario.NomeCompleto;
            usuarioEncontrado.Email = usuario.Email;
            usuarioEncontrado.Senha = usuario.Senha;
            usuarioEncontrado.Telefone = usuario.Telefone;
            usuarioEncontrado.DataAtualizacao = usuario.DataAtualizacao;
            usuarioEncontrado.DataCadastro = usuario.DataCadastro;
            usuarioEncontrado.TipoUsuario = usuario.TipoUsuario;

            _context.SaveChanges();
            return usuarioEncontrado;
        }

        public void Cadastrar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public Usuario? Deletar(int id)
        {
            var usuarioEncontrado = _context.Usuarios.Find(id);

            if (usuarioEncontrado == null)
            {
                return null;
            }

            _context.Usuarios.Remove(usuarioEncontrado);
            _context.SaveChanges();

            return usuarioEncontrado;
        }

        public Usuario? ListarPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.UsuarioId == id);
        }

        public List<Usuario> ListarTodos()
        {
            return _context.Usuarios.ToList();
        }
    }
}
