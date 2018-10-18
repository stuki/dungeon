#if DEBUG

using System.Collections.Generic;
using dungeon.Models;
using Microsoft.AspNetCore.Mvc;

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