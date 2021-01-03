using Contact.API.Models;
using FluentValidation;

namespace Contact.API.Validators
{
    public class CreateContactValidator : AbstractValidator<CreateContactModel>
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
