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
    public class SessionsController : ControllerBase
    {
        private readonly DungeonContext _context;

        public SessionsController(DungeonContext context)
        {
            _context = context;
        }

        #region Session

        #if DEBUG

        // GET: api/Sessions
        [HttpGet]
        public IEnumerable<Session> GetSessions()
        {
            return _context.Sessions;
        }

        #endif

        // GET: api/Sessions/playerid/5
        [HttpGet("playerid/{id}")]
        public ActionResult<IEnumerable<Session>> GetSessions([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var session = _context.Players.Where(p => p.Id == id).SelectMany(p => p.PlayerSessions).Select(ps => ps.Session);

            if (session == null)
                return NotFound();

            return Ok(session);
        }

        // GET: api/Sessions/id/5
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetSession([FromRoute] string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var session = await _context.Sessions.FindAsync(id);

            session.PlayerSessions = _context.Sessions.Where(p => p.Id == id).SelectMany(p => p.PlayerSessions).Include("Player").ToList();

            session.Characters = _context.Characters.Where(c => c.SessionId == session.Id).ToList();

            if (session == null)
                return NotFound();

            return Ok(session);
        }

        // PUT: api/Sessions/id/5
        [HttpPut("id/{id}")]
        public async Task<IActionResult> PutSession([FromRoute] string id, [FromBody] Session session)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != session.Id)
                return BadRequest();

            _context.Entry(session).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Sessions
        [HttpPost]
        public async Task<ActionResult<Session>> PostSession([FromBody] Session session)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Random rnd = new Random();
            string code = rnd.Next(0, 9999).ToString().PadLeft(4, '0');

            session.CreatedAt = DateTime.Now;
            session.DungeonMasterId = session.CreatorId;
            session.Password = code;

            _context.Sessions.Add(session);

            PlayerSession playerSession = new PlayerSession(){ 
                PlayerId = session.CreatorId,
                SessionId = session.Id
            };

            _context.PlayerSessions.Add(playerSession);

            await _context.SaveChangesAsync();

            return Ok(session);
        }

        // POST: api/Sessions/:id/join
        [HttpPost("{id}/join")]
        public async Task<IActionResult> JoinSession([FromRoute] string id, [FromBody] Player player)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            PlayerSession playerSession = new PlayerSession()
            {
                PlayerId = player.Id,
                SessionId = id
            };

            _context.PlayerSessions.Add(playerSession);

            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Sessions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSession([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var session = await _context.Sessions.FindAsync(id);

            if (session == null)
                return NotFound();
                
            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();

            return Ok(session);
        }

        private bool SessionExists(string id)
        {
            return _context.Sessions.Any(e => e.Id == id);
        }

        #endregion

        #region Character

        // GET: api/Sessions/:sessionId/Characters/:playerId
        [HttpGet("{sessionId}/Character/{playerId:int}")]
        public async Task<IActionResult> GetCharacter([FromRoute] string sessionId, int playerId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var character = await _context.Characters.SingleOrDefaultAsync(c => c.PlayerId == playerId && c.SessionId == sessionId);

            if (character == null)
                return NotFound();

            return Ok(character);
        }

        // PUT: api/Sessions/:sessionId/Characters/:playerId
        [HttpPut("{sessionId}/Characters/{playerId:int}")]
        public async Task<IActionResult> PutCharacter([FromRoute] string sessionId, int playerId, [FromBody] Character character)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (sessionId != character.SessionId && playerId != character.PlayerId)
                return BadRequest();

            _context.Entry(character).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(character.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Sessions/:sessionId/Characters/create
        [HttpPost("{sessionId}/Characters/create")]
        public async Task<IActionResult> PostCharacter([FromBody] Character character)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            return Ok(character);
        }

        // DELETE: api/Sessions/:sessionId/Characters/
        [HttpDelete("{sessionId}/Characters/{id:int}/delete")]
        public async Task<IActionResult> DeleteCharacter([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var character = await _context.Characters.FindAsync(id);
            if (character == null)
                return NotFound();

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return Ok(character);
        }

        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.Id == id);
        }

        #endregion

        #region Logs
        // GET: api/Sessions/:sessionId/Logs/:id
        [HttpGet("{sessionId}/Logs/")]
        public async Task<ActionResult<List<Log>>> GetLog([FromRoute] string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var log = await _context.Logs.ToListAsync();

            log = log.Where(_ => _.SessionId == id).ToList();

            if (log == null)
                return NotFound();

            return Ok(log);
        }

        // PUT: api/Sessions/:sessionId/Logs/5
        [HttpPut("{sessionId}/Logs/{id}")]
        public async Task<IActionResult> PutLog([FromRoute] int id, [FromBody] Log log, string sessionId)
        {
            if (!ModelState.IsValid && log.SessionId != sessionId)
                return BadRequest(ModelState);

            if (id != log.Id)
                return BadRequest();

            _context.Entry(log).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Sessions/:sessionId/Logs
        [HttpPost("{sessionId}/Logs/create")]
        public async Task<IActionResult> PostLog([FromBody] Log log, [FromRoute] string sessionId)
        {
            if (!ModelState.IsValid && log.SessionId != sessionId)
                return BadRequest(ModelState);
            

            log.CreatedAt = DateTime.Now;

            _context.Logs.Add(log);
            await _context.SaveChangesAsync();

            return Ok(log);
        }

        // DELETE: api/Sessions/:sessionId/Logs/5
        [HttpDelete("{sessionId}/Logs/{id}/delete")]
        public async Task<IActionResult> DeleteLog([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var log = await _context.Logs.FindAsync(id);
            if (log == null)
                return NotFound();

            _context.Logs.Remove(log);
            await _context.SaveChangesAsync();

            return Ok(log);
        }

        private bool LogExists(int id)
        {
            return _context.Logs.Any(e => e.Id == id);
        }
        #endregion
    }
}