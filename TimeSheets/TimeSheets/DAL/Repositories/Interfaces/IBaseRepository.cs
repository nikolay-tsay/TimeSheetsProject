using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeSheets.DAL.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsync();

        Task<T> GetOneAsync(int id);

        Task CreateAsync(T obj);
    }
}