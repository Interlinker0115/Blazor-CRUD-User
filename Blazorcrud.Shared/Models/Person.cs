using Microsoft.VisualBasic;

namespace Blazorcrud.Shared.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public int GroupNumber { get; set; } = default!;
        public string Description {get; set;} = default!;
        public DateOnly EntryDate { get; set; } = default!;
        public string UserName {get; set;} = default!;
        public bool IsDeleting {get; set;} = default!;
    }
}