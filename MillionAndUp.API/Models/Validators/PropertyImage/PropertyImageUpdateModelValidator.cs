using FluentValidation;

namespace MillionAndUp.API.Models.Validators.PropertyImage
{
    public class PropertyImageUpdateModelValidator : AbstractValidator<PropertyImageUpdateModel>
    {
        public PropertyImageUpdateModelValidator()
        {
            RuleFor(x => x.IdPropertyImage)   
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.IdProperty) 
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.UploadFile.Length)
                .NotNull()
                .LessThanOrEqualTo(10000000)
                .WithMessage("File size is larger than allowed");

            RuleFor(x => x.UploadFile.ContentType)
                .NotNull()
                .Must(x => x.Contains("image/jpeg") || x.Contains("image/png") || x.Contains("image/jpg"))
                .WithMessage("File type is not allowed");
        }
    }
}
