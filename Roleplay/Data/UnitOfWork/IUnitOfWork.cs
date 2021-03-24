using PR5_Roleplay.Models;
using Roleplay.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roleplay.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<Adventure> AdventureRepository { get; }
        IGenericRepository<Character> CharacterRepository { get; }
        IGenericRepository<Session> SessionRepository { get; }
        Task SaveAsync();
    }
}
