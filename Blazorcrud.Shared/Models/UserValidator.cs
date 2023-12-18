using FluentValidation;

namespace Blazorcrud.Shared.Models
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(user => user.FirstName).NotEmpty().WithMessage("FirstName is a required field.")
                .Length(3, 50).WithMessage("FirstName must be between 3 and 50 characters.");
            RuleFor(user => user.LastName).NotEmpty().WithMessage("LastName is a required field.")
                .Length(3, 50).WithMessage("LastName must be between 3 and 50 characters.");
            RuleFor(user => user.Username).NotEmpty().WithMessage("UserName is a required field.")
                .Length(3, 50).WithMessage("UserName must be between 3 and 50 characters.");
            RuleFor(user => user.Password).NotEmpty().WithMessage("Password is a required field.")
                .Length(3, 50).WithMessage("Password must be between 3 and 50 characters.");
        }
    }
}