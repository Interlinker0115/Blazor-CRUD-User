using FluentValidation;

namespace Blazorcrud.Shared.Models
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(user => user.FirstName).NotEmpty().WithMessage("Grupo is a required field.")
                .Length(1, 50).WithMessage("Grupo must be between 1 and 50 characters.");
            RuleFor(user => user.LastName).NotEmpty().WithMessage("Descri��o is a required field.")
                .Length(3, 50).WithMessage("Descri��o must be between 3 and 50 characters.");
            RuleFor(user => user.Username).NotEmpty().WithMessage("Inclus�o is a required field.")
                .Length(5, 50).WithMessage("Inclus�o must be between 5 and 50 characters.");
            RuleFor(user => user.Password).NotEmpty().WithMessage("Usu�rio is a required field.")
                .Length(3, 50).WithMessage("Usu�rio must be between 3 and 50 characters.");
        }
    }
}