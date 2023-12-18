using FluentValidation;

namespace Blazorcrud.Shared.Models
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(person => person.Description).NotEmpty().WithMessage("Description is a required field.")
                .Length(3, 50).WithMessage("Description must be between 3 and 50 characters.");
           
        }
    }
}