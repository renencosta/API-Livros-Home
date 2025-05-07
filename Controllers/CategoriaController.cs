using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivros_Home.Interfaces;
using ProjetoLivros_Home.Models;

namespace ProjetoLivros_Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        //Injetar o repository
        private readonly ICategoriaRepository _repository;

        public CategoriaController(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]

        public async Task<IActionResult> ListarTodos()
        {
            return Ok(_repository.ListarTodosAsync());
        }

        [HttpPost]

        public IActionResult Cadastrar(Categoria categoria)
        {
            _repository.Cadastrar(categoria);
            return Created();
        }

        [HttpPut]

        public IActionResult Atualizar(int id, Categoria categoria)
        {
            _repository.Atualizar(id, categoria);
            return Ok();
        }

        [HttpDelete]

        public IActionResult Deletar(int id)
        {
            _repository.Deletar(id);
            return Ok();
        }
    }
}
