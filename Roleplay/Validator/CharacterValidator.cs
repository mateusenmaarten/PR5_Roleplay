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
            RuleFor(x => x.CharacterName).NotEmpty();
            RuleFor(x => x.CharacterAge).NotEmpty().InclusiveBetween(18, 99);
            RuleFor(x => x.CharacterDescription).NotEmpty();
            RuleFor(x => x.FavouriteWeapon).NotEmpty();
        }
    }
}
