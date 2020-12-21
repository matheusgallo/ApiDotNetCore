using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGraoOuro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        public readonly ITarefaRepository _repo;

        public TarefaController(ITarefaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _repo.GetTarefasAsync();

                return Ok(result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado");
            }
        }

        [HttpGet("buscarTarefa/{tarefaId}")]
        public async Task<IActionResult> GetById(int tarefaId)
        {
            try
            {
                var result = await _repo.GetTarefaAsyncById(tarefaId);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado");
            }
        }

        [HttpGet("minhasTarefas/{usuarioId}")]
        public async Task<IActionResult> GetByUsuario(int usuarioId)
        {
            try
            {
                var result = await _repo.GetTarefaAsyncByUsuarioId(usuarioId);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado");
            }
        }


        [HttpPost("criarTarefa/{usuarioId}")]
        public async Task<IActionResult> Post(Tarefa tarefa, int usuarioId)
        {
            try
            {
                tarefa.UsuarioId = usuarioId;
                _repo.Add(tarefa);

                return StatusCode(StatusCodes.Status201Created, "Tarefa criada com sucesso");

            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado");
            }
        }

        [HttpPut("editarTarefa/{tarefaId}")]
        public async Task<IActionResult> Put(int tarefaId, Tarefa tarefa)
        {
            try
            {
                var task =  await _repo.GetTarefaAsyncById(tarefaId);
                if (task == null) return BadRequest();

                if(tarefa.UsuarioId == 0) 
                    tarefa.UsuarioId = task.UsuarioId;

                _repo.Update(tarefa);

                return StatusCode(StatusCodes.Status202Accepted, "Tarefa editada");

            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado");
            }
        }
        [HttpDelete("removerTarefa/{tarefaId}")]
        public async Task<IActionResult> Delete(int tarefaId)
        {
            try
            {
                var tarefa = await _repo.GetTarefaAsyncById(tarefaId);
                if (tarefa == null) return BadRequest();

                _repo.Delete(tarefa);

                return StatusCode(StatusCodes.Status202Accepted, "Tarefa removida");

            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado");
            }
        }

    }

}
