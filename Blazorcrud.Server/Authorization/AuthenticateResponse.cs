namespace Blazorcrud.Server.Authorization;
using Blazorcrud.Shared.Models;

public class AuthenticateResponse
{
    public int Id {get; set;}
    public int GroupNumber { get; set; } = default!;
    public string FirstName {get; set; } = default!;
    public string LastName {get; set; } = default!;
    public string Username {get;set; } = default!;
    public DateOnly EntryDate { get; set; } = default!;
    public int Role {  get; set; } = default!;
    public string Token { get; set; } = default!;
}