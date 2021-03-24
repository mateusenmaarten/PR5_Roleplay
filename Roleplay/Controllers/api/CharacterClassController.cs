using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PR5_Roleplay.Models;
using Roleplay.Data.UnitOfWork;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Roleplay.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterClassController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public CharacterClassController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/CharacterClass

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterClass>>> GetCharacterClasses()
        {
            return await _uow.CharacterClassRepository.GetAll().ToListAsync();
        }

        // GET: api/CharacterClass/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterClass>> GetCharacterClass(int id)
        {
            CharacterClass characterClass = await _uow.CharacterClassRepository.GetById(id);

            if (characterClass == null)
            {
                return NotFound();
            }

            return characterClass;
        }
    }
}
