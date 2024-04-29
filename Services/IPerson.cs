using PersoModels;

namespace Labb3APIv2.Services
{
    public interface IPerson
    {
        Task<IEnumerable<Person>> GetAll();
  
        Task<IEnumerable<Person>> GetLimitedNum(int num);
        Task<Person> GetSingelPerson(int id);
        Task<IEnumerable<Person>> Serach(string name);

        Task<Person> Add(Person newEntity);
        Task<Person> AddInterestToPerson(int id, Interest newInterest);
        Task<Person> Ddelete(int id);
        Task<Person> Update(Person entity);
    }
}
