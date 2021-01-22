using FluentValidation;
using PR5_Roleplay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roleplay.Validator
{
    public class AdventureValidator : AbstractValidator<Adventure>
    {
        public AdventureValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Author).NotEmpty();
            RuleFor(x => x.Summary).NotEmpty().MinimumLength(10);
        }
    }
}
