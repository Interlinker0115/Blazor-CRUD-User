namespace Blazorcrud.Shared.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName {get; set;} = default!;
        public string Gender { get; set; } = default!;
        public string PhoneNumber {get; set;} = default!;
        public bool IsDeleting {get; set;} = default!;
    }
}