using Contact.API.Models;
using FluentValidation;

namespace Contact.API.Validators
{
    public class CreateContactInformationValidator : AbstractValidator<CreateContactInformationModel>
    {
        public CreateContactInformationValidator()
        {
            RuleFor(x => x.Phone)
                .NotNull()
               .WithMessage("The Phone must be at least 2 character long");
            RuleFor(x => x.Location)
                .MinimumLength(2)
                .WithMessage("The Location must be at least 2 character long");
        }
    }
}
