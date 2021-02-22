using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PR5_Roleplay.Models;
using Roleplay.Data;

namespace Roleplay.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdventureController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdventureController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Adventure
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adventure>>> GetAdventures()
        {
            return await _context.Adventures.ToListAsync();
        }

        // GET: api/Adventure/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adventure>> GetAdventure(int id)
        {
            var adventure = await _context.Adventures.FindAsync(id);

            if (adventure == null)
            {
                return NotFound();
            }

            return adventure;
        }

        // PUT: api/Adventure/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdventure(int id, Adventure adventure)
        {
            if (id != adventure.AdventureID)
            {
                return BadRequest();
            }

            _context.Entry(adventure).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdventureExists(id))
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

        // POST: api/Adventure
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Adventure>> PostAdventure(Adventure adventure)
        {
            _context.Adventures.Add(adventure);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdventure", new { id = adventure.AdventureID }, adventure);
        }

        // DELETE: api/Adventure/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Adventure>> DeleteAdventure(int id)
        {
            var adventure = await _context.Adventures.FindAsync(id);
            if (adventure == null)
            {
                return NotFound();
            }

            _context.Adventures.Remove(adventure);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdventureExists(int id)
        {
            return _context.Adventures.Any(e => e.AdventureID == id);
        }
    }
}
