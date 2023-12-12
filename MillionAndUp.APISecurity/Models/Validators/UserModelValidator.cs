using FluentValidation;

namespace MillionAndUp.APISecurity.Models.Validators
{
    public class UserModelValidator : AbstractValidator<UserModel>
    {
        public UserModelValidator()
        {
            RuleFor(x => x.Usuario)
                .NotEmpty()
                .NotNull()
                .MaximumLength(15);

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull();
        }
    }
}
