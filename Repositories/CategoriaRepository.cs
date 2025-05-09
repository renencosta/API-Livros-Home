using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProjetoLivros_Home.Context;
using ProjetoLivros_Home.Interfaces;
using ProjetoLivros_Home.Models;

namespace ProjetoLivros_Home.Repositories
{
    public class CategoriaRepository : ICategoriaRepository

    //Herdar e implementar a interface
    //Injetar o Contexto

    {
        private readonly LivrosContext _context;

        public CategoriaRepository(LivrosContext context)
        {
            _context = context;
        }

        public Categoria? Atualizar(int id, Categoria categoria)
        {
            var categoriaEncontrda = _context.Categorias.Find(id);

            if (categoriaEncontrda == null)
            {
                return null;
            }

            categoriaEncontrda.NomeCategoria = categoria.NomeCategoria;
            _context.SaveChanges();

            return categoriaEncontrda;
        }

        public void Cadastrar(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        public Categoria? Deletar(int id)
        {
            var categoriaEncontrada = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);

            if (categoriaEncontrada == null)
            {
                return null;
            }

            _context.Categorias.Remove(categoriaEncontrada);
            _context.SaveChanges();

            return categoriaEncontrada;
        }

        public Categoria? ListarPorId(int id)
        {
            var categoriaEncontrada = _context.Categorias.Find(id);

            return categoriaEncontrada;
        }

        public List<Categoria> ListarTodos()
        {
            return _context.Categorias.ToList();
        }
    }
}
