using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace ApiGraoOuro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuarioRepository _repo;
        public UsuarioController(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAsyncAll();

                return Ok(result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado");
            }
        }

        [HttpGet("detalheUsuario/{usuarioId}")]
        public async Task<IActionResult> GetById(int usuarioId)
        {
            try
            {
                var result = await _repo.GetUsuarioById(usuarioId);

                return Ok(result);
            }
            catch(System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            try
            {
                _repo.Add(usuario);

                return StatusCode(StatusCodes.Status201Created, "O usuário foi criado");
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado");
            }

        }

        [HttpPut("editarUsuario/{usuarioId}")]
        public async Task<IActionResult> Put(int usuarioId, Usuario usuario)
        {
            try
            {
                var user = await _repo.GetUsuarioById(usuarioId);
                if (user == null) return BadRequest();

                _repo.Update(usuario);

                return StatusCode(StatusCodes.Status201Created, "O usuário foi criado");
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado");
            }
        }
        [HttpDelete("removerUsuario/{usuarioId}")]
        public async Task<IActionResult> Delete(int usuarioId)
        {
            try
            {
                var user = await _repo.GetUsuarioById(usuarioId);
                if (user == null) return BadRequest();

                _repo.Delete(user);

                return StatusCode(StatusCodes.Status200OK, "Usuario Removido");
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado");
            }
        }

    }
}