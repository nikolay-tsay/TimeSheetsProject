using System.Threading.Tasks;
using TimeSheets.DTO;
using TimeSheets.Entities;

namespace TimeSheets.DAL.Services.Interfaces
{
    public interface IInvoiceService : IBaseService<InvoiceDto, Invoice>
    {
        Task CloseInvoiceAsync(int id);
    }
}