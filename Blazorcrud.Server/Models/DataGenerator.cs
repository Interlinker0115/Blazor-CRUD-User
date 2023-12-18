using Blazorcrud.Shared.Models;
using Bogus;

namespace Blazorcrud.Server.Models
{
    public class DataGenerator
    {
        public static void Initialize(AppDbContext appDbContext)
        {
           Randomizer.Seed = new Random(32321);
            appDbContext.Database.EnsureDeleted();
            appDbContext.Database.EnsureCreated();
            /*if (!(appDbContext.People.Any()))
                {
                    //Create test addresses
                    
                    // Create new people
                    var testPeople = new Faker<Blazorcrud.Shared.Models.Person>()
                        .RuleFor(p => p.GroupNumber, f => f.Random.Number())
                        .RuleFor(p => p.Description, f => f.Company.ToString())
                        .RuleFor(p => p.EntryDate, f => f.Date.RecentDateOnly())
                        .RuleFor(p => p.UserName, f=> "admin")
                        ;
                        
                    var people = testPeople.Generate(10);

                    foreach (Blazorcrud.Shared.Models.Person p in people)
                    {
                        appDbContext.People.Add(p);
                    }
                    appDbContext.SaveChanges();
                }*/

            

            if (!(appDbContext.Users.Any()))
            {
                var testUsers = new Faker<User>()
                    .RuleFor(u => u.FirstName, u => u.Name.FirstName())
                    .RuleFor(u => u.LastName, u => u.Name.LastName())
                    .RuleFor(u => u.Username, u => u.Internet.UserName())
                    .RuleFor(u => u.GroupNumber, u => u.Random.Number())
                    .RuleFor(u => u.EntryDate, u => u.Date.RecentDateOnly())
                    .RuleFor(u => u.Password, u => "admin")
                    .RuleFor(u => u.Role, u => u.Random.Number(1, 2))
                    ;
                var users = testUsers.Generate(0);

                User customUser = new User(){
                    FirstName = "Terry",
                    LastName = "Smith",
                    GroupNumber = 0,
                    EntryDate = DateOnly.MaxValue,
                    Username = "superadmin",
                    Password = "superadmin",
                    Role = 0,
                };
                User customUser1 = new User()
                {
                    FirstName = "Erica",
                    LastName = "Hirthe",
                    GroupNumber = 2,
                    EntryDate = DateOnly.MaxValue,
                    Username = "Grover",
                    Password = "admin",
                    Role = 2,
                };
                User customUser2 = new User()
                {
                    FirstName = "Bernard",
                    LastName = "Homenick",
                    GroupNumber = 2,
                    EntryDate = DateOnly.MaxValue,
                    Username = "Albina44",
                    Password = "admin",
                    Role = 1,
                };
                User customUser3 = new User()
                {
                    FirstName = "Garrison",
                    LastName = "Waelchi",
                    GroupNumber = 1,
                    EntryDate = DateOnly.MaxValue,
                    Username = "Constantin",
                    Password = "admin",
                    Role = 1,
                };
                User customUser4 = new User()
                {
                    FirstName = "Percival",
                    LastName = "Purdy",
                    GroupNumber = 1,
                    EntryDate = DateOnly.MaxValue,
                    Username = "Annamarie",
                    Password = "admin",
                    Role = 2,
                };
                users.Add(customUser);
                users.Add(customUser1);
                users.Add(customUser2);
                users.Add(customUser3);
                users.Add(customUser4);

                foreach (User u in users)
                {
                    u.PasswordHash = BCrypt.Net.BCrypt.HashPassword(u.Password);
                    u.Password = "**********";
                    appDbContext.Users.Add(u);
                }
                appDbContext.SaveChanges();
            }
        }
    }
}