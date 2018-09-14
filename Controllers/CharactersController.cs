#if DEBUG

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dungeon;

namespace dungeon.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly DungeonContext _context;

        public CharactersController(DungeonContext context)
        {
            _context = context;
        }

        // GET: api/Characters
        [HttpGet]
        public IEnumerable<Character> GetCharacters()
        {
            return _context.Characters;
        }
    }
}
        
#endif