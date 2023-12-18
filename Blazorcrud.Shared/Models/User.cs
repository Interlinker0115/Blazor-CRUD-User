using System.Text.Json.Serialization;

namespace Blazorcrud.Shared.Models
{
    public class User
    {
        public int Id {get; set;}
        public string FirstName {get; set;} = default!;
        public string LastName {get; set;} = default!;
        public string Username {get; set;} = default!;
        public int GroupNumber { get; set;} = default!;
        public DateOnly EntryDate { get; set;} = default!;
        public string Password {get; set;} = default!;

        public int Role {  get; set;} = default!;
        public string? Token {get; set;} = default!;
        public bool IsDeleting {get; set;} = default!;
        [JsonIgnore]
        public string? PasswordHash {get; set;}
    }
}