using FluentValidation;

namespace MillionAndUp.API.Models.Validators.PropertyTrace
{
    /// <summary>
    /// Class to validate the attributes of the property trace Model
    /// </summary>
    public class PropertyTraceModelValidator : AbstractValidator<PropertyTraceModel>
    {
        public PropertyTraceModelValidator()
        {
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
