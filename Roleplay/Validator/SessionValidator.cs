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
            RuleFor(x => x.Adventure).NotEmpty().WithMessage("Please select an adventure");
            RuleFor(x => x.SessionGamemaster).NotEmpty().WithMessage("Please provide who will be the gamemaster this session");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Please provide a date for the session");
            RuleFor(x => x.SessionPlayers).NotEmpty().WithMessage("Please select 2 or more players");
        }
    }
}
