using PR5_Roleplay.Models;
using Roleplay.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roleplay.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        IGenericRepository<Adventure> adventureRepository;
        IGenericRepository<Character> characterRepository;
        IGenericRepository<CharacterClass> characterClassRepository;
        IGenericRepository<Session> sessionRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IGenericRepository<Adventure> AdventureRepository
        {
            get
            {
                if (this.adventureRepository == null)
                {
                    this.adventureRepository = new GenericRepository<Adventure>(_context);
                }
                return adventureRepository;
            }
        }

        public IGenericRepository<Character> CharacterRepository
        {
            get
            {
                if (this.characterRepository == null)
                {
                    this.characterRepository = new GenericRepository<Character>(_context);
                }
                return characterRepository;
            }
        }

        public IGenericRepository<CharacterClass> CharacterClassRepository
        {
            get
            {
                if (this.characterClassRepository == null)
                {
                    this.characterClassRepository = new GenericRepository<CharacterClass>(_context);
                }
                return characterClassRepository;
            }
        }

        public IGenericRepository<Session> SessionRepository
        {
            get
            {
                if (this.sessionRepository == null)
                {
                    this.sessionRepository = new GenericRepository<Session>(_context);
                }
                return sessionRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
