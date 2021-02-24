using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PR5_Roleplay.Models;
using Roleplay.Data.UnitOfWork;

namespace Roleplay.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public SessionController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Session
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Session>>> GetSessions()
        {
            return await _uow.SessionRepository.GetAll()
                .Include(a => a.Adventure)
                .Include(s => s.SessionPlayers)
                .ToListAsync();
        }

        // GET: api/Session/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Session>> GetSession(int id)
        {
            var session = await _uow.SessionRepository.GetById(id);

            if (session == null)
            {
                return NotFound();
            }

            return session;
        }

        // PUT: api/Session/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSession(int id, Session session)
        {
            if (id != session.SessionID)
            {
                return BadRequest();
            }

            _uow.SessionRepository.Update(session);

            try
            {
                await _uow.SaveAsync();
            }
            catch (Exception)
            {
                //foutmelding loggen
                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/Session
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Session>> PostSession(Session session)
        {
            _uow.SessionRepository.Create(session);
            try
            {
                await _uow.SaveAsync();
            }
            catch (Exception)
            {
                //foutmelding loggen
                return BadRequest();
            }
            

            return CreatedAtAction("GetSession", new { id = session.SessionID }, session);
        }

        // DELETE: api/Session/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Session>> DeleteSession(int id)
        {
            var session = await _uow.SessionRepository.GetById(id);
            if (session == null)
            {
                return NotFound();
            }

            _uow.SessionRepository.Delete(session);
            try
            {
                await _uow.SaveAsync();
            }
            catch (Exception)
            {
                //foutmelding loggen
                return BadRequest();
            }

            return NoContent();
        }
    }
}
