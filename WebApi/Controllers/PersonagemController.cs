using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonagemController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public PersonagemController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonagem([FromBody] Personagem personagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _appDbContext.WebApiDB.Add(personagem);

            await _appDbContext.SaveChangesAsync();

            return StatusCode(201, personagem);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personagem>>> GetPersonagem()
        {
            var personagens = await _appDbContext.WebApiDB.ToListAsync();

            return Ok(personagens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Personagem>>> GetPersonagem(int id)
        {

            var personagem = await _appDbContext.WebApiDB.FindAsync(id);

            if (personagem == null)
            {
                return NotFound("Dados inválidos!");
            }

            return Ok(personagem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersonagem(int id, [FromBody] Personagem personagemAtualizado)
        {

            var personagemExistente = await _appDbContext.WebApiDB.FindAsync(id);

            if (personagemExistente == null)
            {
                return NotFound("Dados inválidos!");
            }

            _appDbContext.Entry(personagemExistente).CurrentValues.SetValues(personagemAtualizado);

            await _appDbContext.SaveChangesAsync();

            return StatusCode(201, personagemAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePersonagem(int id)
        {

            var personagem = await _appDbContext.WebApiDB.FindAsync(id);

            if (personagem == null)
            {
                return NotFound("Dados inválidos!");
            }

            _appDbContext.Remove(personagem);

            await _appDbContext.SaveChangesAsync();

            return Ok("Personagem Removido!");

        }
    }
}