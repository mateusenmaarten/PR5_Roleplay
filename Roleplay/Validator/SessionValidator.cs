using FluentValidation;
using PR5_Roleplay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roleplay.Validator
{
    public class SessionValidator : AbstractValidator<Session>
    {
        public SessionValidator()
        {
            RuleFor(x => x.Adventure).NotEmpty();
            RuleFor(x => x.SessionGamemaster).NotEmpty();
            RuleFor(x => x.Date).NotEmpty();
            RuleFor(x => x.SessionPlayers).NotEmpty();
        }
    }
}
