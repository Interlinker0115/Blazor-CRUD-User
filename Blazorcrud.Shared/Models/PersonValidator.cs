using FluentValidation;

namespace Blazorcrud.Shared.Models
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(person => person.FirstName).NotEmpty().WithMessage("First name is a required field.")
                .Length(3, 50).WithMessage("First name must be between 3 and 50 characters.");
            RuleFor(person => person.LastName).NotEmpty().WithMessage("Last name is a required field.")
                .Length(3, 50).WithMessage("Last name must be between 3 and 50 characters.");
            RuleFor(person => person.Gender).NotEmpty().WithMessage("Gender is a required field.")
                .Length(3, 50).WithMessage("Gender must be between 3 and 50 characters.");
            RuleFor(person => person.PhoneNumber).NotEmpty().WithMessage("Phone number is a required field.")
                .Length(5, 50).WithMessage("Phone number must be between 5 and 50 characters.");
           
        }
    }
}