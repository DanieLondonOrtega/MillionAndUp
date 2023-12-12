﻿using FluentValidation;

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

            RuleFor(x => x.File.Length)
                .NotNull()
                .LessThanOrEqualTo(10000000)
                .WithMessage("File size is larger than allowed");

            RuleFor(x => x.File.ContentType)
                .NotNull()
                .Must(x => x.Contains("image/jpeg") || x.Contains("image/png") || x.Contains("image/jpg"))
                .WithMessage("File type is not allowed");
        }
    }
}
