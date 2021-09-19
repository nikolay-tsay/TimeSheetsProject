using System.Threading.Tasks;
using TimeSheets.DTO;
using TimeSheets.Entities;

namespace TimeSheets.DAL.Services.Interfaces
{
    public interface IContractService : IBaseService<ContractDto, Contract>
    {
        Task FinishContractAsync(int id);
    }
}