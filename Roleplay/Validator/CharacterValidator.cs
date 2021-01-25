using FluentValidation;
using PR5_Roleplay.Models;


namespace Roleplay.Validator
{
    public class CharacterValidator : AbstractValidator<Character>
    {
        public CharacterValidator()
        {
            RuleFor(x => x.CharacterName).NotEmpty().WithMessage("Your character needs a name");
            RuleFor(x => x.CharacterAge).NotEmpty().InclusiveBetween(18, 99).WithMessage("Please provide an age for your character");
            RuleFor(x => x.CharacterDescription).NotEmpty().WithMessage("Please describe your character");
            RuleFor(x => x.FavouriteWeapon).NotEmpty().WithMessage("Please provide the favourite weapon of your character");
        }
    }
}
