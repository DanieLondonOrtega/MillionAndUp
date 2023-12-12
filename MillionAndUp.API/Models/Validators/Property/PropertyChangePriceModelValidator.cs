using FluentValidation;

namespace MillionAndUp.API.Models.Validators.Property
{
    public class PropertyChangePriceModelValidator : AbstractValidator<PropertyChangePriceModel>
    {
        public PropertyChangePriceModelValidator()
        {
            RuleFor(x => x.IdProperty)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Price)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
        }
    }
}
