using Contact.Data.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Validators
{
    public class CreateContactValidator : AbstractValidator<Contacts>
    {
        public CreateContactValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("The first name must be at least 2 character long");
            RuleFor(x => x.Name)
               .MinimumLength(2)
               .WithMessage("The first name must be at least 2 character long");
        }
    }
}
