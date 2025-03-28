using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> AddPersonagem(Personagem personagem)
        {
            if (personagem == null)
            {
                return BadRequest("Dados inválidos!");
            }

            _appDbContext.WebApiDB.Add(personagem);

            await _appDbContext.SaveChangesAsync();

            return StatusCode(201, personagem);
        }
    }
}