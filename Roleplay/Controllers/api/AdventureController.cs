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
    public class AdventureController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public AdventureController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Adventure
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adventure>>> GetAdventures()
        {
            return await _uow.AdventureRepository.GetAll().ToListAsync();
        }

        // GET: api/Adventure/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adventure>> GetAdventure(int id)
        {
            Adventure adventure = await _uow.AdventureRepository.GetById(id);

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

            _uow.AdventureRepository.Update(adventure);

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

        // POST: api/Adventure
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Adventure>> PostAdventure(Adventure adventure)
        {
            _uow.AdventureRepository.Create(adventure);
            try
            {
                await _uow.SaveAsync();
            }
            catch (Exception)
            {
                //foutmelding loggen
                return BadRequest();
            }
            

            return CreatedAtAction("GetAdventure", new { id = adventure.AdventureID }, adventure);
        }

        // DELETE: api/Adventure/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Adventure>> DeleteAdventure(int id)
        {
            Adventure adventure = await _uow.AdventureRepository.GetById(id);
            if (adventure == null)
            {
                return NotFound();
            }

            _uow.AdventureRepository.Delete(adventure);

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
