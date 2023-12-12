using FluentValidation;

namespace MillionAndUp.API.Models.Validators.Property
{
    /// <summary>
    /// Class to validate the attributes of the Property Update Model
    /// </summary>
    public class PropertyUpdateModelValidator : AbstractValidator<PropertyUpdateModel>
    {
        public PropertyUpdateModelValidator()
        {
            RuleFor(x => x.IdProperty)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.IdOwner)   
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(x => x.Address)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(x => x.Price)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.CodeInternal)
                .NotEmpty()
                .NotNull()
                .MaximumLength(5);

            RuleFor(x => x.Year)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
        }
    }
}
