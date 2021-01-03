using Contact.API.Models;
using FluentValidation;

namespace Contact.API.Validators
{
    public class CreateContactInformationValidator : AbstractValidator<CreateContactInformationModel>
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
