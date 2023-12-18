using Blazorcrud.Shared.Data;
using Blazorcrud.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazorcrud.Server.Models
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _appDbContext;

        public PersonRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Person> AddPerson(Person person)
        {
            var result = await _appDbContext.People.AddAsync(person);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Person?> DeletePerson(int personId)
        {
            var result = await _appDbContext.People.FirstOrDefaultAsync(p => p.PersonId == personId);
            if (result is null) return null;
            _appDbContext.People.Remove(result);
            var resu = await _appDbContext.People.FirstOrDefaultAsync(p => p.PersonId == personId);
            await _appDbContext.SaveChangesAsync();
            return result;

        }

        public async Task<Person?> GetPerson(int personId)
        {
            var result = await _appDbContext.People
                .FirstOrDefaultAsync(p => p.PersonId == personId);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new KeyNotFoundException("Person not found");
            }
        }

        public PagedResult<Person> GetPeople(string? name, int page)
        {
            int pageSize = 5;

            if (name != null)
            {
                return _appDbContext.People
                    .Where(p => p.UserName.ToLower().Contains(name.ToLower()) ||
                        p.UserName.ToLower().Contains(name.ToLower()))
                    .OrderBy(p => p.PersonId)
                    .GetPaged(page, pageSize);
            }
            else
            {
                return _appDbContext.People
                    .OrderBy(p => p.PersonId)
                    .GetPaged(page, pageSize);
            }
        }

        public async Task<Person?> UpdatePerson(Person person)
        {
            var result = await _appDbContext.People.FirstOrDefaultAsync(p => p.PersonId == person.PersonId);
            if (result != null)
            {
                // Update existing person
                _appDbContext.Entry(result).CurrentValues.SetValues(person);


                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Person not found");
            }
            return result;
        }
    }
}