#if DEBUG

using System.Collections.Generic;
using dungeon.Models;
using Microsoft.AspNetCore.Mvc;

namespace dungeon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly DungeonContext _context;

        public LogsController(DungeonContext context)
        {
            _context = context;
        }


        // GET: api/Logs
        [HttpGet]
        public IEnumerable<Log> GetLogs()
        {
            return _context.Logs;
        }
    }
}

#endif