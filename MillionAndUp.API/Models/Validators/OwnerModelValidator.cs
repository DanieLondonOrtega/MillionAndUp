using FluentValidation;

namespace MillionAndUp.API.Models.Validators
{
    /// <summary>
    /// Class to validate the attributes of the Owner Model
    /// </summary>
    public class OwnerModelValidator : AbstractValidator<OwnerModel>
    {
        public OwnerModelValidator()
        {
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
