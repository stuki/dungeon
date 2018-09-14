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