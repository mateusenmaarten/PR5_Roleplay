using FluentValidation;
using PR5_Roleplay.Models;


namespace Roleplay.Validator
{
    public class AdventureValidator : AbstractValidator<Adventure>
    {
        public AdventureValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Please provide a title for the adventure");
            RuleFor(x => x.Author).NotEmpty().WithMessage("Please provide the author of this adventure");
            RuleFor(x => x.Summary).NotEmpty().MinimumLength(10).WithMessage("Please describe the adventure");
        }
    }
}
