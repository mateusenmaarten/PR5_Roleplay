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
        IUnitOfWork<Adventure> AdventureRepository { get; }
        IUnitOfWork<Character> CharacterRepository { get; }
        IUnitOfWork<Session> SessionRepository { get; }
        Task SaveAsync();
    }
}
