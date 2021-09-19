using System.Threading.Tasks;
using TimeSheets.Entities;

namespace TimeSheets.DAL.Repositories.Interfaces
{
    public interface IInvoiceRepository : IBaseRepository<Invoice>
    {
        Task CloseInvoiceAsync(int id);
    }
}