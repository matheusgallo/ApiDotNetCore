using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiGraoOuro.Data;
using ApiGraoOuro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGraoOuro.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {
    public readonly DataContext _context;

    public ValuesController(DataContext context)
    {
      _context = context;
    }
    // GET api/values
    [HttpGet()]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result =  await _context.Usuario.ToListAsync();
            return Ok(result);
        }
        catch (System.Exception)
        {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao retornar os dados, favor entrar em contato"
            );
        }
    }

    //// GET api/values/5
    // [HttpGet("{id}")]
    // public ActionResult<Usuario> Get(int id)
    // {
    //     return _context.Usuario.FirstOrDefault(x => id == x.UsuarioId);
    // }

    //// POST api/values
    //[HttpPost]
    //public void Post([FromBody] string value)
    //{
    //}

    //// PUT api/values/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    //// DELETE api/values/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}
  }
}
