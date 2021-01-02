using Contact.Data.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Validators
{
    public class CreateContactInformationValidator : AbstractValidator<ContactInformations>
    {
        public CreateContactInformationValidator()
        {
            RuleFor(x => x.Info)
                .NotNull()
               .WithMessage("The first name must be at least 2 character long");
            RuleFor(x=>x.Info)
                .MinimumLength(2)
                .WithMessage("The first name must be at least 2 character long");
        }
    }
}
