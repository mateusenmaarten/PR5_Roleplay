using FluentValidation;
using PR5_Roleplay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roleplay.Validator
{
    public class CharacterValidator : AbstractValidator<Character>
    {
        public CharacterValidator()
        {
            RuleFor(x => x.CharacterName).NotNull();
            RuleFor(x => x.CharacterAge).InclusiveBetween(18, 99);
        }
    }
}
