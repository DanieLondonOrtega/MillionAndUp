using FluentValidation;

namespace MillionAndUp.API.Models.Validators
{
    /// <summary>
    /// Class to validate the attributes of the Owner Update Model
    /// </summary>
    public class OwnerUpdateModelValidator : AbstractValidator<OwnerUpdateModel>
    {
        public OwnerUpdateModelValidator()
        {
            RuleFor(x => x.IdOwner)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(x => x.Address)
                .MaximumLength(100);

            RuleFor(x => x.Birthday)
                .NotEmpty()
                .NotNull();
        }
    }
}
