namespace Labb3APIv2.Services
{
    public interface IHobbyRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetSingel(int id);
        Task<T> Add(T newEntity);
        Task<T> Ddelete(int id);
        Task<T> Update(T entity);
        Task<IEnumerable<T>> Search(string name);
    }
}
