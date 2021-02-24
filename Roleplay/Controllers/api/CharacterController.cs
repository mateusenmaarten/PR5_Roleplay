using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PR5_Roleplay.Models;
using Roleplay.Data.UnitOfWork;

namespace Roleplay.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public CharacterController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Character
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            return await _uow.CharacterRepository.GetAll()
                .Include(x => x.CharacterClass)
                .Include(x => x.Player)
                .ToListAsync();
        }

        // GET: api/Character/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            Character character = await _uow.CharacterRepository.GetById(id);

            if (character == null)
            {
                return NotFound();
            }

            return character;
        }

        // PUT: api/Character/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, Character character)
        {
            if (id != character.CharacterID)
            {
                return BadRequest();
            }

            _uow.CharacterRepository.Update(character);

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

        // POST: api/Character
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(Character character)
        {
            _uow.CharacterRepository.Create(character);
            try
            {
                await _uow.SaveAsync();
            }
            catch (Exception)
            {
                //foutmelding loggen
                return BadRequest();
            }

            return CreatedAtAction("GetCharacter", new { id = character.CharacterID }, character);
        }

        // DELETE: api/Character/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Character>> DeleteCharacter(int id)
        {
            var character = await _uow.CharacterRepository.GetById(id);
            if (character == null)
            {
                return NotFound();
            }

            _uow.CharacterRepository.Delete(character);

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
