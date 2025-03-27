using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;

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

        
    }
}