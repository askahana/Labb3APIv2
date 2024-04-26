using Labb3APIv2.Data;
using Microsoft.EntityFrameworkCore;
using PersoModels;

namespace Labb3APIv2.Services
{
    public class PersonRepository : IHobbyRepository<Person>
    {
        private PersonDbConxtext _db;

        public PersonRepository(PersonDbConxtext db)
        {
            _db = db;
        }
        public async Task<Person> Add(Person newEntity)
        {
            var reuslt = await _db.Persons.AddAsync(newEntity);
            await _db.SaveChangesAsync();
            return reuslt.Entity;
        }

        public async Task<Person> Ddelete(int id)
        {
            var result = await _db.Persons.FirstOrDefaultAsync(p => p.PersonId == id);
            if (result != null)
            {
                _db.Persons.Remove(result);
                await _db.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _db.Persons.Include(i => i.Interest).ThenInclude(l => l.Link).ToListAsync();
        }

        public async Task<Person> GetSingel(int id)
        {
            return await _db.Persons.Include(i => i.Interest).ThenInclude(l => l.Link).FirstOrDefaultAsync(p => p.PersonId == id);
        }

        public async Task<Person> Update(Person entity)
        {
            var result = await _db.Persons.Include(i => i.Interest).ThenInclude(l => l.Link).FirstOrDefaultAsync(p => p.PersonId == entity.PersonId);
            if (result != null)
            {
                result.Tel = entity.Tel;
                if (entity.Interest != null && entity.Interest.Any())
                {
                    // 新しい興味を追加
                    foreach (var hobby in entity.Interest)
                    {
                        var existingInterest = await _db.Interests.FindAsync(hobby.InterestId);
                        if (existingInterest != null)
                        {
                            result.Interest.Add(existingInterest);
                            
                        }
                    }
                }

                await _db.SaveChangesAsync();
                return result;
            }
            return null;
        }

        // Serach person
        public async Task<IEnumerable<Person>> Search(string name)
        {
            IQueryable<Person> query = _db.Persons;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.FirstName.Contains(name)
                || p.LastName.Contains(name));
            }
            return await query.ToListAsync();
        }

    }
}
