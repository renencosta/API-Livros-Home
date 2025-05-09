using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivros_Home.Interfaces;
using ProjetoLivros_Home.Models;
using ProjetoLivros_Home.Repositories;

namespace ProjetoLivros_Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            var usuarios = _repository.ListarTodos();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]

        public IActionResult ListarPorId(int id)
        {
            var usuarios = _repository.ListarPorId(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return Ok(usuarios);
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            _repository.Cadastrar(usuario);
            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarUsuario(int id, Usuario usuario)
        {
            var usuarioAtualizado = _repository.Atualizar(id, usuario);

            if(usuarioAtualizado == null)
            {
                return NotFound();
            }

            return Ok(usuarioAtualizado);
        }

        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            var usuarioDeletado = _repository.Deletar(id);

            if (usuarioDeletado == null)
            {
                return NotFound();
            }

            return Ok(usuarioDeletado);
        }
    }
}
