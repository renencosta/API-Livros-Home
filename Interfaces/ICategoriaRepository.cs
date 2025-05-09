using ProjetoLivros_Home.Models;

namespace ProjetoLivros_Home.Interfaces
{
    public interface ICategoriaRepository
    {
        List<Categoria> ListarTodos();

        void Cadastrar(Categoria categoria);

        Categoria? Atualizar(int id, Categoria categoria);

        Categoria? Deletar(int id);

        Categoria? ListarPorId(int id);
    }
}
