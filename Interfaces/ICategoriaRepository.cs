using ProjetoLivros_Home.Models;

namespace ProjetoLivros_Home.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> ListarTodosAsync();

        void Cadastrar(Categoria categoria);

        Categoria? Atualizar(int id, Categoria categoria);

        Categoria? Deletar(int id);
    }
}
