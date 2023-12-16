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
            if (!(appDbContext.People.Any()))
                {
                    //Create test addresses
                    
                    // Create new people
                    var testPeople = new Faker<Blazorcrud.Shared.Models.Person>()
                        .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                        .RuleFor(p => p.LastName, f => f.Name.LastName())
                        .RuleFor(p => p.Gender, f => f.Random.String(10))
                        .RuleFor(p => p.PhoneNumber, f => f.Phone.PhoneNumber())
                        ;
                        
                    var people = testPeople.Generate(25);

                    foreach (Blazorcrud.Shared.Models.Person p in people)
                    {
                        appDbContext.People.Add(p);
                    }
                    appDbContext.SaveChanges();
                }

            

            if (!(appDbContext.Users.Any()))
            {
                var testUsers = new Faker<User>()
                    .RuleFor(u => u.FirstName, u => u.Name.FirstName())
                    .RuleFor(u => u.LastName, u => u.Name.LastName())
                    .RuleFor(u => u.Username, u => u.Internet.UserName())
                    .RuleFor(u => u.Password, u => u.Internet.Password());
                var users = testUsers.Generate(4);

                User customUser = new User(){
                    FirstName = "Terry",
                    LastName = "Smith",
                    Username = "admin",
                    Password = "admin"
                };

                users.Add(customUser);

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