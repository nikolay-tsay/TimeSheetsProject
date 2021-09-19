using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeSheets.DAL.Services.Interfaces
{
    public interface IBaseService<TFirst, TSecond> 
        where TFirst : class
        where TSecond : class
    {
        Task<IList<TFirst>> GetAllAsync();

        Task<TFirst> GetOneAsync(int id);

        Task CreateAsync(TSecond obj);
    }
}