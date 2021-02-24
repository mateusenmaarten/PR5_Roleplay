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
        IUnitOfWork<Adventure> adventureRepository;
        IUnitOfWork<Character> characterRepository;
        IUnitOfWork<Session> sessionRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IUnitOfWork<Adventure> AdventureRepository
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

        public IUnitOfWork<Character> CharacterRepository
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

        public IUnitOfWork<Session> SessionRepository
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
