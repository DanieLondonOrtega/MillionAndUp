using FluentValidation;

namespace MillionAndUp.API.Models.Validators.PropertyTrace
{
    /// <summary>
    /// Class to validate the attributes of the Property trace Update Model
    /// </summary>
    public class PropertyTraceUpdateModelValidator : AbstractValidator<PropertyTraceUpdateModel>
    {
        public PropertyTraceUpdateModelValidator()
        {
            RuleFor(x => x.IdPropertyTrace)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.IdProperty)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.DateSale)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(x => x.Value)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.Tax)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
        }
    }
}
