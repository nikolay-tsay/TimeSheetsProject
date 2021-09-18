using System.Threading.Tasks;
using TimeSheets.Entities;

namespace TimeSheets.DAL.Repositories.Interfaces
{
    public interface IContractRepository : IBaseRepository<Contract>
    {
        Task FinishContract(int id);
    }
}