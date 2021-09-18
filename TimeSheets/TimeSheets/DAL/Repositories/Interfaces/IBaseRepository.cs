using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeSheets.DAL.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IList<T>> GetAll();

        Task<T> GetOne(int id);

        Task Create(T obj);
    }
}