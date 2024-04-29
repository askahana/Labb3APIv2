using Labb3APIv2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using PersoModels;
using System;

namespace Labb3APIv2.Services
{
    public class InterestRepository : IHobbyRepository<Interest>
    {
        private PersonDbConxtext _db;
        public InterestRepository(PersonDbConxtext db)
        {
            _db = db;
        }
        public async Task<Interest> Add(Interest newEntity)
        {
            var result = await _db.Interests.AddAsync(newEntity);
            await _db.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<Interest> Ddelete(int id)
        {
            var result = await _db.Interests.FirstOrDefaultAsync(i => i.InterestId == id);
            if (result != null)
            {
                _db.Interests.Remove(result);
                await _db.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Interest>> GetAll()
        {
            return await _db.Interests.Include(l => l.Link).ToListAsync();
        }

        public async Task<Interest> GetSingel(int id)
        {
            return await _db.Interests.Include(l => l.Link).FirstOrDefaultAsync(i => i.InterestId == id);
        }

        public async Task<Interest> Update(Interest Entity)
        {
            var result = await _db.Interests.Include(l => l.Link).
                FirstOrDefaultAsync(i => i.InterestId == Entity.InterestId);
            if (result != null)
            {
                result.Description = Entity.Description;
                result.Title = Entity.Title;

                if(Entity.Link != null && Entity.Link.Any())
                {
                    foreach(var links in Entity.Link)
                    {
                        var existLink = await _db.Links.FindAsync(links.LinkId);
                        if(existLink != null)
                        {
                            result.Link.Add(existLink);
                        }
                    }
                }


                await _db.SaveChangesAsync();
                return result;

            }
            return null;
        }
        public async Task<IEnumerable<Interest>> Search(string name)
        {
            IQueryable<Interest> query = _db.Interests;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(i => i.Title.Contains(name)
                || i.Description.Contains(name));

            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Interest>> GetSpecificPersonInfo(int personalId)
        {
            var person = await _db.Persons.Include(p => p.Interest).ThenInclude(p => p.Link)
                .FirstOrDefaultAsync(p => p.PersonId == personalId);
            if (person != null)
            {
                return person.Interest;
            }
            else
            {
                return null; // または適切な処理を行います。
            }

        }
    }
}
