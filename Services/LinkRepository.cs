using Labb3APIv2.Data;
using Microsoft.EntityFrameworkCore;
using PersoModels;

namespace Labb3APIv2.Services
{
    public class LinkRepository : IHobbyRepository<Link>
    {
        private PersonDbConxtext _db;

        public LinkRepository(PersonDbConxtext db)
        {
            _db = db;
        }
        public async Task<Link> Add(Link newEntity)
        {
            var result = await _db.Links.AddAsync(newEntity);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Link> Ddelete(int id)
        {
            var result = await _db.Links.FirstOrDefaultAsync(l => l.LinkId == id);
            if (result != null)
            {
                _db.Links.Remove(result);
                await _db.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Link>> GetAll()
        {
            return await _db.Links.ToListAsync();
        }

        public async Task<Link> GetSingel(int id)
        {
            return await _db.Links.FirstOrDefaultAsync(l => l.LinkId == id);
        }

        public async Task<Link> Update(Link entity)
        {
            var result = await _db.Links.FirstOrDefaultAsync(l => l.LinkId == entity.LinkId);
            if (result != null)
            {
                result.LinkAddress = entity.LinkAddress;
                await _db.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<IEnumerable<Link>> Search(string name)
        {
            IQueryable<Link> query = _db.Links;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(l => l.LinkAddress.Contains(name));
            }
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<Link>> GetSpecificPersonInfo(int personalId)
        {
          
            var person = await _db.Persons.Include(p => p.Interest).ThenInclude(p =>p.Link)
                .FirstOrDefaultAsync(p => p.PersonId == personalId);
            if (person != null)
            {
                var links = person.Interest.SelectMany(i => i.Link);
                return links;
            }
            else
            {
                return null; // または適切な処理を行います。
            }

        }

    }
}
